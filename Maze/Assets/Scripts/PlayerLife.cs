using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    public int lives;
    public int coins;
    public GameObject sword;

    private bool isAttacking = false;

    public AudioSource attack;
    public AudioSource takeDamage;
    public AudioSource hitEnemy;
    
    public int getLives()
    {
        return lives;
    }

    public int getCoins()
    {
        return coins;
    }

    public void loseLife()
    {
        lives--;
    }

    public void gainLife()
    {
        lives++;
    }

    public int addCoins(int num)
    {
        coins = coins + num;
        return coins;
    }
    
    public int removeCoins(int num)
    {
        coins = coins - num;
        return coins;
    }
    
    void Start()
    {
        lives = 3;
        coins = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isAttacking == false)
            {
                Attack();
                attack.Play();
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (!isAttacking && collider.gameObject.CompareTag("Enemy"))
        {
            loseLife();
            takeDamage.Play();
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (isAttacking && collider.gameObject.CompareTag("Enemy"))
        {
            // Get the EnemyHealth component from the collided enemy
            EnemyHealth enemyHealth = collider.GetComponent<EnemyHealth>();

            if (enemyHealth != null)
            {
                int damageAmount = 1;
                enemyHealth.TakeDamage(damageAmount, transform.position);
                hitEnemy.Play();
            }
        }
    }

    void Attack()
    {
        isAttacking = true;
        StartCoroutine(swingSword());
    }

    IEnumerator swingSword()
    {
        float swordOffset = 0.6f; // Adjust this value based on the distance you want the sword to be from the player

        // Calculate the direction the player is moving in
        Vector2 movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        // Calculate the angle and set the sword's rotation
        float angle;

        if (movementDirection != Vector2.zero)
        {
            // If there is movement, calculate the angle based on the movement direction
            angle = Mathf.Atan2(movementDirection.y, movementDirection.x) * Mathf.Rad2Deg;
        }
        else
        {
            // If there is no movement, set a default angle to point the sword up (e.g., angle 0)
            angle = 90f;
        }

        Vector3 swordDirection = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad), 0f);
        Vector3 swordPosition = transform.position + swordDirection * swordOffset;

        GameObject newSword = Instantiate(sword, swordPosition, Quaternion.Euler(0f, 0f, angle - 45f));
        newSword.transform.parent = transform; // Unparent the sword from the player

        yield return new WaitForSeconds(0.5f);
        Destroy(newSword);
        isAttacking = false; // Reset the flag so the player can attack again
    }
}

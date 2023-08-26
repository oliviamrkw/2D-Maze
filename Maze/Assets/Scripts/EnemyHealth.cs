using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public GameManager gameManager;
    
    public int maxHealth = 3; // Set the maximum health for this enemy
    public int coinsOnDeath = 5; // Number of coins to drop upon death
    public float pushForce = 1f;

    private int currentHealth; // Current health of the enemy
    private Rigidbody2D rb;

    void Start()
    {
        currentHealth = maxHealth; // Initialize the enemy with full health
        rb = GetComponent<Rigidbody2D>(); // Get the enemy's Rigidbody2D component
    }

    public void TakeDamage(int damageAmount, Vector2 playerPosition)
    {
        if (currentHealth <= 0) // If the enemy is already defeated, don't do anything
        {
            return;
        }

        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            gameManager.KillEnemy(coinsOnDeath);
        }
        else
        {
            Vector2 pushDirection = transform.position - (Vector3)playerPosition;
            pushDirection.Normalize();
            rb.AddForce(pushDirection * pushForce, ForceMode2D.Impulse);
        }
    }
}

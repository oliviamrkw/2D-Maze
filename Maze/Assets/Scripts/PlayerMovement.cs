using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    public Sprite upSprite;
    public Sprite downSprite;
    public Sprite leftSprite;

    private SpriteRenderer spr;

    float diagSpeed = 0.7f;
    public float speed;
    float moveX;
    float moveY;

    private bool hasKey;

    public AudioSource open;
    public AudioSource getItemSound;

    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
        speed = 4f;
        hasKey = false;
    }

    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");

        if (moveX > 0)
        {
            spr.sprite = leftSprite;
            spr.sprite = FlipSprite(spr, true);
        }
        else if (moveX < 0)
        {
            spr.sprite = leftSprite;
            spr.sprite = FlipSprite(spr, false);
        }
        else if (moveY > 0)
        {
            spr.sprite = upSprite;
        }
        else if (moveY < 0)
        {
            spr.sprite = downSprite;
        }
    }

    Sprite FlipSprite(SpriteRenderer spriteRenderer, bool flip)
    {
        spriteRenderer.flipX = flip;
        return spriteRenderer.sprite;
    }

    void FixedUpdate()
    {
        if (moveX != 0 && moveY != 0)
        {
            moveX *= diagSpeed;
            moveY *= diagSpeed;
        } 

        Vector2 movement = new Vector2(moveX, moveY);
        movement = movement.normalized * speed * Time.deltaTime;

        rb.MovePosition(rb.position + movement);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Key"))
        {
            hasKey = true;
            Destroy(collision.gameObject);
            getItemSound.Play();
        }

        if (collision.gameObject.CompareTag("Door") && hasKey == true)
        {
            Destroy(collision.gameObject);
            hasKey = false;
            open.Play();
        }

        if (collision.gameObject.CompareTag("NextLevel"))
        {
            SceneManager.LoadScene("Level01");
        }

        if (collision.gameObject.CompareTag("Win"))
        {
            SceneManager.LoadScene("WinScreen");
        }
    }
}
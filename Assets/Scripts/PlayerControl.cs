using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    Rigidbody2D rb;

    public float speed = 5;
    public float jumpForce = 2;
    public KeyCode Right;
    public KeyCode Left;
    public KeyCode Space;
    public bool onGround;
    public bool isJumping;

    public int currentHealth;
    public int maxHealth = 100;

    public float knockback;
    public float knockbackDuration;
    public float knockbackCount;
    public bool knockbackRight;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        currentHealth = maxHealth;
    }

    private void Update()
    {
        // Player movement controls
        if (Input.GetKey(Right))
        {
            rb.transform.Translate(new Vector2(speed * Time.deltaTime, 0));
        }
        
        if (Input.GetKey(Left))
        {
            rb.transform.Translate(new Vector2(-speed * Time.deltaTime, 0));
        }

        if (knockbackCount <= 0)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        } else {
            if (knockbackRight)
                rb.velocity = new Vector2(-knockback, knockback);
            if (!knockbackRight)
                rb.velocity = new Vector2(knockback, knockback);
            knockbackCount -= Time.deltaTime;
        }

        if (Input.GetKeyDown(Space) && onGround == true)
        {
            SoundManagerScript.PlaySound("jump");
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isJumping = true;
        }
        else if (Input.GetKeyDown(Space) && isJumping == true)
        {
            SoundManagerScript.PlaySound("jump");
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isJumping = false;
        }


        // Update player health
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        // When player loses all of health, player dies
        if (currentHealth <= 0)
        {
            Die();
        }

        // Player move left, face left
        if (Input.GetAxis("Horizontal") < -0.1f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        // Player move right, face right
        if (Input.GetAxis("Horizontal") > 0.1f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    // When player is touching ground 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform") || collision.gameObject.CompareTag("Enemy"))
        {
            onGround = true;
        }
    }

    // When player is not touching ground
    private void OnCollisionExit2D(Collision2D collision)
    {
        onGround = false;
    }

    // Leads to restart scene
    void Die()
    {
        SceneManager.LoadScene("Restart");
    }

    void Win()
    {
        SceneManager.LoadScene("Victory");
    }

    // When player takes damage, red flash animation plays
    public void Damage(int dmg)
    {
        SoundManagerScript.PlaySound("takedmg");
        currentHealth -= dmg;
        gameObject.GetComponent<Animation>().Play("DamageFlash");
    }

    // Knock player up
    public IEnumerator Knockup(float knockupDuration, float knockupPower, Vector3 knockupDirection)
    {
        float timer = 0;
        rb.velocity = new Vector2(rb.velocity.x, 0);

        while (knockupDuration > timer)
        {
            timer += Time.deltaTime;
            rb.AddForce(new Vector3(knockupDirection.x * -100, knockupDirection.y * knockupPower, transform.position.z));
        }

        yield return 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "DeathZone")
        {
            Die();
        }

        if (collision.tag == "Victory")
        {
            Win();
        }
    }
}

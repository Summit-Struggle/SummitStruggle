using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private int health;
    private int maxhealth;

    private Animator anim;
    private Rigidbody2D rb;

    [SerializeField] private AudioSource deathSoundEffect;
    [SerializeField] HealthBar healthBar;


    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;
    [Header("Components")]
    [SerializeField] private Behaviour[] components;
    private bool invulnerable;

    
    private void Start()
    {
        anim = GetComponent<Animator>();    
        rb = GetComponent<Rigidbody2D>();

        //Sets max and current health to 100
        maxhealth = 100;
        health = 100;

        Debug.Log("max health: " + maxhealth);
        Debug.Log("Health: " + health);

    }

    private void Update()
    {
        if(health == 0)
        {
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            twentyPercentDmg();
        }


        if (collision.gameObject.CompareTag("20%damage"))
        {
            twentyPercentDmg();
        }

        if (collision.gameObject.CompareTag("Death"))
        {
            TakeDamage(maxhealth);
        }
    }

    private void Die()
    {
        anim.SetTrigger("death");
        deathSoundEffect.Play();
        rb.bodyType = RigidbodyType2D.Static;
        Debug.Log("Death");
        RestartLevel();
    }

    private void twentyPercentDmg ()
    {
        TakeDamage((int)(maxhealth * 0.2));
        Debug.Log("Health: " + health);
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //Separate damage for goblin attack
    public void TakeDamage(int damage) // need to update method and form an equation to calculate what the players new health should be.
    {
        anim.SetTrigger("TakeDamage");
        health -= damage;
        if(health <= 0)
        {
            Die();
        }
        else
        {
            healthBar.SetHealth(health);
        }
    }

    public void HealPlayer(int amount) // need to update method and form an equation to calculate what the players new health should be.
    {
        if((health + amount) > maxhealth)
        {
            health = maxhealth;
        } else
        {
            health = health + amount;
        }


        healthBar.SetHealth(health);
    }

    private void SetPlayersMaxHealth() //sets the players max health, can also do in the unity editor.
    {
        healthBar.SetHealth(maxhealth);
    }

    public int getHealth ()
    {
        return this.health;
    }

    public int getMaxHealth ()
    {
        return this.maxhealth;
    }
}

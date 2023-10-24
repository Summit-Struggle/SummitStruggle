using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private int health;
    private int maxhealth;

    private Animator anim;
    private Rigidbody2D rb;

    // [SerializeField] private AudioSource deathSoundEffect;
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
            TwentyPercentDmg();
        }


        if (collision.gameObject.CompareTag("20%damage"))
        {
            TwentyPercentDmg();
        }

        if (collision.gameObject.CompareTag("Death"))
        {
            Die();
        }
    }

    private void Die()
    {
        anim.SetTrigger("Die");
        // deathSoundEffect.Play();
        rb.bodyType = RigidbodyType2D.Static;
        Debug.Log("Death");
    }

    private void TwentyPercentDmg ()
    {
        TakeDamage((int)(maxhealth * 0.2));
        Debug.Log("Health: " + health);
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

  
    public void TakeDamage(int damage) // subtracts damage from current health
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
        Debug.Log("Healing...");
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

    //increase max health when upgrade bought in shop
    public void UpdateMaxHealth(int amount)
    {
        maxhealth += amount;
        //heal for this amount so it matches
        HealPlayer(amount);
    } 

    public int GetHealth ()
    {

        return health;
    }

      public void SetCurrentHealth (int amount)
    {
        health = amount;
        healthBar.SetHealth(health);
    }

    public int getMaxHealth ()
    {
        return this.maxhealth;
    }

    public void setHealthFromSave (int health)
    {
        healthBar.SetHealth(health);
    }

}

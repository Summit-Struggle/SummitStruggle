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

    
    private void Start()
    {
        anim = GetComponent<Animator>();    
        rb = GetComponent<Rigidbody2D>();   
    }

    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.gameObject.CompareTag("Trap"))
    //     {
    //         Die();
    //     }

    // }

    private void Die()
    {
        anim.SetTrigger("death");
        rb.bodyType = RigidbodyType2D.Static;
        deathSoundEffect.Play();
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void TakeDamage() // need to update method and form an equation to calculate what the players new health should be.
    {
        healthBar.SetHealth(health);
    }

    private void HealPlayer() // need to update method and form an equation to calculate what the players new health should be.
    {
        healthBar.SetHealth(health);
    }

    private void SetPlayersMaxHealth() //sets the players max health, can also do in the unity editor.
    {
        healthBar.SetHealth(maxhealth);
    }
}

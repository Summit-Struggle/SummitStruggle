using UnityEngine;
using System.Collections;

public class GoblinHealth : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] private float startingHealth;
    [SerializeField] private float currentHealth;
    private Animator anim;

    [Header("Components")]
    [SerializeField] private Behaviour[] components;
    [SerializeField] private GameObject obj;

    private SpriteRenderer spriteRend;
    private PlayerLevel playerLevel;
   [SerializeField] private Currency currency;
    private bool isDead;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
        playerLevel = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLevel>();
        isDead = false;
    }
   public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
        }
        else
        {
               //Start death animation
                playerLevel.XP += 150;
                isDead = true;
                anim.SetTrigger("die");
                currency.gainCoins(20);

        }
    }

   
    public void Destroy(){
          foreach (Behaviour component in components){ 
                    component.enabled = false;
                    }
         Destroy(obj);
    }
}
using UnityEngine;
using System.Collections;

public class GoblinHealth : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;

    [Header("Components")]
    [SerializeField] private Behaviour[] components;
    private bool dead;

    [SerializeField] private GameObject obj;

    private SpriteRenderer spriteRend;
    private PlayerLevel playerLevel;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
        playerLevel = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLevel>();
        dead = false;
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
            if (!dead)
            {
                anim.SetTrigger("die");
                // Dead();

                playerLevel.XP += 150;

                //Deactivate all attached component classes
                foreach (Behaviour component in components)
                    component.enabled = false;

                dead = true;
            }
        }
    }

    public void Dead()
    {
                Destroy(obj);
    }
}
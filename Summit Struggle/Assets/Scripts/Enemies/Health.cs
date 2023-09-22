using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
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

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
        dead = false;
    }
   public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("Hurt");
        }
        else
        {
            if (!dead)
            {
                anim.SetTrigger("Die");
                Dead();


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
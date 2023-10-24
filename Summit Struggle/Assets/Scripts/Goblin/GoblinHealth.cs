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

    //private bool alive;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
        playerLevel = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLevel>();
        //alive = true;
        
    }

    private void Update()
    {
        //if (currentHealth <= 0)
        //{
        //    setActive(false);
        //} 
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
            anim.SetTrigger("die");
        }
    }

   


    public void Destroy(){
          foreach (Behaviour component in components){ 
                    component.enabled = false;
                    }
         Destroy(obj);
    }

    public void setActive (bool alive)
    {
        if(alive)
        {
            obj.SetActive(true);
        } else
        {
            obj.SetActive(false);
        }
    }

    public void setDead ()
    {
        setActive(false);
    }

    public float getCurrentHealthForSave ()
    {
        return currentHealth;
    }

    public void setCurrentHealthForSave (float amount)
    {
        currentHealth = amount;
    }
}
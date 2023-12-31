using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header ("Attack Parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private int damage;

    [Header("Collider Parameters")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;

    [Header("Enemy Layer")]
    [SerializeField] private LayerMask enemyLayer;
    private float cooldownTimer = Mathf.Infinity;

    //References
    private Animator anim;
    private GoblinHealth enemyHealth;

    public int numOfKills;

  
  private void Awake()
  {
    anim = GetComponent<Animator>();
    numOfKills = 0;

  }

    // Update is called once per frame
    private void Update()
    {
        cooldownTimer += Time.deltaTime;
        
        if(Input.GetMouseButtonDown(0))
        {
            cooldownTimer = 0;
            anim.SetTrigger("Melee");

        }
    }

    private void Attack() {
        // PlayerAttack attack box 
        RaycastHit2D hit = 
            Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, enemyLayer);

       if (hit.collider != null)
       {
            enemyHealth = hit.transform.GetComponent<GoblinHealth>();
            enemyHealth.TakeDamage(damage);

            if(enemyHealth.getCurrentHealthForSave() <= 0)
            {
                numOfKills++;
            }
       }
       
    }


     private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

}

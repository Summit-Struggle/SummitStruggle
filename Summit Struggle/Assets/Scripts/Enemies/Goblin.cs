using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private int damage;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = mathf.Infinity;

    private void update()
    {
        cooldownTimer = Time.deltaTime;

        //attack only when enemy sees player.
        if(PlayerInSight()){
            if(cooldownTimer >= attackCooldown)
            {
                //attack

            }
        }
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size,
         0, Vector2.left, 0, PlayerLayer);

        return hit.collider != null;
     
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center, boxCollider.bounds.size);
    }
}

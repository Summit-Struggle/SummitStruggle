using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //variables
    Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    private float dirX = 0f;
    private SpriteRenderer sprite;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    [SerializeField] private LayerMask jumpableGround;

    // private enum MovementState { idle, running, jumping, falling }

    [SerializeField] private AudioSource jumpSoundEffect;
    


    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();    
        coll = GetComponent<BoxCollider2D>();   
    }

    // Update is called once per frame
    private void Update()
    {        
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        
        if (Input.GetKeyDown("space"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            // jumpSoundEffect.Play();
        }



        UpdateAnimation();
        
    }

    private void UpdateAnimation()
    {
        // MovementState state;

        if (dirX > 0f)
        {
            anim.SetBool("Running", true);
            // state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            anim.SetBool("Running", true);
            // state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            anim.SetBool("Running", false);
            // state = MovementState.idle;
        }

        if (rb.velocity.y > .01f)
        {
            anim.SetBool("Jumping", true);
            // state = MovementState.jumping;
        }

        else if (rb.velocity.y < -.1f)
        {
            // state = MovementState.falling;
        }

        // anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

}

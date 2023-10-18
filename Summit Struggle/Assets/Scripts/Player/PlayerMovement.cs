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
    private bool doubleJump;

    public KeybindUI keybindUI;

    // private enum MovementState { idle, running, jumping, falling }

    [SerializeField] private AudioSource jumpSoundEffect;



    // Start is called before the first frame update
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();

        // Ensure you have a reference to the KeybindUI script
        keybindUI = FindObjectOfType<KeybindUI>();
        if (keybindUI == null)
        {
            Debug.LogError("KeybindUI not found. Make sure it's in the scene.");
        }
    }

    // Update is called once per frame
    private void Update()
    {
        //<<<<<<< HEAD:Summit Struggle/Assets/Scripts/PlayerMovement.cs
        //dirX = Input.GetAxisRaw("Horizontal");
        //rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        dirX = 0f;

        // Use custom key bindings for right and left movements
        if (Input.GetKey(keybindUI.GetKeyBinding("Right")))
        {
            dirX = 1f;
        }
        else if (Input.GetKey(keybindUI.GetKeyBinding("Left")))
        {
            dirX = -1f;
        }
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetKeyDown(keybindUI.GetKeyBinding("Jump")))
        {

            //=======
            dirX = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

            if (IsGrounded() && !Input.GetKeyDown("space"))
            {
                doubleJump = false;
            }


            if (Input.GetKeyDown("space"))
            {
                if (IsGrounded() || doubleJump)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                    doubleJump = !doubleJump;
                }
            }

            if (Input.GetKeyDown("space") && IsGrounded())
            {
                //>>>>>>> main:Summit Struggle/Assets/Scripts/Player/PlayerMovement.cs
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                // jumpSoundEffect.Play();
            }

            //if (Input.GetKey(keybindUI.GetKeyBinding("Attack")))
            //{
            // will be teplace the conditions above with the correct ones based on your attack input
            // Trigger the player's attack action
            //}

            UpdateAnimation();

        }
    }

    private void UpdateAnimation()
    {
        // MovementState state;

        if (dirX > 0f)
        {
            anim.SetBool("Idle", false);
            anim.SetBool("Running", true);
            sprite.flipX = false;
             if (rb.velocity.y > .01f)
             { 
            anim.SetBool("Jumping", true);
            anim.SetBool("Running", false);
           
             }
          else if (rb.velocity.y < -.1f)
            {
            anim.SetBool("Jumping", false);
            anim.SetBool("Falling", true);
             }
        }
        else if (dirX < 0f)
        {
            anim.SetBool("Idle", false);
            anim.SetBool("Running", true);
            sprite.flipX = true;
               if (rb.velocity.y > .01f)
        {
            anim.SetBool("Jumping", true);
            anim.SetBool("Running", false);
        }
          else if (rb.velocity.y < -.1f)
        {
            anim.SetBool("Running", false);
            anim.SetBool("Jumping", false);
            anim.SetBool("Falling", true);
        }
        }
        else
        {
            anim.SetBool("Falling", false);
            anim.SetBool("Running", false);
        }

        //jumping from stationary position
        if (rb.velocity.y > .01f)
        {
            anim.SetBool("Jumping", true);
        }

        else if (rb.velocity.y < -.1f)
        {
            anim.SetBool("Jumping", false);
            anim.SetBool("Falling", true);
        }
        else
        {
           anim.SetBool("Falling", false); 
        }

        // anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

}

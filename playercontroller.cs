using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    float runSpeed = 7f; //all variables needed for physics and interaction as well as triggers
    float climbSpeed = 3f;
    float jumpSpeed = 6f;
    float gravityScale;
    Rigidbody2D rb;
    Animator anim;
    bool isWalking = false;
    bool isAlive = true;
    bool isJumping = false;

    void Start() //starting run up commands
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        gravityScale = rb.gravityScale;
    }

    void Update() //constant checks
    {
        if (!isAlive) { return;}
        walk();
        Jump();
        FlipDirection();
        climb();
        Die();
    }

    void walk()
    {
        float axisVal = Input.GetAxis("Horizontal"); //input runs
        Vector2 walkVelocity = new Vector2(axisVal * runSpeed, rb.velocity.y);
        rb.velocity = walkVelocity;

        if(isWalking) {anim.SetBool("walk", true);} //animation sets
        else {anim.SetBool("walk", false);}
    }

    void Jump()
    {
        if (!rb.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return; } //making sure he is on ground
        
        if(Input.GetButtonDown("Jump")) //jump action
        {
            Vector2 jumpVelocity = new Vector2(0f, jumpSpeed);
            rb.velocity += jumpVelocity;
            isJumping = true;
        }
        if (Mathf.Abs(rb.velocity.y) < Mathf.Epsilon) { isJumping = false; };
        if (isJumping) { anim.SetBool("jump", true); } //animation sets
        else { anim.SetBool("jump", false); }
    }

    void FlipDirection() //still have no idea how this flips the character
    {
        isWalking = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        if (isWalking)
        {
            transform.localScale = new Vector2( Mathf.Sign(rb.velocity.x), 1f);
        }
    }

    void climb()
    {
        if (!rb.IsTouchingLayers(LayerMask.GetMask("Ladder"))) //so when you are not climbing it limits
        {
            anim.SetBool("climb", false); 
            gravityScale = rb.gravityScale;
            float axsVal = Input.GetAxis("Horizontal");
            Vector2 walkVelocity = new Vector2(axsVal * runSpeed, rb.velocity.y);
            rb.velocity = walkVelocity;
            return;
        }

        float axisVal = Input.GetAxis("Vertical"); //when you are climbing it allows it
        Vector2 climbVelocity = new Vector2(rb.velocity.x, axisVal * climbSpeed);
        rb.velocity = climbVelocity;
        gravityScale = 0;
        if ( Mathf.Abs(rb.velocity.y) > Mathf.Epsilon )
        {
            anim.SetBool("climb", true);
        }

    }
    void Die()
    {
        if (rb.IsTouchingLayers(LayerMask.GetMask("Enemy","Hazard"))) //character death
        {
            anim.SetTrigger("dead");
            rb.velocity = new Vector2(1f, 4f);
            isAlive = false;
            StartCoroutine(PlayerDied());
        }
    }
    IEnumerator PlayerDied() //waits a few seconds for death animation
    {
        yield return new WaitForSecondsRealtime(3f);
        FindObjectOfType<GameManager>().ProcessPlayerDeath();
    }
}
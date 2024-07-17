using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    PlayerManagement management;
    PlayerMovement movement;
    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer sprite;

    bool alive = true;
    private void Start()
    {
        management = GetComponent<PlayerManagement>();
        movement = GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        Running();
        if (alive)
        {
            Jumping();
        }
    }
    public void Running()
    {
        if (movement.horizontalMovement!=0)
        {
            animator.SetFloat("xVelocity", movement.horizontalMovement);
        }
    }
    public void Jumping()
    {
        animator.SetBool("isJumping", movement.isJumping);
        if (movement.isJumping)
        {
            animator.SetFloat("yVelocity", rb.velocity.y);
        }
    }
    public void Damage()
    {
        alive = false;
        animator.SetBool("isJumping", alive);
        animator.SetTrigger("isDamaged");
    }

    public void DisableSprite()
    {
        sprite.enabled = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float speed = 2f;
    float jumpForce = 4f;
    float groundCheckRadius = 0.06f;

    private Rigidbody2D rb2D;
    private bool grounded;

    [SerializeField] GameObject foot;

    public bool isJumping;
    public float horizontalMovement;
    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        {
            horizontalMovement = Input.GetAxis("Horizontal");
            rb2D.velocity = new Vector2(horizontalMovement * speed, rb2D.velocity.y);

            RotateTowardsMovementDirection(horizontalMovement);
        } // Movement
        {
            IsGrounded();
            if (Input.GetButtonDown("Jump") && grounded)
            {
                rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);
            }
        } // Jump action
    }
    private void IsGrounded()
    {
        int layerMask = 1 << 7; // Only checks layer 7
        Collider2D[] colliders = Physics2D.OverlapCircleAll(foot.transform.position, groundCheckRadius, layerMask);
        grounded = colliders.Length > 0;
        isJumping = !grounded;
    } // Checks if the player is on land
    private void RotateTowardsMovementDirection(float horizontalMovement)
    {
        if (horizontalMovement < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (horizontalMovement > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    } // Rotate player toward movement direction
}
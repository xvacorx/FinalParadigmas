using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneEnemy : Enemy
{
    public float detectionRange = 5f;
    private Rigidbody2D rb;
    private bool hasFallen = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, detectionRange);
        Debug.DrawRay(transform.position, Vector2.down * detectionRange, Color.red);

        if (!hasFallen && hit.collider != null && hit.collider.CompareTag("Player"))
        {
            Fall();
        }
    }

    void Fall()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        hasFallen = true;
        gameObject.tag = "Trap";
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasFallen && collision.gameObject.CompareTag("Terrain"))
        {
            gameObject.tag = "Terrain";
        }
        if (collision.gameObject.CompareTag("PlayerWeapon"))
        {
            LoseLife(1f);
        }
    }
}

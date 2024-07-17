using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeEnemy : Enemy
{
    public float speed = 2f;
    private Rigidbody2D rb;
    private Vector2 direction = Vector2.up;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = direction * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            direction = -direction;
        }
        if (collision.gameObject.CompareTag("PlayerWeapon"))
        {
            LoseLife(1f);
        }
    }
}
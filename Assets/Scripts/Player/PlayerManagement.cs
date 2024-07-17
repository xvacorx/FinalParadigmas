using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManagement : MonoBehaviour
{
    PlayerMovement movement;
    PlayerAnimations animations;
    Rigidbody2D rb;

    private void Start()
    {
        movement = GetComponent<PlayerMovement>();
        animations = GetComponent<PlayerAnimations>();
        rb = GetComponent<Rigidbody2D>();
        movement.enabled = true;
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    public void TakeDamage()
    {
        HUD.Instance.AddDeathCount();
        animations.Damage();
        movement.enabled = false;
        rb.bodyType = RigidbodyType2D.Static;
        HUD.Instance.DeductScorePercentage(0.6f);
    }
}

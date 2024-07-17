using System.Collections;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public float initialSpeed = 10f;
    public float durationBeforeShrink = 2f;
    public float shrinkDuration = 1f;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private CircleCollider2D circlecollider;

    private Vector2 direction;

    private void Start()
    {
        circlecollider = GetComponent<CircleCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = direction * initialSpeed;
        StartCoroutine(LifetimeCoroutine());
    }

    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            sprite.enabled = false;
            circlecollider.enabled = false;
            Destroy(gameObject, 1f); // Un segundo de delay para asegurarse que funcione el resto de cosas
        }
    }

    private IEnumerator LifetimeCoroutine()
    {
        yield return new WaitForSeconds(durationBeforeShrink);
        float elapsedTime = 0f;
        Vector3 initialScale = transform.localScale;
        Vector3 targetScale = Vector3.zero;

        while (elapsedTime < shrinkDuration)
        {
            transform.localScale = Vector3.Lerp(initialScale, targetScale, elapsedTime / shrinkDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localScale = targetScale;
        Destroy(gameObject);
    }
}
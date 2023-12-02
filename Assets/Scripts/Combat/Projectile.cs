using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    [Header("Properties"), Space(8)]

    [SerializeField] float damage = 15f;
    [Tooltip("If gravity is enabled, this will become an impulse, not a velocity.")]
    [SerializeField] float speed = 15f;
    [SerializeField] bool gravityEnabled = false;

    [SerializeField] LayerMask mask;

    [Header("Events"), Space(8)]
    public ContactPoint2DEvent onHitObject;

    Rigidbody2D rb;
    Vector2 dir;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = gravityEnabled ? rb.gravityScale : 0f;
        if (gravityEnabled)
        {
            rb.AddForce(dir * speed, ForceMode2D.Impulse);
        }
    }

    void FixedUpdate()
    {
        rb.velocity = gravityEnabled ? rb.velocity : dir * speed;
    }

    public void SetDirection(Vector2 dir)
    {
        this.dir = dir;
    }

    public void SetDamage(float d) => damage = d;
    public void SetMuzzleVelocity(float v) => speed = v;

    public void SetLayerMask(LayerMask newMask) => mask = newMask;

    // void OnTriggerEnter2D(Collider2D other)
    void OnCollisionEnter2D(Collision2D col)
    {
        if (GameUtils.IsOnLayerMask(col.gameObject.layer, mask))
        {
            if (col.gameObject.TryGetComponent(out HealthSystem hp))
            {
                hp.RemoveHp(damage);
                onHitObject?.Invoke(col.GetContact(0));
                return;
            }
        }

        if (!col.collider.isTrigger)
            onHitObject?.Invoke(col.GetContact(0));
    }
}
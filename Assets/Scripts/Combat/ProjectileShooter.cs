using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ProjectileShooter : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] Projectile projectilePrefab;
    [SerializeField] Transform shootPoint;
    [SerializeField] LayerMask projectileMask = ~0;
    [SerializeField] float damage = 5;
    [SerializeField] float muzzleVelocity = 10;
    [SerializeField] bool auto = true;
    [SerializeField] float roundsPerMinute = 550f;

    [Header("Events")]
    public UnityEvent onShoot;

    bool isShooting;
    float nextShootingTime;
    bool notAutoShootState;
    float _damage;

    private void Start()
    {
        SetDamageMultiplier(1f);
    }

    void Update()
    {
        if (!auto && !notAutoShootState) return;

        if (isShooting && Time.time >= nextShootingTime && projectilePrefab != null)
        {
            var bullet = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);
            bullet.SetDirection(shootPoint.right);
            bullet.SetLayerMask(projectileMask);
            bullet.SetDamage(_damage);
            bullet.SetMuzzleVelocity(muzzleVelocity);

            nextShootingTime = Time.time + 1f / (roundsPerMinute / 60f);
            notAutoShootState = false;

            onShoot?.Invoke();
        }
    }

    public void SetShootingState(bool state)
    {
        if (isShooting != state && state)
        {
            notAutoShootState = true;
        }

        isShooting = state;
    }

    public bool IsAuto() => auto;

    public void SetDamageMultiplier(float m)
    {
        _damage = damage * m;
    }
}

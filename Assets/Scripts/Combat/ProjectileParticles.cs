using UnityEngine;

public class ProjectileParticles : MonoBehaviour
{
    [SerializeField] Transform particle;
    public void Spawn(ContactPoint2D contact)
    {
        float angle = Mathf.Atan2(contact.normal.y, contact.normal.x) * Mathf.Rad2Deg;
        var rot = Quaternion.Euler(0, 0, angle - 90);

        var obj = Instantiate(particle, contact.point, rot);
    }
}
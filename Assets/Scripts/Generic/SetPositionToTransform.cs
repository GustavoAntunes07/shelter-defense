using UnityEngine;

class SetPositionToTransform : MonoBehaviour
{
    [SerializeField] Transform target;

    void Update()
    {
        if (target != null)
            transform.position = target.position;
    }

    public void DeattachFromParent()
    {
        transform.SetParent(null);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAnimation : MonoBehaviour
{
    public float range = 1f;
    public float threshold = .01f;
    public float offsetY = .35f;
    public float damping = .3f;

    bool goingUp = true;
    float currentVelocity;
    Vector3 pos;

    private void Update()
    {
        if (goingUp)
            pos.y = Mathf.SmoothDamp(pos.y, range, ref currentVelocity, damping);
        else
            pos.y = Mathf.SmoothDamp(pos.y, -range, ref currentVelocity, damping);

        if (Mathf.Abs(pos.y - range) < threshold) goingUp = false;
        else if (Mathf.Abs(pos.y + range) < threshold) goingUp = true;

        transform.localPosition = pos + new Vector3(0, offsetY);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAnimation : MonoBehaviour
{
    public bool animatePosition = true;
    public float range = 1f;
    public float threshold = .01f;
    public float offsetY = .35f;
    public float damping = .3f;
    public bool animateScale = false;
    public float targetScale = 1.2f;

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

        if (animatePosition)
            transform.localPosition = pos + new Vector3(0, offsetY);

        float mapped = GameUtils.Map(pos.y, -range, range, 1, targetScale);

        if (animateScale)
            transform.localScale = Vector3.one * mapped;
    }
}

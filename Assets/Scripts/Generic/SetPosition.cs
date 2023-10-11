using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPosition : MonoBehaviour {
    public float posMulti = 1f;
    public Vector2 posOffset;

    public void SetPos(Vector2 pos) {
        transform.localPosition = (Vector3)(pos * posMulti) + (Vector3)posOffset;
    }
}

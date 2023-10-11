using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtDir : MonoBehaviour {
    Vector2 dir;

    void Update() {
        var rot = Quaternion.LookRotation(Vector3.forward, dir);
        transform.rotation = Quaternion.Euler(0, 0, rot.eulerAngles.z + 90);
    }

    public void SetDir(Vector2 dir) {
        this.dir = dir;
    }
}

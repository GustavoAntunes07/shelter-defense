using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour {
    [SerializeField] float speedMultiplier = 1;

    [Space(8), Header("Events"), Space(8)]
    public FloatEvent OnSpeedChanged;
    [Space(8)]
    public FloatEvent OnSpeedAdded;
    [Space(8)]
    public FloatEvent OnSpeedRemoved;

    void Start() {
        SetMultiplier(speedMultiplier);
    }

    public void SetMultiplier(float multi) {
        speedMultiplier = multi;
        OnSpeedChanged.Invoke(speedMultiplier);
    }

    public void AddMultiplier(float multi) {
        SetMultiplier(speedMultiplier + multi);
        OnSpeedAdded.Invoke(speedMultiplier);
    }

    public void RemoveMultiplier(float multi) {
        SetMultiplier(speedMultiplier - multi);
        OnSpeedRemoved.Invoke(speedMultiplier);
    }

    [ContextMenu("Set to 2x")]
    public void SetTo10x() => SetMultiplier(2);

    [ContextMenu("Set to 1x")]
    public void SetTo1x() => SetMultiplier(1);
}

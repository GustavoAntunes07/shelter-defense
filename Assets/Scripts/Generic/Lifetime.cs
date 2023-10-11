using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Lifetime : MonoBehaviour {
    [Header("Properties"), Space(8)]
    [SerializeField] float lifetime = 5f;
    [SerializeField] bool triggerOnStart = true;

    [Header("Events"), Space(8)]
    public UnityEvent onLifetimeOver;

    float timeLeft = float.NaN;

    void Start() {
        if (triggerOnStart)
            Trigger();
    }

    void Update() {
        if (!float.IsNaN(timeLeft)) {
            timeLeft -= Time.deltaTime;

            if (timeLeft <= 0)
                onLifetimeOver?.Invoke();
        }
    }

    public void Trigger() {
        timeLeft = lifetime;
    }

    public void DestroyItself() => Destroy(gameObject);
}

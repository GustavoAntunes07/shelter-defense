using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ProjectileShooter))]
public class ShooterAi : MonoBehaviour {
    [SerializeField] float shootTime = 5f;
    [SerializeField] float shootDelay = 3f;

    ProjectileShooter shooter;

    void Start() {
        shooter = GetComponent<ProjectileShooter>();
    }

    void Update() {
        if (!shooter.IsAuto()) {

        }
    }
}

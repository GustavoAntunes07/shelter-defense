using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void SetMoveState(bool isMoving)
    {
        anim.SetBool("isMoving", isMoving);
    }

    public void SetGroundedState(bool isGrounded)
    {
        anim.SetBool("isGrounded", isGrounded);
    }
}

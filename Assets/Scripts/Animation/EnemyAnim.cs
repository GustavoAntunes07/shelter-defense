using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAnim : MonoBehaviour
{
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void PlayShootAnimation()
    {
        anim.SetTrigger("shoot");
    }

    public void SetMoveState(bool m)
    {
        anim.SetBool("move", m);
    }

    public void PlaySpawnAnimation() => anim.SetTrigger("spawn");
}

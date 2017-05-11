using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {

    private Animator anim;
    public string playIdle, playAttack;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

   public void PlayIdle()
    {
        anim.SetBool("Idle", true);
        anim.Play(playIdle);
    }

    public void PlayAttack()
    {
        anim.SetBool("Idle", false);
        anim.Play(playAttack);
    }
}

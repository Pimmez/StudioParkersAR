using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {

    //Makes Animator
    private Animator anim;
    [SerializeField]
    private string playWalk, playIdle, playHit;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void PlayAnimationOn()
    {
        anim.SetBool("Idle", false);
        anim.Play(playWalk);
    }

   public void PlayAnimationOff()
    {
        anim.SetBool("Idle", true);
        anim.Play(playIdle);
    }

    public void PlayHit()
    {
        anim.SetBool("Idle", false);
        anim.Play(playHit);
    }
}

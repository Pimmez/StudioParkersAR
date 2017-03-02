using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {

    //Makes Animator
    private Animator anim;
    [SerializeField]
    private string playWalk, playIdle, playHit, playAttack;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void PlayAnimationOn()
    {
        
        anim.Play(playWalk);
        anim.SetBool("Idle", false);
    }

   public void PlayAnimationOff()
    {
        anim.SetBool("Idle", true);
        anim.Play(playIdle);
    }

    public void PlayHit()
    {
     
        anim.Play(playHit);
        anim.SetBool("Idle", false);
    }

    public void PlayAttack()
    {
        anim.Play(playAttack);
        anim.SetBool("Idle", false);
    }
}

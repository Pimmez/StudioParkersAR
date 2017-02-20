using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {

    //Makes Animator
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void PlayAnimationOn()
    {
        anim.SetBool("Idle", false);
        anim.Play("RUN00_F");
    }

   public void PlayAnimationOff()
    {
        anim.SetBool("Idle", true);
        anim.Play("WAIT02");
    }
}

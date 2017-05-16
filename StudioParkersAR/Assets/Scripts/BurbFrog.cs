using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurbFrog : MonoBehaviour {

    private Animator anim;
    private SoundManager sound;
    private LookAtCamera getBool; 

    private void Start()
    {
        getBool = GetComponent<LookAtCamera>();
        sound = FindObjectOfType<SoundManager>();
        anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        EventManager.StartListening("OnBurb", OnBurb);
    }

    private void OnDisable()
    {
        EventManager.StopListening("OnBurb", OnBurb);
    }

    void OnBurb()
    {
        getBool.disableTouch = false;
        EventManager.TriggerEvent("OnFlyDisabled");
        anim.Play("Lick");
        sound.PlayAudio(2);
    }

    void EndLick()
    {
        EventManager.TriggerEvent(SuperUIManager.TO_END_SCENE);
    }
}

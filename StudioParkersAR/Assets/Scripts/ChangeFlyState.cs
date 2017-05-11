using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeFlyState : MonoBehaviour
{
    public GameObject targetFly;
    public Image fly;
    public Image raakImage;
    public bool hitFly;
    private TargetBoundaryMovement move;
    private SoundManager sound;

    private void Start()
    {
        raakImage.enabled = false;
        //fly.enabled = false;
        //targetFly.SetActive(false);
        hitFly = false;
        move = FindObjectOfType<TargetBoundaryMovement>();
        sound = FindObjectOfType<SoundManager>();
    }

    private void OnEnable()
    {
        EventManager.StartListening("OnTrackingLost", OnFlyLost);
    }

    private void OnDisable()
    {
        EventManager.StopListening("OnTrackingLost", OnFlyLost);
    }

    //Sets fly and his target off and the feedback image on
    public void EnableRaakImage()
    {
        fly.enabled = false;
        targetFly.SetActive(false);
        hitFly = true;
        raakImage.rectTransform.position = fly.rectTransform.position;
        sound.PlayAudio(0);
        EventManager.TriggerEvent("ScoreHit");
    }
    
    //Sets fly and his target on and the feedback image off
    public void EnableFly()
    {
        fly.enabled = true;
        targetFly.SetActive(true);
        raakImage.enabled = false;
        hitFly = false;
        //move.negativeMovement -= 0.5f;
        //move.positiveMovement += 0.5f;
    }

    void OnFlyLost() //Disables Fly, Targetfly and hitfly when Tracking is Lost
    {
        fly.enabled = false;
        targetFly.SetActive(false);
        hitFly = false;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeFlyState : MonoBehaviour
{
    [Space(10)]
    [Tooltip("The target that the fly follows.")]
    public GameObject targetFly;

    [Space(10)]
    [Tooltip("The image of the fly.")]
    public Image fly;
    [Tooltip("The image of the raakImage(HitImage).")]
    public Image raakImage;

    [Space(10)]
    [Tooltip("A boolean that indicates of the fly is hit or not.")]
    public bool hitFly;

    private SoundManager sound;

    private void Start()
    {
        raakImage.enabled = false;
        hitFly = false;
        sound = FindObjectOfType<SoundManager>();
    }

    private void OnEnable()
    {
        EventManager.StartListening("OnTrackingLost", OnFlyLost);
        EventManager.StartListening("OnFlyDisabled", OnFlyLost);
        EventManager.StartListening("EnableFly", EnableFly);
    }

    private void OnDisable()
    {
        EventManager.StopListening("OnTrackingLost", OnFlyLost);
        EventManager.StopListening("OnFlyDisabled", OnFlyLost);
        EventManager.StopListening("EnableFly", EnableFly);
    }

    //Sets fly and his target off and the feedback image on
    public void EnableRaakImage()
    {
        fly.enabled = false;
        hitFly = true;
        raakImage.rectTransform.position = fly.rectTransform.position;
        sound.PlayAudio(0);
        EventManager.TriggerEvent("ScoreHit");
    }
    
    //Sets fly and his target on and the feedback image off
    public void EnableFly()
    {
        hitFly = false;
        raakImage.enabled = false;
        fly.enabled = true;
        EventManager.TriggerEvent("SpeedUp");
    }

    void OnFlyLost() //Disables Fly, Targetfly and hitfly when Tracking is Lost
    {
        fly.enabled = false;
        targetFly.SetActive(false);
        hitFly = false;
    }

}

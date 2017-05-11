using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.UI;

public class CheckTracking : MonoBehaviour{

    private TrackableBehaviour mTrackableBehaviour;
    private bool flyStatus = false;
    public GameObject fly, flyTarget, TooFarText, startExperience, Score;

    private SoundManager sound;
    private ChangeFlyState flystate;

    void Start()
    {
        VuforiaBehaviour.Instance.enabled = false;
        flystate = FindObjectOfType<ChangeFlyState>();
        Score.SetActive(false);
        sound = FindObjectOfType<SoundManager>();
    }

    private void OnEnable()
    {
        EventManager.StartListening("CheckFlyEvent", CheckFlyEvent);
        EventManager.StartListening("OnTrackingFound", OnTrackingFound);
        EventManager.StartListening("OnTrackingLost", OnTrackingLost);

    }

    private void OnDisable()
    {
        EventManager.StopListening("CheckFlyEvent", CheckFlyEvent);
        EventManager.StopListening("OnTrackingFound", OnTrackingFound);
        EventManager.StopListening("OnTrackingLost", OnTrackingLost);

    }

    void CheckFlyEvent()
    {
        if (startExperience.activeSelf == false)
        {
            VuforiaBehaviour.Instance.enabled = true;           
        }
    }

    void OnTrackingFound()
    {
        //Log.instance.LogFiles("OnTrackingFound");
        flyStatus = true;
        Score.SetActive(true);
        CheckFly();
        EventManager.TriggerEvent("TimerTrue");
    }

    void OnTrackingLost()
    {
        //Log.instance.LogFiles("OnTrackingLost");
        flyStatus = false;
        Score.SetActive(false);
        EventManager.TriggerEvent("TimerFalse");
    }

    void CheckFly()
    {
        //Log.instance.LogFiles("flystatus :: " + flyStatus);
        if (flyStatus)
        {
            flystate.fly.enabled = true;
            flystate.targetFly.SetActive(true);
            TooFarText.SetActive(true);
        }
    }
}

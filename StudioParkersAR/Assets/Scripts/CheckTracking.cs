using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.UI;

public class CheckTracking : MonoBehaviour{

    private TrackableBehaviour mTrackableBehaviour;
    private bool flyStatus = false;
    private ChangeFlyState flystate;

    [Space(10)]

    [Tooltip("The fly that is drawn on the canvas")]
    public GameObject fly;

    [Tooltip("The target that the fly follows")]
    public GameObject flyTarget;

    [Tooltip("StartExperiencePanel")]
    public GameObject startExperience;

    [Tooltip("Score / Counter")]
    public GameObject Score;


    void Start()
    {
        VuforiaBehaviour.Instance.enabled = false;
        flystate = FindObjectOfType<ChangeFlyState>();
        Score.SetActive(false);
    }

    private void OnEnable()
    {
        EventManager.StartListening("CheckFlyEvent", CheckFlyEvent);
        EventManager.StartListening("OnTrackingFound", OnTrackingFound);
        EventManager.StartListening("OnTrackingLost", OnTrackingLost);
        EventManager.StartListening("StartTheGame", StartTheGame);
    }

    private void OnDisable()
    {
        EventManager.StopListening("CheckFlyEvent", CheckFlyEvent);
        EventManager.StopListening("OnTrackingFound", OnTrackingFound);
        EventManager.StopListening("OnTrackingLost", OnTrackingLost);
        EventManager.StopListening("StartTheGame", StartTheGame);
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
        EventManager.TriggerEvent("TimerTrue");
    }

    void OnTrackingLost()
    {
        flyStatus = false;
        Score.SetActive(false);
        EventManager.TriggerEvent("TimerFalse");
    }

    void StartTheGame()
    {
        flyStatus = true;
        Score.SetActive(true);
        CheckFly();
    }

    void CheckFly()
    {
        if (flyStatus)
        {
            flystate.fly.enabled = true;
            flystate.targetFly.SetActive(true);
        }
    }
}

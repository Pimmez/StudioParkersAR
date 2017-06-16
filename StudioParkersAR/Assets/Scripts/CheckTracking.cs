using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.UI;

public class CheckTracking : MonoBehaviour{

    private ChangeFlyState flystate;
    private bool gameIsStarted = false;
    [Space(10)]

    [Tooltip("The fly that is drawn on the canvas")]
    public GameObject fly;

    [Tooltip("The target that the fly follows")]
    public GameObject flyTarget;

    [Tooltip("StartExperiencePanel")]
    public GameObject uiPanelStartExperience;

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
        EventManager.StartListening("StartTimerOneAndVuforia", ActivateVuforia);
        EventManager.StartListening("OnTrackingFound", OnTrackingFound);
        EventManager.StartListening("OnTrackingLost", OnTrackingLost);
        EventManager.StartListening("StartTheGame", StartTheGame);
    }

    private void OnDisable()
    {
        EventManager.StopListening("StartTimerOneAndVuforia", ActivateVuforia);
        EventManager.StopListening("OnTrackingFound", OnTrackingFound);
        EventManager.StopListening("OnTrackingLost", OnTrackingLost);
        EventManager.StopListening("StartTheGame", StartTheGame);
    }

    void ActivateVuforia()
    {
        if (uiPanelStartExperience.activeSelf == false)
        {
            VuforiaBehaviour.Instance.enabled = true;
        }
    }

    void OnTrackingFound()
    {
        print("***OnTrackingFound***");
        if( gameIsStarted )
        {
            startFlyAndScore( true );
            EventManager.TriggerEvent("TimerTrue");
        }
        
    }

    void OnTrackingLost()
    {
        if (gameIsStarted)
        {
            startFlyAndScore(false);
            EventManager.TriggerEvent("TimerFalse");
        }
    }

    void StartTheGame()
    {
        startFlyAndScore( true );
        gameIsStarted = true;
    }

    void startFlyAndScore( bool p_bool)
    {
        print("***startFlyAndScore***: " + p_bool);
        Score.SetActive(p_bool);
        flystate.fly.enabled = p_bool;
        flystate.targetFly.SetActive(p_bool);
    }
}

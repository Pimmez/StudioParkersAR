using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    [SerializeField] private Text timerText;

    [SerializeField] private float timerCounter;
    public bool isTiming;

    private SoundManager sound;
    private AudioSource audio;

    private void Start()
    {
        audio = FindObjectOfType<AudioSource>();
        sound = FindObjectOfType<SoundManager>();
    }

    private void OnEnable()
    {
        EventManager.StartListening("TimerTrue", TimerTrue);
        EventManager.StartListening("TimerFalse", TimerFalse);
    }

    private void OnDisable()
    {
        EventManager.StopListening("TimerTrue", TimerTrue);
        EventManager.StopListening("TimerFalse", TimerFalse);
    }

    void Update()
    {
        if(isTiming)
        {
            CountTimer();
        }
    }

    void SetTimer(bool p_isTiming)
    {
        isTiming = p_isTiming;
    }

    void TimerTrue()
    {
        SetTimer(true);
    }

    void TimerFalse()
    {
        SetTimer(false);
    }

    void CountTimer()
    {
        timerCounter -= Time.deltaTime;

        float min = Mathf.Floor(timerCounter / 60);

        float sec = timerCounter % 60;

        timerText.text = string.Format("Timer: {0:0} : {1:00}", min, sec);

        if (!audio.isPlaying)
        {
            sound.PlayAudioIfNotPlaying(1);
            //sound.PlayAudio(1);
        }

        if (timerCounter <= 0)
        {
            Destroy(timerText);
            isTiming = false;
            EventManager.TriggerEvent(SuperUIManager.TO_END_SCENE);
        }
    } 
}

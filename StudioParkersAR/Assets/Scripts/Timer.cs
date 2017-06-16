using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    [Tooltip("timer1Text || timer2Text :: indicates which timer goes where and both need to be a Text component.")]
    [SerializeField] private Text timer1Text, timer2Text;

    [Space(10)]
    [Tooltip("TimerBalk :: The Green Image Shown In The Top Of The Screen.")]
    [SerializeField] private RectTransform timerBalk;

    [Space(10)]
    [Tooltip("timer1Text :: indicates the countdown time for timer1Text.")]
    [SerializeField] private float timer1Value;

    [Tooltip("timer2Text :: indicates the countdown time for timer2Text.")]
    [SerializeField] private float timer2Value;

    [Tooltip("SmoothTime :: The Lower The Float The Smoother It Will Be.")]
    [SerializeField] private float smoothTime = 1f;
      
    private Text gameTimerText;
    private float timerValue;
    private bool isTiming = false;
    private bool isTimerOne = true;
    private bool isTimerTwo = false;
    private SoundManager sound;
    private AudioSource audio;
    private float velocity;

    private void Start()
    {
        sound = FindObjectOfType<SoundManager>();
        audio = FindObjectOfType<AudioSource>();
        timerValue = timer1Value;
        gameTimerText = timer1Text;
        timerBalk.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        EventManager.StartListening("StartTimerOneAndVuforia", TimerTrue);
        EventManager.StartListening("TimerTrue", TimerTrue);
        EventManager.StartListening("TimerFalse", TimerFalse);
    }

    private void OnDisable()
    {
        EventManager.StopListening("StartTimerOneAndVuforia", TimerTrue);
        EventManager.StopListening("TimerTrue", TimerTrue);
        EventManager.StopListening("TimerFalse", TimerFalse);
    }

    void Update()
    {
        print("timer update " + isTiming );
        if (isTiming)
        {
            TimerValue();
            ChangeTimerImage();
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

    float TimerValue()
    {
        timerValue -= Time.deltaTime;

        float min = Mathf.Floor(timerValue / 60);

        float sec = timerValue % 60;

        gameTimerText.text = string.Format("{1:0}", min, sec);


        if (timerValue <= 0 && isTimerOne)
        {
            Destroy(timer1Text);
            isTimerTwo = true;
            timerValue = timer2Value;
            gameTimerText = timer2Text;
            EventManager.TriggerEvent("StartTheGame");
            timerBalk.gameObject.SetActive(true);
            isTimerOne = false;
            if (!audio.isPlaying)
            {
                sound.PlayAudioIfNotPlaying(1);
            }
        }
        else if (timerValue <= 0 && isTimerTwo)
        {
            Destroy(timer2Text);
            isTiming = false;
            EventManager.TriggerEvent("OnBurb");
        }

        return timerValue;
    }

    void ChangeTimerImage()
    {
        float newX = Mathf.SmoothDamp(timerBalk.localScale.x, (timerValue + 1) / (timer2Value + 3), ref velocity, smoothTime);
        timerBalk.localScale = new Vector3(newX, timerBalk.localScale.y, timerBalk.localScale.z);
    }
}

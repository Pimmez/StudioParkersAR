using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Vuforia;
using UnityEngine;
using UnityEngine.Events;


public class SuperUIManager : MonoBehaviour
{
    public const string START_EXPERIENCE = "StartExperience";
    public const string WEBSITE = "Website";
    public const string RETURN_MENU = "ReturnToMenu";
    public const string TO_GAME = "ToGame";
    public const string TO_END_SCENE = "ToEndScene";
    public const string PEEK_EXPERIENCE = "StartPeekExperience";
    public const string TO_PEEK = "PeekScene";

    private bool loadScene;
    private GameObject StartExperiencePanel;
    private Animator anim;

    private void Start()
    {
        StartExperiencePanel = GameObject.Find("StartExperiencePanel");
        anim = FindObjectOfType<Animator>();
    }

    private void OnEnable()
    {
        EventManager.StartListening(START_EXPERIENCE, StartExperience);
        EventManager.StartListening(WEBSITE, OpenURL);
        EventManager.StartListening(RETURN_MENU, ReturnToMenu);
        EventManager.StartListening(TO_GAME, ToGame);
        EventManager.StartListening(TO_END_SCENE, ToEndScene);
        EventManager.StartListening(PEEK_EXPERIENCE, PeekExperience);
        EventManager.StartListening(TO_PEEK, ToPeekScene);
    }

    private void OnDisable()
    {
        EventManager.StopListening(START_EXPERIENCE, StartExperience);
        EventManager.StopListening(WEBSITE, OpenURL);
        EventManager.StopListening(RETURN_MENU, ReturnToMenu);
        EventManager.StopListening(TO_GAME, ToGame);
        EventManager.StopListening(TO_END_SCENE, ToEndScene);
        EventManager.StopListening(PEEK_EXPERIENCE, PeekExperience);
        EventManager.StopListening(TO_PEEK, ToPeekScene);
    }

    // Updates once per frame
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android && Input.GetKeyDown(KeyCode.Escape))
        {
            BackToMainMenu();
        }
    }

    //Vuforia Scene
    void StartExperience()
    {
        StartExperiencePanel.SetActive(false);
        EventManager.TriggerEvent("StartTimerOneAndVuforia");
    }

    void PeekExperience()
    {
        StartExperiencePanel.SetActive(false);
    }

    //IntroParkers Scene
    void ToGame()
    {
        if (loadScene == false)
        {
            loadScene = true;
            anim.SetBool("IsPressed", true);
            anim.Play("ButtonToGame");
            PlayerPrefs.DeleteKey("TotalScore");
            StartCoroutine(FadeLevelIn());
            StartCoroutine(LoadNewScene());

        }
    }

    //Vuforia Scene
    void ReturnToMenu()
    {
        PlayerPrefs.DeleteKey("TotalScore");
        StartCoroutine(FadeLevelIn());
        SceneManager.LoadScene("IntroParkers");
    }

    //IntroParkers Scene
    void OpenURL()
    {

#if UNITY_EDITOR
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            StartCoroutine(FadeLevelIn());
            SceneManager.LoadScene("WhoAreParkers");
        }
        else
        {
            Application.OpenURL("http://studioparkers.nl");
        }

#elif (UNITY_ANDROID || UNITY_IOS || UNITY_WP8)
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            SceneManager.LoadScene("WhoAreParkers");
        }
        else
        {
            Application.OpenURL("http://studioparkers.nl");
        }
#endif
    }

    IEnumerator LoadNewScene()
    {
        // This line waits for 3 seconds before executing the next line in the coroutine.
        yield return new WaitForSeconds(1);

        // Start an asynchronous operation to load the scene that was passed to the LoadNewScene coroutine.
        AsyncOperation aSync = SceneManager.LoadSceneAsync("ParkersAugmented");
        // While the asynchronous operation to load the new scene is not yet complete, continue waiting until it's done.
        while (!aSync.isDone)
        {
            yield return null;
        }

    }

    void ToPeekScene()
    {
        print("ToPeekScene");
        if (loadScene == false)
        {
            loadScene = true;
            anim.SetBool("IsPeeked", true);
            anim.Play("ButtonToPeek");
            PlayerPrefs.DeleteKey("TotalScore");
            StartCoroutine(FadeLevelIn());
            SceneManager.LoadScene("PeekScene");

        }
    }

    void ToEndScene()
    {
        StartCoroutine(FadeLevelIn());
        SceneManager.LoadScene("EndScene");
    }


    //All Scenes
    void BackToMainMenu()
    {
        if (SceneManager.GetActiveScene().name != "IntroParkers")
        {
            SceneManager.LoadScene("IntroParkers");
        }
        else
        {
            //Stops The Game
            Application.Quit();
        }
    }


    IEnumerator FadeLevelIn()
    {
        float fadeTime = GameObject.Find("Fade").GetComponent<Fade>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
    }

}

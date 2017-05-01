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


    private bool loadScene;
    [SerializeField] private Text loadingText;
    private GameObject loading, StartExperiencePanel;

    private void Start()
    {
        StartExperiencePanel = GameObject.Find("StartExperiencePanel");
        loadingText.enabled = false;
    }

    private void OnEnable()
    {
        EventManager.StartListening(START_EXPERIENCE, StartExperience);
        EventManager.StartListening(WEBSITE, OpenURL);
        EventManager.StartListening(RETURN_MENU, ReturnToMenu);
        EventManager.StartListening(TO_GAME, ToGame);
    }

    private void OnDisable()
    {
        EventManager.StopListening(START_EXPERIENCE, StartExperience);
        EventManager.StopListening(WEBSITE, OpenURL);
        EventManager.StopListening(RETURN_MENU, ReturnToMenu);
        EventManager.StopListening(TO_GAME, ToGame);
    }

    // Updates once per frame
    void Update()
    {
        // If the new scene has started loading...
        if (loadScene == true)
        {
            // ...then pulse the transparency of the loading text to let the player know that the computer is still working.
            loadingText.color = new Color(loadingText.color.r, loadingText.color.g, loadingText.color.b, Mathf.PingPong(Time.time, 1));
        }

        Quit("IntroParkers", "ParkersAugmented", "WhoAreParkers");

    }

    //Vuforia Scene
    void StartExperience()
    {   
        Destroy(StartExperiencePanel);
    }

    //IntroParkers Scene
    void ToGame()
    {
        if (loadScene == false)
        {
            loadingText.enabled = true;

            // ...set the loadScene boolean to true to prevent loading a new scene more than once...
            loadScene = true;

            // ...change the instruction text to read "Loading..."
            loadingText.text = "Loading...";

            // ...and start a coroutine that will load the desired scene.
            StartCoroutine(LoadNewScene());
        }
    }

    //Vuforia Scene
    void ReturnToMenu()
    {
        SceneManager.LoadScene("IntroParkers");
    }

    //IntroParkers Scene
    void OpenURL()
    {

#if UNITY_EDITOR
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            SceneManager.LoadScene("WhoAreParkers");
        }
        else
        {
            Application.OpenURL("https://studioparkers.nl");
        }

#elif (UNITY_ANDROID || UNITY_IOS || UNITY_WP8)
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            SceneManager.LoadScene(moreInfo);
        }
        else
        {
            Application.OpenURL("https://studioparkers.nl");
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

    //All Scenes
    void Quit(string mainMenu, string gameName, string moreInfo)
    {
        if (Application.platform == RuntimePlatform.Android && Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().name == gameName)
            {
                SceneManager.LoadScene(mainMenu);
            }
            else if (SceneManager.GetActiveScene().name == moreInfo)
            {
                SceneManager.LoadScene(mainMenu);
            }
            else
            {
                //Stops The Game
                Application.Quit();
            }

        }
    }

}

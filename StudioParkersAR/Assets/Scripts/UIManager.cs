using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Vuforia;
using UnityEngine;


public class UIManager : MonoBehaviour {

    private bool loadScene;
    [SerializeField] private Text loadingText;
    private GameObject buttonUrl, buttonGame, loading;

    private void Start()
    {
        buttonUrl = GameObject.Find("ButtonToSite");
        buttonGame = GameObject.Find("ButtonToGame");
        loadingText.enabled = false;

        // Create a temporary reference to the current scene.
        Scene currentScene = SceneManager.GetActiveScene();

            // Retrieve the index of the scene in the project's build settings.
            int buildIndex = currentScene.buildIndex;

            // Check the scene name as a conditional.
            switch (buildIndex)
            {
                default:
                    buttonGame.SetActive(false);
                    buttonUrl.SetActive(false);
                    loadingText.enabled = false;
                break;
                case 0:
                    buttonGame.SetActive(true);
                    buttonUrl.SetActive(true);
                    break;
                case 1:
                    break;
            }
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
    public void GoFurther(GameObject furtherPanel)
    {
        Destroy(furtherPanel);
    }

    //IntroParkers Scene
    public void ToGame(string gameName)
    {
        if (loadScene == false)
        {
            loadingText.enabled = true;

            // ...set the loadScene boolean to true to prevent loading a new scene more than once...
            loadScene = true;

            // ...change the instruction text to read "Loading..."
            loadingText.text = "Loading...";

            // ...and start a coroutine that will load the desired scene.
            StartCoroutine(LoadNewScene(gameName));
        }
    }

    //Vuforia Scene
    public void ReturnToMenu(string mainMenu)
    {
        SceneManager.LoadScene(mainMenu);
    }

    //IntroParkers Scene
    public void OpenURL(string moreInfo)
    {

        #if UNITY_EDITOR
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            SceneManager.LoadScene(moreInfo);
        }
        else
        {
            Application.OpenURL("https://www.studioparkers.nl");
        }

#elif (UNITY_ANDROID || UNITY_IOS || UNITY_WP8)
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            SceneManager.LoadScene(moreInfo);
        }
        else
        {
            Application.OpenURL("https://www.studioparkers.nl");
        }
#endif
    }

    IEnumerator LoadNewScene(string gameName)
    {
        // This line waits for 3 seconds before executing the next line in the coroutine.
        yield return new WaitForSeconds(1);

        // Start an asynchronous operation to load the scene that was passed to the LoadNewScene coroutine.
        AsyncOperation aSync = SceneManager.LoadSceneAsync(gameName);

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
            else if(SceneManager.GetActiveScene().name == moreInfo)
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

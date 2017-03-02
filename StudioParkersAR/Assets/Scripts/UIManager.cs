using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Vuforia;
using UnityEngine;


public class UIManager : MonoBehaviour {

    [SerializeField] private string gameName, mainMenu, parkersName;

    private bool loadScene = false;

    [SerializeField]
    GameObject buttonGame, buttonUrl, furtherPanel;

    [SerializeField]
    private Text loadingText;

    private void Start()
    {
        buttonGame.SetActive(true);
        buttonUrl.SetActive(true);
        loadingText.enabled = false;
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

        Quit();

    }

    //Vuforia Scene
    public void GoFurther()
    {
        Destroy(furtherPanel);
    }

    //IntroParkers Scene
    public void ToGame()
    {
        if (loadScene == false)
        {
            Destroy(buttonGame);
            Destroy(buttonUrl);
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
    public void ReturnToMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }

    //IntroParkers Scene
    public void OpenURL()
    {

        #if UNITY_EDITOR
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            SceneManager.LoadScene(parkersName);
        }
        else
        {
            Application.OpenURL("https://www.studioparkers.nl");
        }

        #elif (UNITY_ANDROID || UNITY_IOS || UNITY_WP8)
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            SceneManager.LoadScene(parkersName);
        }
        else
        {
            Application.OpenURL("https://www.studioparkers.nl");
        }
        #endif
    }

    IEnumerator LoadNewScene()
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
    void Quit()
    {
        if (Application.platform == RuntimePlatform.Android && Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().name == gameName)
            {
                SceneManager.LoadScene(mainMenu);
            }
            else if(SceneManager.GetActiveScene().name == parkersName)
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

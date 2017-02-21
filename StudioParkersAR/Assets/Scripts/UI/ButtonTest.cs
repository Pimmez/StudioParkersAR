using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class ButtonTest : MonoBehaviour {

    [SerializeField] private string gameName, mainMenu;

    private bool loadScene = false;
    [SerializeField]
    GameObject buttonGame, buttonUrl, mainText;

    [SerializeField]
    private Text loadingText;

    private void Start()
    {
        buttonGame.SetActive(true);
        mainText.SetActive(true);
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

    }

    public void ToGame()
    {
        if (loadScene == false)
        {
            buttonGame.SetActive(false);
            mainText.SetActive(false);
            buttonUrl.SetActive(false);
            loadingText.enabled = true;

            // ...set the loadScene boolean to true to prevent loading a new scene more than once...
            loadScene = true;

            // ...change the instruction text to read "Loading..."
            loadingText.text = "Loading...";

            // ...and start a coroutine that will load the desired scene.
            StartCoroutine(LoadNewScene());
        }
    }

    public void ReturnToMenu()
    {
        if(Application.platform == RuntimePlatform.Android)
            { 

                SceneManager.LoadScene(mainMenu);
            }
            
    }

    public void OpenURL()
    {
        #if UNITY_EDITOR
            Application.OpenURL("https://www.studioparkers.nl");
        #elif (UNITY_ANDROID || UNITY_IPHONE || UNITY_WP8)
            Application.OpenURL("https://www.studioparkers.nl");
        #endif
    }

    public void QuitGame()
    {
        //Stops The Game
        Application.Quit();
    }

    IEnumerator LoadNewScene()
    {
        // This line waits for 3 seconds before executing the next line in the coroutine.
        yield return new WaitForSeconds(3);

        // Start an asynchronous operation to load the scene that was passed to the LoadNewScene coroutine.
        AsyncOperation aSync = SceneManager.LoadSceneAsync(gameName);

        // While the asynchronous operation to load the new scene is not yet complete, continue waiting until it's done.
        while (!aSync.isDone)
        {
            yield return null;
        }

    }

}

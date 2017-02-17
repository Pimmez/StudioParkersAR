using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class ButtonTest : MonoBehaviour {

    [SerializeField] private string gameName, mainMenu;

    public void ToGame()
    {
        SceneManager.LoadScene(gameName);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }

    public void OpenURL()
    {
        #if UNITY_EDITOR
            Application.OpenURL("www.studioparkers.nl");
        #elif (UNITY_ANDROID || UNITY_IPHONE || UNITY_WP8)
            Application.OpenURL("www.studioparkers.nl");
        #endif
    }

    public void QuitGame()
    {
        //Stops The Game
        Application.Quit();
    }


}

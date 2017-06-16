using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour {

    public Texture2D fadeOutTexture;
    public float fadeSpeed = 0.3f;

    private int drawDepth = -1000;
    private float alpha = 1.0f;
    private int fadeDirection = -1; //1 is fade in || -1 is fade out

    private void OnGUI()
    {
       alpha += fadeDirection * fadeSpeed * Time.deltaTime;
       alpha = Mathf.Clamp01(alpha); //clamp01 clamp between 0 and 1

        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
    }

    public float BeginFade(int direction)
    {
        fadeDirection = direction;
        return (fadeSpeed);
    }


	void OnEnable()
	{
		SceneManager.sceneLoaded += LevelLoaded;
	}

	void OnDisable()
	{
		SceneManager.sceneLoaded -= LevelLoaded;
	}

	private void LevelLoaded(Scene scene, LoadSceneMode mode)
    {
        BeginFade(-1);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebCamTest : MonoBehaviour {
    /*
    IEnumerator Start()
    {
        yield return Application.RequestUserAuthorization(UserAuthorization.WebCam | UserAuthorization.Microphone);
        if (Application.HasUserAuthorization(UserAuthorization.WebCam | UserAuthorization.Microphone))
        {
            Debug.Log("Works");
            AccesCompleted();
        }
        else
        {
            Debug.Log("FAILED");
        }
    }
    */

    void Start()
    {
        WebCamDevice[] devices = WebCamTexture.devices;
        WebCamTexture webCamTexture = new WebCamTexture();
        Debug.Log("Webcam loading?");

        if (devices.Length > 0)
        {
            webCamTexture.deviceName = devices[0].name;
            Debug.Log("Webcam Plays");
            webCamTexture.Play();
           
        }
    }

    /*
    void AccesCompleted()
    {
        WebCamTexture webCamTexture = new WebCamTexture();
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = webCamTexture;
        Debug.Log("Time to check name");
        CheckName();

    }
    */
}

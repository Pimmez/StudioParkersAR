using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccesCam : MonoBehaviour {

    IEnumerator Start()
    {
        yield return Application.RequestUserAuthorization(UserAuthorization.WebCam | UserAuthorization.Microphone);
            if (Application.HasUserAuthorization(UserAuthorization.WebCam | UserAuthorization.Microphone))
            {
                
            }
            else
            {
                
            }
    }
}

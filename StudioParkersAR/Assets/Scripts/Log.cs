using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Log : MonoBehaviour {

    public Text text;

    private static Log logger; //Made an instance of it what's static

    public static Log instance //We have a getter what we call instance
    {
        get
        {
            if (!logger)//if we dont have a eventManager
            {
                logger = FindObjectOfType(typeof(Log)) as Log; //Find EventManager
                if (!logger) //if we still don't have a eventManager
                {
                    //Show An Error
                    Debug.LogError("there needs to be one active Logger script on a Gameobject in your scene");
                }
                else //if we found it lets initaliaze it
                {
                    logger.LogFiles("start");
                }
            }
            return logger;
        }
    }

    public void LogFiles(string info)
    {
        text.text += info + "\n";
    }

}

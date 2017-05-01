using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTriggerTest : MonoBehaviour {


	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Q))
        {
            EventManager.TriggerEvent("OtherFunction");
        }
        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || (Input.GetMouseButtonDown(0)))
        {
            EventManager.TriggerEvent("SomeFunction");
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            EventManager.TriggerEvent("Spawn");
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            EventManager.TriggerEvent("Destroy");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            EventManager.TriggerEvent("UIImage");
        }


    }
}

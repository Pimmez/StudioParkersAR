using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

    private void OnEnable()
    {
        EventManager.StartListening("Destroy", DestroyObject);
    }

    private void OnDisable()
    {
        EventManager.StopListening("Destroy", DestroyObject);
    }

    void DestroyObject()
    {
        EventManager.StopListening("Destroy", DestroyObject);
        Destroy(this.gameObject);
        Debug.Log("Destroyed!");
    }
}

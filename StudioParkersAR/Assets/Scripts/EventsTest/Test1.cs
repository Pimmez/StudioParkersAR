using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Test1 : MonoBehaviour {

    /*
    private UnityAction someListener;

    private void Awake()
    {
        someListener = new UnityAction(SomeFunction);
    }
    */

    private void OnEnable()
    {
        EventManager.StartListening("SomeFunction", SomeFunction); //someListener
        EventManager.StartListening("OtherFunction", SomeOtherFunction);
    }

    private void OnDisable()
    {
        EventManager.StopListening("SomeFunction", SomeFunction); //someListener
        EventManager.StopListening("OtherFunction", SomeOtherFunction);
    }

    void SomeFunction()
    {
        Debug.Log("SomeFunction was called Yeah!");
    }

    void SomeOtherFunction()
    {
        Debug.Log("Some Other Function was called Wow!");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour {

    private Dictionary<string, UnityEvent> eventDictionary; //A SingleDictionary

    private static EventManager eventManager; //Made an instance of it what's static

    public static EventManager instance //We have a getter what we call instance
    {
        get
        {
            if(!eventManager)//if we dont have a eventManager
            {
                eventManager = FindObjectOfType(typeof(EventManager)) as EventManager; //Find EventManager
                if(!eventManager) //if we still don't have a eventManager
                {
                    //Show An Error
                    Debug.LogError("there needs to be one active EventManager script on a Gameobject in your scene");
                }
                else //if we found it lets initaliaze it
                {
                    eventManager.Init();
                }
            }
            return eventManager;
        }
    }

    void Init()
    {
        if(eventDictionary == null) //if our dictionary is NULL lets create a new dictionary
        {
            eventDictionary = new Dictionary<string, UnityEvent>();
        }
    }

    public static void StartListening(string eventName, UnityAction listener) //we take an event and an action
    {
        UnityEvent thisEvent = null;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.AddListener(listener); //add event and stick it to the dictionary
        }
        else //or we create a new entry
        {
            thisEvent = new UnityEvent(); 
            thisEvent.AddListener(listener);
            instance.eventDictionary.Add(eventName, thisEvent);
        }
    }

    public static void StopListening(string eventName, UnityAction listener)
    {
        if(eventManager == null)
        {
            return;
        }
        UnityEvent thisEvent = null;
        // we find the entry of it exists and we remove it
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }

    public static void TriggerEvent(string eventName) //we go to the entry in the key value pair and invoke it
    {
        UnityEvent thisEvent = null;
        if(instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.Invoke();
        }
    }

}

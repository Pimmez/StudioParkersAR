using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WebsiteEvent : MonoBehaviour {

    [SerializeField] private Button button;

    private void Start()
    {
        button.onClick.AddListener(Website);
    }

    void Website()
    {
        EventManager.TriggerEvent(SuperUIManager.WEBSITE);
    }
}

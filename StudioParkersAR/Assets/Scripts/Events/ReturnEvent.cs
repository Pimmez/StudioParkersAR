using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReturnEvent : MonoBehaviour {

    [SerializeField] private Button button;

    private void Start()
    {
        button.onClick.AddListener(ReturnToMenu);
    }

    void ReturnToMenu()
    {
        EventManager.TriggerEvent(SuperUIManager.RETURN_MENU);
    }
}

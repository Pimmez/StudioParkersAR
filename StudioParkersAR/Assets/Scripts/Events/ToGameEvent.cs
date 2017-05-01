using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToGameEvent : MonoBehaviour {

    [SerializeField] private Button button;

    private void Start()
    {
        button.onClick.AddListener(ToGame);
    }

    void ToGame()
    {
        EventManager.TriggerEvent(SuperUIManager.TO_GAME);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToPeekEvent : MonoBehaviour {

    [SerializeField] private Button button;

    private void Start()
    {
        button.onClick.AddListener(ToPeek);
    }

    void ToPeek()
    {
        EventManager.TriggerEvent(SuperUIManager.TO_PEEK);
    }
}

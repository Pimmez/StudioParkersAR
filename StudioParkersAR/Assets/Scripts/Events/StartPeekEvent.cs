using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPeekEvent : MonoBehaviour {

    [SerializeField] private Button button;

    private void Start()
    {
        button.onClick.AddListener(PeekExperience);
    }

    void PeekExperience()
    {
        EventManager.TriggerEvent(SuperUIManager.PEEK_EXPERIENCE);
    }
}

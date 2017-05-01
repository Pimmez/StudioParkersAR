using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartExperienceEvent : MonoBehaviour {

    [SerializeField] private Button button;

    private void Start()
    {
        button.onClick.AddListener(StartExperience);
    }

    void StartExperience()
    {
        EventManager.TriggerEvent(SuperUIManager.START_EXPERIENCE);
    }
}

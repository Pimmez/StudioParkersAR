using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveHighScoreEvent : MonoBehaviour {

    [SerializeField]
    private Button button;

    private void Start()
    {
        button.onClick.AddListener(SaveScore);
    }

    void SaveScore()
    {
        EventManager.TriggerEvent("PublishScore");
    }
}

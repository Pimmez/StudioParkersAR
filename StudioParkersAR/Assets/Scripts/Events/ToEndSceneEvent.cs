using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToEndSceneEvent : MonoBehaviour {

    [SerializeField]
    private Button button;

    private void Start()
    {
        button.onClick.AddListener(ToEndScene);
    }

    void ToEndScene()
    {
        EventManager.TriggerEvent(SuperUIManager.TO_END_SCENE);
    }
}

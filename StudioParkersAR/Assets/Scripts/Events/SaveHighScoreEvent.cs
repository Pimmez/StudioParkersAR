using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveHighScoreEvent : MonoBehaviour
{

    [SerializeField]
    private Button button;
    private Image image;
    [SerializeField]
    private Sprite saved;
    private HighScore highScore;
    private RectTransform rectTransform;
    public Outline outlineAchter, outlineVoor;


    private void Awake()
    {
        image = gameObject.GetComponent<Image>();
        rectTransform = gameObject.GetComponent<RectTransform>();
        highScore = FindObjectOfType<HighScore>();
        button.onClick.AddListener(SaveScore);

        outlineAchter.enabled = false;
        outlineVoor.enabled = false;
    }

    void SaveScore()
    {
        if (!string.IsNullOrEmpty(highScore.voornaam.text) && !string.IsNullOrEmpty(highScore.achternaam.text))
        {
            button.onClick.RemoveListener(SaveScore);
            image.sprite = saved;
            rectTransform.sizeDelta = new Vector2(127, 59);
            outlineAchter.enabled = false;
            outlineVoor.enabled = false;
            EventManager.TriggerEvent("PublishScore");
        }
        if (string.IsNullOrEmpty(highScore.voornaam.text) && string.IsNullOrEmpty(highScore.achternaam.text))
        {
            outlineVoor.enabled = true;
            outlineAchter.enabled = true;

        }
        else if (string.IsNullOrEmpty(highScore.voornaam.text))
        {
            outlineVoor.enabled = true;
        }
        else if (string.IsNullOrEmpty(highScore.achternaam.text))
        {
            outlineAchter.enabled = true;
        }
        else
        {
            outlineAchter.enabled = false;
            outlineVoor.enabled = false;
        }
    }
}

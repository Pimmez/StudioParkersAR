using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    [SerializeField] private Text scoreText;
    private int amountHit, totalScore;

    // Use this for initialization
    void Start () {
        amountHit = 0;
    }

    private void Update()
    {
        totalScore = amountHit;
    }

    private void OnEnable()
    {
        EventManager.StartListening("ScoreHit", Hit);
    }

    private void OnDisable()
    {
        EventManager.StopListening("ScoreHit", Hit);
    }

    void Hit()
    {
        amountHit++;
        scoreText.text = "X " + amountHit;
        PlayerPrefs.SetInt("TotalScore", totalScore + 1);
    }

    

}

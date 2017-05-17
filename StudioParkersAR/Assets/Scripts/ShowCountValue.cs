using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowCountValue : MonoBehaviour
{
    [Space(10)]
    [Tooltip("The Canvas.")]
    public GameObject canvas;
    [Tooltip("The prefab that needs to be instanciated, in our case the fly.")]
    public GameObject prefab;

    [Space(10)]
    [Tooltip("The position in vector3, this displays where the prefab will be placed.")]
    public Vector3 center;

    [Space(10)]
    [Tooltip("Textfield that displays the score.")]
    public Text scoreField;
    [Tooltip("Textfield that displays the text of the score.")]
    public Text scoreTextField;

    private float degrees;
    private int amount;
    private SoundManager sound;
    private Animator anim;

    // Use this for initialization
    void Start()
    {
        sound = FindObjectOfType<SoundManager>();
        anim = FindObjectOfType<Animator>();
        TotalScore();
    }

    void TotalScore()
    {
        scoreTextField.text = "Total Score:";
        DisplayFlies();
    }

    void DisplayFlies()
    {
        amount = PlayerPrefs.GetInt("TotalScore");
        if (amount > 0)
        {
            degrees = 360 / amount;
            StartCoroutine(SpawnPrefabs(3f / amount, amount));
        }
        else if (amount <= 0)
        {
            scoreField.text = "0";
        }
    }

    public IEnumerator SpawnPrefabs(float interval, float invokeCount)
    {
        for (int i = 0; i < invokeCount; i++)
        {
             var x = center.x + Mathf.Sin((degrees * i) * Mathf.PI / 180) * 150;
             var y = center.y + Mathf.Cos((degrees * i) * Mathf.PI / 180) * 150;
             prefab.transform.position = new Vector3(x, y, 0);
             Instantiate(prefab, canvas.transform, false);
             sound.PlayAudio(0);
             yield return new WaitForSeconds(interval);
        }
        anim.SetBool("isScaling", true);
        anim.Play("Scaling");
        anim.SetBool("isScaling", false);
        scoreField.text = "" + amount.ToString();
        sound.PlayAudio(1);
        
    }

}

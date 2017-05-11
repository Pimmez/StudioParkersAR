using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowCountValue : MonoBehaviour
{
    [SerializeField] private Text scoreField, scoreTextField;

    private float degrees;
    private int amount;
    public GameObject prefab, canvas;
    public Vector3 center;
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
        degrees = 360 / amount;
        //Debug.Log("Spawning");
        StartCoroutine(SpawnPrefabs(3f / amount, amount));

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  

public class ChangeFlyState : MonoBehaviour {

    [SerializeField] private GameObject targetFly;
    public GameObject fly;
    public Image feedback;
    public bool hitFly;

    private void Start()
    {
        feedback.enabled = false;
        hitFly = false;
    }

    //Sets fly and his target off and the feedback image on
    public void ChangeFalse()
    {
        fly.SetActive(false);
        targetFly.SetActive(false);
        hitFly = true;
    }
    //Sets fly and his target on and the feedback image off
    public void ChangeTrue()
    {
        fly.SetActive(true);
        targetFly.SetActive(true);
        feedback.enabled = false;
        hitFly = false;
    }
}

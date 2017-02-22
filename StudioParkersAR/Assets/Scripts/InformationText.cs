using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InformationText : MonoBehaviour {

    [SerializeField]
    private GameObject panelText, infoText;

    [SerializeField]
    private string tagName;

    //Set the gameobjects invisible
    private void Start()
    {
        panelText.SetActive(false);
        infoText.SetActive(false);
    }

    //The moment they collide with each other
    void OnTriggerEnter(Collider other)
    {
        //If the tag of this object is equel to the string, set the gameobjects to visible
        if(this.gameObject.tag == tagName)
        {
            panelText.SetActive(true);
            infoText.SetActive(true);
        }
    }

    //The moment they don't collide with each other
    void OnTriggerExit(Collider other)
    {
        if (this.gameObject.tag == tagName)
        {
            panelText.SetActive(false);
            infoText.SetActive(false);
        }
    }
}

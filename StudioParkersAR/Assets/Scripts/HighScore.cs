using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour{

    public string addScoreURL = "http://mywebsite/check_scores.php"; //be sure to add a ? to your url
    public Text MyInputField;
    public Text showMessage;
    private int Score;

    private void OnEnable()
    {
        EventManager.StartListening("PublishScore", Activated);
    }

    private void OnDisable()
    {
        EventManager.StopListening("PublishScore", Activated);
    }

    void Activated()
    {
        Score = PlayerPrefs.GetInt("TotalScore");
        StartCoroutine(PostScores(MyInputField.text, Score));
    }

    // remember to use StartCoroutine when calling this function!
    IEnumerator PostScores(string myinput, int score)
    {
        //This connects to a server side php script that will add the name and score to a MySQL DB.
        // Supply it with a string representing the players name and the players score.

        // first we create a new WWWForm, that means a "post" command goes out to our database (for futher information just google "post" and "get" commands for html/php
        WWWForm form = new WWWForm();

        // with this line we will give a new name and save our score into that name
        form.AddField("NAME", myinput);
        form.AddField("SCORE", score);

        Debug.Log("Naam: " + myinput + " Score: " + score);

        // the next line will start our php file that saves the Score and attaches the saved values from the "form" to it
        // For this tutorial I've used a new variable "db_url" that stores the path
        WWW webRequest = new WWW(addScoreURL, form);

        // with this line we'll wait until we get an info back
        yield return webRequest;
        Debug.Log(webRequest);
        if (webRequest.error != null)
        {
            showMessage.color = Color.red;
            showMessage.text = "Er is een fout opgetreden bij het uploaden van je Highscore: " + webRequest.error;
        }
        else
        {
            showMessage.color = Color.white;
            showMessage.text = "Jouw Highscore is geüpload!";
            webRequest.Dispose(); //clear our form in game
        }

    }

}

    /*
    private string formNick = ""; //this is the field where the player will put the name to login
    private string formPassword = ""; //this is his password

    public string formText = ""; //this field is where the messages sent by PHP script will be in
    public string URL = "http://mywebsite/check_scores.php"; //change for your URL
    public string hash = "hashcode"; //change your secret code, and remember to change into the PHP file too

    private Rect textrect = new Rect(10, 150, 500, 500); //just make a GUI object rectangle

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 80, 20), "Your nick:"); //text with your nick
        GUI.Label(new Rect(10, 30, 80, 20), "Your pass:");

        formNick = GUI.TextField(new Rect(90, 10, 100, 20), formNick); //here you will insert the new value to variable formNick
        formPassword = GUI.TextField(new Rect(90, 30, 100, 20), formPassword); //same as above, but for password

        if (GUI.Button(new Rect(10, 60, 100, 20), "Try login"))
        { //just a button
            Login();
        }
        GUI.TextArea(textrect, formText);
    }

    void Login()
    {
        var form = new WWWForm(); //here you create a new form connection
        form.AddField("myform_hash", hash); //add your hash code to the field myform_hash, check that this variable name is the same as in PHP file
        form.AddField("myform_nick", formNick);
        form.AddField("myform_pass", formPassword);
        
        var w = WWW(URL, form); //here we create a var called 'w' and we sync with our URL and the form
        yield return w; //we wait for the form to check the PHP file, so our game dont just hang
        if (w.error != null)
        {
            print(w.error); //if there is an error, tell us
        }
        else
        {
            print("Test ok");
            formText = w.data; //here we return the data our PHP told us
            w.Dispose(); //clear our form in game
        }
        
        formNick = ""; //just clean our variables
        formPassword = "";
    }
    */
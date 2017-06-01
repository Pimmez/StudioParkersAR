using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class HighScore : MonoBehaviour {

    private string addScoreURL = "http://www.studioparkers.nl/highscore/highscore.php?"; //be sure to add a ? to your url
    private string secretKey = "Parkerdf3r23e4k4eera23sq3s"; // Edit this value and make sure it's the same as the one stored on the server
    public Text achternaam, voornaam;
    public Text showMessage;
    private int Score;
    private string device;

    private void Start()
    {
#if UNITY_EDITOR
        device = "PC";
#elif (UNITY_IOS)
        device = "IOS";
#elif (UNITY_ANDROID)
         device = "Android"; 
#elif (!UNITY_ANDROID || UNITY_IOS) 
        device = "";
#endif
    }

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
        StartCoroutine(PostScores(voornaam.text, achternaam.text, Score, device, secretKey));
    }

    IEnumerator PostScores(string surname, string lastname, int score, string device, string key)
    {

        // Create a form object for sending high score data to the server
        WWWForm form = new WWWForm();

        string post_url = addScoreURL + "surname=" + WWW.EscapeURL(surname) + "lastname=" + WWW.EscapeURL(lastname) + "&score=" + score + "&device=" + device + "&key=" + key;

        // Post the URL to the site and create a download object to get the result.
        WWW hs_post = new WWW(post_url);
        yield return hs_post; // Wait until the download is done
        print(hs_post);

        if (hs_post.error != null)
        {       
			showMessage.text = "There was an error posting the high score: " + hs_post.error;
        }
        else
        {
			showMessage.text = "Je highscore is geupload!";
        }
        


        /*
        // Create a download object
        WWW webRequest = new WWW(addScoreURL, form);

        // Wait until the download is done
        yield return webRequest; 

        if (!string.IsNullOrEmpty(webRequest.error))
        {
            print("Error downloading: " + webRequest.error);
        }
        else
        {
            // show the highscores
            print("Je highscore is geupload!");
        }
        */
    }

}

    
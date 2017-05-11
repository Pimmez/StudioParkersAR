using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LookAtCamera : MonoBehaviour
{
    [SerializeField] private GameObject target, kikker;
    private Vector3 point, cameraVec;
    private AnimationController anim;
    private ChangeFlyState changeFeed;
    private float screenwidthsom = Screen.width / 30f;
    private float screenheightsom = Screen.height / 40f;
    private float mousePosX, mousePosY;

    public Text farAway;

    private void Start()
    {
        anim = GetComponent<AnimationController>();
        changeFeed = FindObjectOfType<ChangeFlyState>();
        farAway.enabled = false;
    }

    void Update()
    {

        cameraVec = Camera.main.transform.position;
        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || (Input.GetMouseButtonDown(0)))
        {
            if (Input.touchCount > 0)
            {
                mousePosX = Input.GetTouch(0).position.x;
                mousePosY = Input.GetTouch(0).position.y;
            }
            else
            {
                mousePosX = Input.mousePosition.x;
                mousePosY = Input.mousePosition.y;
            }

            //declare a variable of RaycastHit struct
            RaycastHit hit;
            //Create a Ray on the tapped / clicked position
            Ray ray;
            //for unity editor
#if UNITY_EDITOR
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //for touch device
#elif (UNITY_ANDROID || UNITY_IOS || UNITY_WP8)
             ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
#endif

            Invoke("TooFarAway", 2f);

            var testX = (mousePosX / screenwidthsom) - 15;
            var testY = mousePosY / screenheightsom - 20;

            point = cameraVec;
            point.x += testX;
            point.y = testY;

            transform.LookAt(point);
            anim.PlayAttack();
        }
    }

    public void RollingInTong(string name)
    {
        point = target.transform.position;
        point.y = 0f;
        transform.LookAt(point);
        anim.PlayIdle();
        if(changeFeed.hitFly == true)
        {
            changeFeed.raakImage.enabled = true;
        }
    }

    void TooFarAway()
    {
        if(cameraVec.z <= -20 && !farAway.enabled)
        {
            farAway.enabled = true;
            Invoke("HideFarAway", 1f);
        }
    }

    void HideFarAway()
    { 
        farAway.enabled = false;
    }

}

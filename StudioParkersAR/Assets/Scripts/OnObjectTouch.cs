using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnObjectTouch : MonoBehaviour
{

    //flag to check if the user has tapped / clicked.
    //Set to true on click. Reset to false on reaching destination
    private bool isClicked = false;
    //destination point
    private Vector3 endPoint;
    [SerializeField] private GameObject target;
    //vertical position of the gameobject
    private float yAxis;
    private AnimationController animController;

    void Start()
    {
        animController = GetComponent<AnimationController>();
        //save the y axis value of gameobject
        yAxis = gameObject.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {

        //check if the screen is touched / clicked
        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || (Input.GetMouseButtonDown(0)))
        {
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

            //Check if the ray hits any collider
            if (Physics.Raycast(ray, out hit))
            {
                //set a flag to indicate to move the gameobject
                isClicked = true;
                //save the click / tap position
                endPoint = hit.point;
                //as we do not want to change the y axis value based on touch position, reset it to original y axis value
                endPoint.y = yAxis;

                Debug.DrawLine(target.transform.position, endPoint, Color.red);
                Debug.LogError(endPoint);
            }

        }

        

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{

    [SerializeField]
    private Transform target;
    private Vector3 point;

    void Update()
    {

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

           // RollingInTong(name);
           

            point = target.position;
            point.y = target.position.y;
            transform.LookAt(point);
        }

    }

    public void RollingInTong(string name)
    {
        Debug.Log(name);
        point = target.position;
        point.y = 0f;
        transform.LookAt(point);
    }


}

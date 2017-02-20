using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{

    [SerializeField]
    private GameObject objects;

    [SerializeField] private float smoothTime;

    // create a plane in xy, at z = 0
    //private Plane basePlane = new Plane(Vector3.up, new Vector3(0, 0, -100));

    private void Start()
    {
        
    }

    void Update()
    {

        RaycastHit hit = new RaycastHit();
        for (int i = 0; i < Input.touchCount; i++)
        {
            if (Input.GetTouch(i).phase.Equals(TouchPhase.Began))
            {
                // Construct a ray from the current touch coordinates
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                if (Physics.Raycast(ray, out hit))
                {
                    // objectOfChoose.transform.localPosition = Vector3.Lerp(transform.localPosition, Input.GetTouch(0).position, smoothTime);
                    objects.transform.position = Vector3.MoveTowards(objects.transform.position, Input.GetTouch(0).position, Time.deltaTime * smoothTime);
                    Debug.Log(hit.collider.gameObject.transform.position);
                    
                    Debug.DrawLine(transform.position, hit.transform.position, Color.red);
                    
                }
            }

        }



        /*
         
        foreach (Touch touch in Input.touches)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
               
                Debug.Log("bye");

                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(touch.position);

                Debug.Log("Hello");
                if (Physics.Raycast(ray, out hit, 100f))
                {
                    Debug.Log("Doing Something?");
                    Debug.DrawLine(Camera.main.transform.position, touch.position, Color.red);
                    //objectOfChoose.transform.position = Vector3.Lerp(transform.position, hit.transform.position, smoothTime);
                }

            ----------------------------------------------------------------------------

        // no need to set z, because ScreenPointToRay ignores it
        Ray ray = Camera.main.ScreenPointToRay(touch.position);
                float distance;
                if (basePlane.Raycast(ray, out distance))
                {

                    Debug.Log(basePlane.Raycast(ray, out distance));
                    Vector3 planePoint = ray.GetPoint(distance); // get the plane point hit
                    Debug.DrawLine(Camera.main.transform.position, touch.position, Color.red);
                    Instantiate(objectOfChoose, planePoint, Quaternion.identity);
                    //objectOfChoose.transform.position = Vector3.Lerp(transform.position, planePoint, smoothTime);

                }
               
            }
        }
        */
    }
}
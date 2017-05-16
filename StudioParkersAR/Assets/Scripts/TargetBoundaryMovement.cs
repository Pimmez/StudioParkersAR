using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetBoundaryMovement : MonoBehaviour {

    [Space(10)]
    [Tooltip("the Speed, Higher means faster.")]
    public float speed; //<- the speed of the movement * Time.DeltaTime, Higher means faster

    [Space(10)]
    [Tooltip("The menuImage")]
    public Image menuImage;

    private Vector3 bottomLeft; //<- bottomLeft of the screen = (0,0)
    private Vector3 topRight; //<- topRight of the screen = (1,1)
    private Vector3 widthHeight; //<- is topRight - bottomLeft to get the widthHeight values
    private Vector3 moveDirection; //<- was direction changed it to moveDirection for reading purposes
    private float targetX, targetY; //<- Empty variables were we can store values in
  
    // Use this for initialization
    void Start () {
        UpdateDirection();    
    }

    private void OnEnable()
    {
        EventManager.StartListening("SpeedUp", SpeedUp);
    }

    private void OnDisable()
    {
        EventManager.StopListening("SpeedUp", SpeedUp);
    }

    // Update is called once per frame
    void Update () {

        targetX = this.transform.position.x; //Set values in variables
        targetY = this.transform.position.y; //Set values in variables
        
        if (targetX < 0)
        {
            targetX = 0;
            this.transform.position = new Vector3(targetX, this.transform.position.y,this.transform.position.z);
            moveDirection.x *= Random.Range(-0.1f, -1f);

        }
        else if (targetX > Screen.width)
        {
            targetX = Screen.width;
            this.transform.position = new Vector3(targetX, this.transform.position.y, this.transform.position.z);
            moveDirection.x *= Random.Range(-0.1f, -1f);

        }
        if (targetY < 0)
        {
            targetY = 0;
            this.transform.position = new Vector3(this.transform.position.x, targetY, this.transform.position.z);
            moveDirection.y *= Random.Range(-0.1f, -1f);

        }
        else if (targetY > Screen.height)
        {
            targetY = Screen.height;
            this.transform.position = new Vector3(this.transform.position.x, targetY, this.transform.position.z);
            moveDirection.y *= Random.Range(-0.1f, -1f);
        }
       
        this.transform.position += moveDirection * speed * Time.deltaTime;

    }

    void UpdateDirection()
    {
        int verticalRange = Random.Range(0, 2) * 2 - 1;//Random.Range(negativeMovement, positiveMovement);
        int horizontalRange = Random.Range(0, 2) * 2 - 1;//Random.Range(negativeMovement, positiveMovement);
        moveDirection = new Vector3(horizontalRange, verticalRange, 0);
        Invoke("UpdateDirection", Random.Range(0.5f, 3f));
    }

    void SpeedUp()
    {
        speed = speed + 50f;
    }
}

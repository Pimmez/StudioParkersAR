using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetBoundaryMovement : MonoBehaviour {

    private Vector3 bottomLeft; //<- bottomLeft of the screen = (0,0)
    private Vector3 topRight; //<- topRight of the screen = (1,1)
    private Vector3 widthHeight; //<- is topRight - bottomLeft to get the widthHeight values
    private Vector3 moveDirection; //<- was direction changed it to moveDirection for reading purposes
    private float targetX, targetY; //<- Empty variables were we can store values in
    [SerializeField] private float speed = 2f; //<- the speed of the movement * Time.DeltaTime, Higher means faster
    public Image menuImage;

    public float negativeMovement = -1;
    public float positiveMovement = 1;

    //[SerializeField] private GameObject screen; //Changing the screen size

    // Use this for initialization
    void Start () {
        //ChangeScreenSize(); //This Function changes the screen borders on the different devices
        UpdateDirection();    
    }
	
	// Update is called once per frame
	void Update () {

        targetX = this.transform.position.x; //Set values in variables
        targetY = this.transform.position.y; //Set values in variables
        
        if (targetX < 0)
        {
            targetX = 0;
            this.transform.position = new Vector3(targetX, this.transform.position.y,this.transform.position.z);
            moveDirection.x *= -1;

        }
        else if (targetX > Screen.width)
        {
            targetX = Screen.width;
            this.transform.position = new Vector3(targetX, this.transform.position.y, this.transform.position.z);
            moveDirection.x *= -1;

        }
        if (targetY < 0)
        {
            targetY = 0;
            this.transform.position = new Vector3(this.transform.position.x, targetY, this.transform.position.z);
            moveDirection.y *= -1;

        }
        else if (targetY > Screen.height)
        {
            targetY = Screen.height;
            this.transform.position = new Vector3(this.transform.position.x, targetY, this.transform.position.z);
            moveDirection.y *= -1;
        }
       
        this.transform.position += moveDirection * speed * Time.deltaTime;
    }

    void UpdateDirection()
    {
        float verticalRange = Random.Range(negativeMovement, positiveMovement);
        float horizontalRange = Random.Range(negativeMovement, positiveMovement);
        if (horizontalRange == 0)
        {
            horizontalRange = Random.Range(negativeMovement, positiveMovement);
        }
        else if(verticalRange == 0)
        {
            verticalRange = Random.Range(negativeMovement, positiveMovement);
        }
        moveDirection = new Vector3(horizontalRange, verticalRange, 0);
        Invoke("UpdateDirection", Random.Range(0.5f, 3f));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "MenuButton")
        {
            moveDirection *= -1;
        }
    }

    /*
    void ChangeScreenSize() //This Function changes the screen borders on the different devices
    {
        float distance = screen.transform.position.z - Camera.main.transform.position.z;

        bottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        topRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, distance));

        widthHeight = topRight - bottomLeft;

    }
    */
}

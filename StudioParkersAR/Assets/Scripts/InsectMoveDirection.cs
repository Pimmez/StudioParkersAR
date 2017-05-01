using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsectMoveDirection : MonoBehaviour {

    [SerializeField] private GameObject targetDirection;
    private Transform myTrans;

	// Use this for initialization
	void Start () {
        myTrans = this.transform; //Stores this.transform in a variable
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 difference = targetDirection.transform.position - myTrans.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        myTrans.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ - 90); //rotationZ - 90 || otherwise the head is not aligned with the target

        myTrans.position = targetDirection.transform.position; //Changes this objects movement to the targets movement
    }
}

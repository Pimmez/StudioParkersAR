using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour {

    private float speed = 5f;
    [SerializeField] private Transform target;

    void Update()
    {
        transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LookAtCamera : MonoBehaviour
{
    [Space(10)]
    [Tooltip("This is the point where the frog will extend its tongue too")]
    [SerializeField] private GameObject target;

    private Vector3 point, cameraVec;
    private AnimationController anim;
    private ChangeFlyState changeFeed;
    private float screenwidthsom = Screen.width / 30f;
    private float screenheightsom = Screen.height / 40f;
    private float mousePosX, mousePosY;
    private Animator animator;

    [HideInInspector]
    public bool disableTouch = true;

    private void Start()
    {
        anim = GetComponent<AnimationController>();
        animator = FindObjectOfType<Animator>();
        changeFeed = FindObjectOfType<ChangeFlyState>();
    }

    void Update()
    {
        if (disableTouch == true)
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

                var testX = (mousePosX / screenwidthsom) - 15;
                var testY = mousePosY / screenheightsom - 20;

                point = cameraVec;
                point.x += testX;
                point.y = testY;

                

                transform.LookAt(point);
                anim.PlayAttack();
            }
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
            StartCoroutine(EnableFly());
        }
    }

    IEnumerator EnableFly()
    {
        if (changeFeed.raakImage.enabled == false)
        {
            changeFeed.raakImage.enabled = true;
            animator.SetBool("FadeOut", true);
            animator.Play("RaakFade");
            animator.SetBool("FadeOut", false);
            yield return new WaitForSeconds(0.5f);
            EventManager.TriggerEvent("EnableFly");
        }     
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    CharacterController controller;
    Vector3 moveVector;
    [SerializeField]
    public float speed;
    public float horizontalspeed = 2.0f;
    public float jumpForce = 4.0f;
    float verticalVelocity = 0.0f;
    float gravity = 12.0f;
    private float animationDuration = 2.0f;
    public float gyrospeed = 1.5f;

    //swipe variables

    public float minSwipeDistY;
    public float minSwipeDistX;
    private Vector2 startPos;

    // Use this for initialization
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //for first 2 sec, till the camera comes down, none of the key ll work

        if (Time.time < animationDuration)
        {
            controller.Move(Vector3.forward * speed * Time.deltaTime);
            return;
        }

        moveVector = Vector3.zero;
        if (controller.isGrounded)
        {
            verticalVelocity = -0f;
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }
        //x
        moveVector.x = Input.GetAxisRaw("Horizontal") * horizontalspeed;
        
        #if UNITY_ANDROID
           moveVector.x = Input.acceleration.x * gyrospeed;
           Debug.Log("accelerator is working !!");
        #endif

        //y
        moveVector.y = verticalVelocity;
        if (Input.GetKeyDown("space"))
        {
            moveVector.y = jumpForce * Time.deltaTime;
            controller.GetComponent<Animator>().SetTrigger("jump");
        }

        //forward
        moveVector.z = speed;

        controller.Move((moveVector * speed) * Time.deltaTime);

        //#if UNITY_ANDROID
        if (Input.touchCount > 0)

        {
          Touch touch = Input.touches[0];
            switch (touch.phase)

            {
                case TouchPhase.Began:
                  startPos = touch.position;
                  break;

                case TouchPhase.Ended :
                case TouchPhase.Canceled:

                    float swipeDistVertical = (new Vector3(0, touch.position.y, 0) - new Vector3(0, startPos.y, 0)).magnitude;

                    if (swipeDistVertical > minSwipeDistY)

                    {
                        float swipeValue = Mathf.Sign(touch.position.y - startPos.y);
                        if (swipeValue > 0)

                        {
                            Debug.Log("up");
                            moveVector.y = jumpForce * Time.deltaTime;
                            controller.GetComponent<Animator>().SetTrigger("jump");
                        }
                        else if (swipeValue < 0)
                        {
                            //Slide();
                        }
                    }

                    float swipeDistHorizontal = (new Vector3(touch.position.x, 0, 0) - new Vector3(startPos.x, 0, 0)).magnitude;

                    if (swipeDistHorizontal > minSwipeDistX)

                    {
                        float swipeValue = Mathf.Sign(touch.position.x - startPos.x);
                        if (swipeValue > 0)
                        {
                             //turn and rotate right
                           // transform.Rotate(0, (swipeValue * 300 ), 0);
                           // moveVector.x = speed;
                           // controller.Move((moveVector * speed) * Time.deltaTime);
                            Debug.Log("right");
                        }
                        else if (swipeValue < 0)
                        {   //turn and rotate left
                           // transform.Rotate(0,swipeValue, 0);
                            Debug.Log("left");
                        }
                    }
                break;
            }
        }
    }

}








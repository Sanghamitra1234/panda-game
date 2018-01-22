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
    public float jumpForce = 9.0f;
    float verticalVelocity = 0.0f;
    float gravity = 12.0f;
    private float animationDuration = 2.0f;
    private Vector2 startPos;
    private int direction = 0;
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
            controller.Move(Vector3.forward*speed * Time.deltaTime);
            return;
        }

        if (controller.isGrounded)
        {
            verticalVelocity = 0f;
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        moveVector = Vector3.zero;
        
        //y direction
        moveVector.y = verticalVelocity;
        if (Input.GetKeyDown("space"))
        {
            moveVector.y = jumpForce;
            controller.GetComponent<Animator>().Play("Jump");
        }
        // Right Turn
        if (Input.GetKeyDown("h")) {
            Vector3 NextDir;
            if (direction == 0)
            {
                NextDir = new Vector3(1, 0, 0);
                direction = 2;
            }
            else if (direction == 1)
            {
                NextDir = new Vector3(-1, 0, 0);
                direction = 3;
            }
            else if (direction == 2)
            {
                NextDir = new Vector3(0, 0, -1);
                direction = 1;
            }
            else
            {
                NextDir = new Vector3(0, 0, 1);
                direction = 0;
            }
            transform.rotation = Quaternion.LookRotation(NextDir);
        }
        //Left Turn
        if (Input.GetKeyDown("g"))
        {
            Vector3 NextDir;
            if (direction == 0)
            {
                NextDir = new Vector3(-1, 0, 0);
                direction = 3;
            }
            else if (direction == 1)
            {
                NextDir = new Vector3(1, 0, 0);
                direction = 2;
            }
            else if (direction == 2)
            {
                NextDir = new Vector3(0, 0, 1);
                direction = 0;
            }
            else
            {
                NextDir = new Vector3(0, 0, -1);
                direction = 1;
            }
            transform.rotation = Quaternion.LookRotation(NextDir);
        }
        // X and Z direction

        if (direction == 0) {
            // For Z moving
            moveVector.z = speed * speed;
            moveVector.x = Input.GetAxisRaw("Horizontal") * horizontalspeed;
        }
        else if (direction == 1) {
            // For -Z moving
            moveVector.z = (-1)*speed * speed;
            moveVector.x = (-1)*Input.GetAxisRaw("Horizontal") * horizontalspeed;
        }
        else if (direction == 2) {
            // For X moving
            moveVector.x = speed * speed;
            moveVector.z = (-1)*Input.GetAxisRaw("Horizontal") * horizontalspeed;
        }
        else {
            // For -X moving
            moveVector.x = (-1)*speed * speed;
            moveVector.z = Input.GetAxisRaw("Horizontal") * horizontalspeed;
        }

        controller.Move(moveVector * Time.deltaTime);
    }

}








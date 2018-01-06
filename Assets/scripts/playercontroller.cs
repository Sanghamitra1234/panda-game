using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour {
    CharacterController controller;
    Vector3 moveVector;
    [SerializeField]
    public float speed;
    public float horizontalspeed = 2.0f;
    public float jumpForce = 4.0f;
    float verticalVelocity = 0.0f;
    float gravity = 12.0f;
    private float animationDuration = 2.0f;

    // Use this for initialization
    void Start () {
        controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        //for first 2 sec, till the camera comes down, none of the key ll work

        if(Time.time < animationDuration)
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
        moveVector.x = Input.GetAxisRaw("Horizontal")*horizontalspeed;

        //y
        moveVector.y = verticalVelocity;
        if (Input.GetKeyDown("space"))
        {
            controller.GetComponent<Animator>().SetTrigger("jump");
            moveVector.y = jumpForce;
        }

        //forward
        moveVector.z= speed;

        controller.Move((moveVector * speed )*Time.deltaTime);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour {

    private Transform lookat;
    Vector3 startOffset;
    private Vector3 moveVector;

    private float transition = 0.0f;
    private float animationDuration = 2.0f;
    private Vector3 animationOffset = new Vector3(0, 5, 5);

	// Use this for initialization
	void Start () {
        lookat=GameObject.FindGameObjectWithTag("Player").transform;
        startOffset = transform.position - lookat.position;
	}
	
	// Update is called once per frame
	void Update () {
        moveVector = lookat.position + startOffset;
        moveVector.x = 0;
        if (transition > 1.0f)

        {
           transform.position = moveVector;
        }
        else
        {
            // start zoom in 
            transform.position = Vector3.Lerp(moveVector + animationOffset, moveVector, transition);
            transition += Time.deltaTime * 1 / animationDuration;
            transform.LookAt(lookat.position + Vector3.up);
        }
	}
}

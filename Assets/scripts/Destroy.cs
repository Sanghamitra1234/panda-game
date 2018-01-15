using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {
    float pos;
    private Transform playerPos;
  
    // Use this for initialization
    void Start () {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
       
    }

    // Update is called once per frame
    void Update () {
		
	}
}

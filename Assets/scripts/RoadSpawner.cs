using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour {

    public GameObject bridgeSmall, bridgeLarge, ground1, ground2, ground3, ground4, ground5, ground6, ground7, ground8,groundBlock,groundIsland,hurdle1,hurdlw2,hurdle3;
    // Use this for initialization
    float groundLength;
    private Transform playerPos;
    Vector3 newRoadPos;


    void Start () {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        newRoadPos = playerPos.position;
        StartSpawningRoad();
    }

    // Update is called once per frame
    void Update () {
		
	}
    void StartSpawningRoad() {
        for(int i = 0; i < 10; i++) {
            SpawnGround1();
        }
    }
    void SpawnGround1() {
        GameObject ground = Instantiate(ground1, newRoadPos, Quaternion.identity);
        newRoadPos.z = newRoadPos.z + 7.55f;
    }
}

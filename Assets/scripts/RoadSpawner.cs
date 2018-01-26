using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour {

    public GameObject bridgeSmall, bridgeLarge, ground1, ground2, ground3, ground4, ground5, ground6, ground7, ground8,groundBlock,groundIsland,hurdle1,hurdlw2,hurdle3;
    // Use this for initialization
    float groundLength,fixOffset,offset;
    private Transform playerPos;
    Vector3 newRoadPos;


    void Start () {
       playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        newRoadPos = playerPos.position;
        StartSpawningRoad();
        fixOffset = newRoadPos.z - playerPos.position.z;
    }

    // Update is called once per frame
    void Update () {
        offset = newRoadPos.z - playerPos.position.z;
        if (offset < fixOffset) {
            Spawn();
        }
	}
    void StartSpawningRoad() {
        for(int i = 0; i < 20; i++) {
            Spawn();
        }
    }

    void Spawn() {
        int rand = Random.Range(0, 10);
        if (rand < 8)
        {
            SpawnGround1();
        }
        else {
            SpawnBridgeLarge();
        }
    }

    void SpawnGround1() {
        GameObject ground = Instantiate(ground1, newRoadPos, Quaternion.identity);
        newRoadPos.z = newRoadPos.z + 7.55f;
  }
    void SpawnBridgeLarge() {
        GameObject bridge = Instantiate(bridgeLarge, newRoadPos, Quaternion.identity);
        newRoadPos.z = newRoadPos.z + 7.55f;
    }
}

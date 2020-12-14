using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private Transform playerTransform;


    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void LateUpdate()
    {
        Vector3 startPos = transform.position;      //camera current pos

        startPos.x = playerTransform.position.x; // camera x equal to player x
        startPos.y = playerTransform.position.y+3; // camera y equal to player y
        startPos.z = -10;                        // camera z equal to -10

        transform.position = startPos;          // add offset value to thew temporary startPos

    }
}

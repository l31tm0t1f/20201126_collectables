using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject Player;         // defines Player which is used to position camera
    [SerializeField] float timeOffset;          // camera-related parameter
    [SerializeField] Vector2 posOffset;         // is not used
    [SerializeField] float leftLimit;           // camera-related parameter
    [SerializeField] float rightLimit;          // camera-related parameter
    [SerializeField] float bottomLimit;         // camera-related parameter
    [SerializeField] float topLimit;            // camera-related parameter
    private Vector3 velocity;                   // 

    void Update()
    {
        Vector3 startPos = transform.position;      //camera current pos
        Vector3 endPos = Player.transform.position; //Players current position
        endPos.x += posOffset.x;
        endPos.y += posOffset.y;
        endPos.z = -10;


        //transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, -10);      // not used

        transform.position = Vector3.SmoothDamp(startPos, endPos, ref velocity, timeOffset);        // Gradually changes a vector towards a desired destination (player location)

        transform.position = new Vector3
        (
        Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
        Mathf.Clamp(transform.position.y, bottomLimit, topLimit),
        transform.position.z
    );
    }
}

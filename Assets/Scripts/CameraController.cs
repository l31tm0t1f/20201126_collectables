using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] float timeOffset;
    [SerializeField] Vector2 posOffset; // is not used
    [SerializeField] float leftLimit;
    [SerializeField] float rightLimit;
    [SerializeField] float bottomLimit;
    [SerializeField] float topLimit;
    private Vector3 velocity;

    void Start()
    {

    }

    void Update()
    {
        //camera current pos
        Vector3 startPos = transform.position;

        //Players current position
        Vector3 endPos = Player.transform.position;
        endPos.x += posOffset.x;
        endPos.y += posOffset.y;
        endPos.z = -10;


        //transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, -10);

        transform.position = Vector3.SmoothDamp(startPos, endPos, ref velocity, timeOffset);

        transform.position = new Vector3
        (
        Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
        Mathf.Clamp(transform.position.y, bottomLimit, topLimit),
        transform.position.z
    );
    }
}

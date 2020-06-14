using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Rigidbody2D toFollow;
    public float speed;

    private Vector3 lastPlayerPosition;
    
    private float distanceToMove;


    // Start is called before the first frame update
    void Start()
    {
        lastPlayerPosition = toFollow.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        distanceToMove = toFollow.transform.position.x - lastPlayerPosition.x;

        transform.position = new Vector3(transform.position.x + distanceToMove, transform.position.y, transform.position.z);

        lastPlayerPosition = toFollow.transform.position;    
    }
}

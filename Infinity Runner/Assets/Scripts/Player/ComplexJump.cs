using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComplexJump : MonoBehaviour
{

    public Rigidbody2D rb;
    public float fallMultiplier = 5f;
    public float smallJumpMultiplier = 10f;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        bool _falling = rb.velocity.y < 0;
        bool _jumping = Input.GetButton("Jump");

        if (_falling)//faster fall
        {
            rb.velocity += Vector2.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;

        }
        else if (!_falling && !_jumping)//small jump
        {
            rb.velocity += Vector2.up * Physics.gravity.y * (smallJumpMultiplier - 1) * Time.deltaTime;
        }

    }
}

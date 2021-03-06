﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalJump : MonoBehaviour
{

    public PlayerControl player;
    public Rigidbody2D playerRb;
    public AudioSource jumpSound;
    public float fallMultiplier = 5f;
    public float smallJumpMultiplier = 10f;


    void Awake()
    {
        player = GetComponent<PlayerControl>();
        playerRb = player.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetButtonDown("Up"))
        {
            if (player.IsGrounded())
            {
                playerRb.velocity = new Vector2(playerRb.velocity.x, player.jumpForce);
                jumpSound.Play();
            }
            
        }

        bool _falling = playerRb.velocity.y < 0;
        bool _jumping = Input.GetButton("Up");

        if (_falling)//faster fall
        {
            playerRb.velocity += Vector2.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;

        }
        else if (!_falling && !_jumping)//small jump
        {
            playerRb.velocity += Vector2.up * Physics.gravity.y * (smallJumpMultiplier - 1) * Time.deltaTime;
        }

    }
}

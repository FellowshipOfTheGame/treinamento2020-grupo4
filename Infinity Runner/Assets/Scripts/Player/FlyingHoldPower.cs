using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//powerup that allows player to control flight holding jump key
public class FlyingHoldPower : MonoBehaviour
{
    public PlayerControl player;
    private Rigidbody2D playerRb;
    public float flyForce = 7f;
    public float standartGravity;
    private void Awake()
    {
        this.player = GetComponent<PlayerControl>();
        this.playerRb = player.GetComponent<Rigidbody2D>();
        standartGravity = playerRb.gravityScale;
        GetComponent<NormalJump>().enabled = false;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButton("Jump"))
        {
            playerRb.gravityScale = 0;
            playerRb.velocity = new Vector2(playerRb.velocity.x, flyForce);
        }
        else
        {
            playerRb.gravityScale = 2.5f;
        }


    }

    private void OnDestroy()
    {
        playerRb.gravityScale = standartGravity;
        GetComponent<NormalJump>().enabled = true;
    }
}

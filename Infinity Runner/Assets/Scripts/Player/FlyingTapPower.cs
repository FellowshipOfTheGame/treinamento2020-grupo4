using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingTapPower : MonoBehaviour
{
    public PlayerControl player;
    private Rigidbody2D playerRb;

    private void Awake()
    {
        this.player = GetComponent<PlayerControl>();
        this.playerRb = player.GetComponent<Rigidbody2D>();
        GetComponent<NormalJump>().enabled = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, player.jumpForce);
        }
    }

    private void OnDestroy()
    {
        GetComponent<NormalJump>().enabled = true;
    }
}

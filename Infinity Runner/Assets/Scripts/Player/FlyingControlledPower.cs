using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

//powerup that allows player to control flight with UP and DOWN keys
public class FlyingControlledPower : MonoBehaviour
{
    public PlayerControl player;
    private Rigidbody2D playerRb;
    private float standartGravity;
    public float speed = 10;

    private void Awake()
    {
        this.player = GetComponent<PlayerControl>();
        this.playerRb = player.GetComponent<Rigidbody2D>();
        standartGravity = playerRb.gravityScale;
        playerRb.gravityScale = 0;
        GetComponent<NormalJump>().enabled = false;
    }

    void FixedUpdate()
    {
        float _movement = Input.GetAxis("Vertical");

        playerRb.velocity = new Vector2(playerRb.velocity.x, _movement*speed);
        
    }

    private void OnDestroy()
    {
        playerRb.gravityScale = standartGravity;
        GetComponent<NormalJump>().enabled = true;
    }
}

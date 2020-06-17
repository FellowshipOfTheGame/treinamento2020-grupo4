using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;


public class PlayerControl : MonoBehaviour
{

    public float moveSpeed = 6;
    public float speedMultiplier; // for when the player is behind player point
    public float jumpForce;

    public Transform playerPoint;

    private Rigidbody2D myRigidbody;
    private Collider2D myCollider;


    public bool grounded;
    public LayerMask groundLayer;

    private Animator myAnimator;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();

        myCollider = GetComponent<Collider2D>();

        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAnimation();
        Move();
    }

    void Move()
    {
        Velocity();
        SimpleJump();
    }

    void Velocity()
    {
        if (IsBehindPlayerPoint())
        {
            float _distanceToPlayerPoint = playerPoint.position.x - transform.position.x;
            myRigidbody.velocity = new Vector2(GetNewVelocity(_distanceToPlayerPoint), myRigidbody.velocity.y);
        }
        else
        {
            myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y);
        }
    }

    private float GetNewVelocity(float _distanceToPlayerPoint)//return the velocity given the distance between player and player point.
    {

        float _maxDistance = playerPoint.position.x - GetLeftScreenLimit();//the value of the max distance that player can reach (he/she will die if touch the left side of screen)

        return moveSpeed * ( (speedMultiplier -1) * (_distanceToPlayerPoint/_maxDistance) + 1); //linear function:   moveSpeed <= newVelocity <= moveSpeed * speedMultiplier
    }

    public float GetLeftScreenLimit()
    {
        //Generate world space point information for position and scale calculations
        Vector3 _cameraPos = Camera.main.transform.position;
        float _screenSize = Vector2.Distance(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)), Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0))) * 0.5f;
        return _cameraPos.x - _screenSize;
    }

    void SimpleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (IsGrounded())
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
            }
        }
    }

    bool IsBehindPlayerPoint()
    {
        return playerPoint.position.x - transform.position.x > 0;
    }

    void UpdateAnimation()
    {
        float _actualVelocity = myRigidbody.velocity.x;
        myAnimator.SetFloat("Speed", _actualVelocity);
        myAnimator.SetBool("Grounded", IsGrounded());
    }

    bool IsGrounded()
    {
        float _extraHeight = 0.5f;
        RaycastHit2D boxCastHit = Physics2D.BoxCast(myCollider.bounds.min, myCollider.bounds.size / 10, 0, Vector2.down, _extraHeight, groundLayer);

        return boxCastHit.collider != null;
    }
}

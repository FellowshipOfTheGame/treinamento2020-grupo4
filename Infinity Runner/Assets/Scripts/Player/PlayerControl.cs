using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using UnityEngine;


public class PlayerControl : MonoBehaviour
{

    public float moveSpeed;
    public float jumpForce;

    public Transform playerPoint;
    public float speedMultiplier; // for when the player gets off the player point

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
            myRigidbody.velocity = new Vector2(moveSpeed * speedMultiplier, myRigidbody.velocity.y);
        }
        else
        {
            myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y);
        }
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

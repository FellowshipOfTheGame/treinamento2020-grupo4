using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using UnityEngine;


public class PlayerControl : MonoBehaviour
{

    public float moveSpeed;
    public float jumpForce;
 
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

        updateAnimation();

  
        
        myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (IsGrounded())
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
            }
        }

    }

    void updateAnimation()
    {
        float _actualVelocity = myRigidbody.velocity.x;
        myAnimator.SetFloat("Speed", _actualVelocity);
        myAnimator.SetBool("Grounded", IsGrounded());
    }

    bool IsGrounded()
    {
        float _extraHeightTest = 0.01f;
        boxCastHit2D boxCastHit = Physics2D.BoxCast(myCollider.bounds.min, myCollider.bounds.size / 10, 0, Vector2.down, _extraHeightTest, groundLayer);

        return boxCastHit.collider != null;
    }
}

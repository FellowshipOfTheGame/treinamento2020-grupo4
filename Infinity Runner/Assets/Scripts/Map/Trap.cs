using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Trap : MonoBehaviour
{   
    private BoxCollider2D trapCollider;
    private Rigidbody2D trapRigidBody;
    // Start is called before the first frame update
    private void Awake()
    {
        trapCollider = gameObject.GetComponent<BoxCollider2D>();
        trapRigidBody = gameObject.GetComponent<Rigidbody2D>();

        trapCollider.isTrigger = true;
        trapRigidBody.gravityScale = 0;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenLimits : MonoBehaviour
{
    public float colDepth = 2f;
    public float zPosition = 0f;
    private Vector2 screenSize;
    private Transform bottomCollider;
    private Transform leftCollider;
    private Vector3 cameraPos;
    // Use this for initialization
    void Start()
    {
        CreateScreenLimitsObjects();
        NameObjects();
        AddColliders();
        Initialize();
    }

    private void Initialize()
    {

        bottomCollider.parent = transform;

        leftCollider.parent = transform;
    }

    private void AddColliders()
    {

        //Add the colliders
        bottomCollider.gameObject.AddComponent<BoxCollider2D>();
        bottomCollider.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        leftCollider.gameObject.AddComponent<BoxCollider2D>();
        leftCollider.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;


    }

    private void NameObjects()
    {

        //Name our objects 
        bottomCollider.name = "BottomCollider";
        leftCollider.name = "LeftCollider";
    }

    private void CreateScreenLimitsObjects()
    {
        //Generate our empty objects
        bottomCollider = new GameObject().transform;
        leftCollider = new GameObject().transform;
    }

    private void LateUpdate()
    {

        //Generate world space point information for position and scale calculations
        cameraPos = Camera.main.transform.position;
        screenSize.x = Vector2.Distance(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)), Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0))) * 0.5f;
        screenSize.y = Vector2.Distance(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)), Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height))) * 0.5f;

        //Change our scale and positions to match the edges of the screen...   
        leftCollider.localScale = new Vector3(colDepth, screenSize.y * 2, colDepth);
        leftCollider.position = new Vector3(cameraPos.x - screenSize.x - (leftCollider.localScale.x * 0.5f), cameraPos.y, zPosition);
        bottomCollider.localScale = new Vector3(screenSize.x * 2, colDepth, colDepth);
        bottomCollider.position = new Vector3(cameraPos.x, cameraPos.y - screenSize.y - (bottomCollider.localScale.y * 0.5f), zPosition);
    }
    
}

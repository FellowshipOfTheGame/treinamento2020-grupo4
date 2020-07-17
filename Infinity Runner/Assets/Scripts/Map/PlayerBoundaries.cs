using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//clamp player into screen boundaries
//code found on: https://pressstart.vip/tutorials/2018/06/28/41/keep-object-in-bounds.html
public class PlayerBoundaries : MonoBehaviour
{
   
    public Camera MainCamera;
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;

    // Use this for initialization
    void Start()
    {
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y; //extents = size of height / 2
    }

    // Update is called once per frame
    void LateUpdate()
    {
        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
        
        Vector3 viewPos = transform.position;
        
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight);
        
        transform.position = viewPos;
    }
}

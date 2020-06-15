using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour
{

    public Transform destructionPointTransform;

    // Start is called before the first frame update
    void Start()
    {
        destructionPointTransform = GameObject.Find("PlatformDestructionPoint").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(transform.position.x < destructionPointTransform.position.x)
        {
            Destroy(gameObject);
        }
    }
}

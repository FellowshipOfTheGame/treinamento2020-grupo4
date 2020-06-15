using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject platform;
    public Transform generationPoint;
    public Camera gameCamera;


    private float platformWidth;
    public float distBetweenMin;
    public float distBetweenMax;
    public float heightBetweenMax;
    public float heightBetweenMin;
    public float maxHeight;
    public float minHeight;
    public float actualHeight;
    

    void Start()
    {
        platformWidth = platform.GetComponent<BoxCollider2D>().size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < generationPoint.transform.position.x)
        {
            actualHeight = transform.position.y;

            float _distBetween = Random.Range(distBetweenMin, distBetweenMax);
            float _heightBetween = Random.Range(heightBetweenMin, heightBetweenMax) * Random.Range(-1, 2);
            
            if(actualHeight + _heightBetween > maxHeight || actualHeight + _heightBetween < minHeight)
            {
                _heightBetween *= -1;
            }

            transform.position = new Vector3(transform.position.x + platformWidth + _distBetween, actualHeight + _heightBetween, transform.position.z);

            Instantiate(platform, transform.position, transform.rotation);

        }
    }
}

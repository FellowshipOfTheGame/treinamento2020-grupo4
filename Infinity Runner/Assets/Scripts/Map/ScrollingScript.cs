using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
public class ScrollingScript : MonoBehaviour {

    private float length, startpos;
    public GameObject cam;
    public float parallaxEffect;

    private void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void Update()
    {
        float _temp = (cam.transform.position.x * (1 - parallaxEffect));
        float dist = (cam.transform.position.x * parallaxEffect);

        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);

        if (_temp > startpos + length) startpos += length;
        else if (_temp < startpos - length) startpos -= length;

    }


}

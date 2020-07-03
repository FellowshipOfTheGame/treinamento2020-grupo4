using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public AudioSource groundSound;
    public AudioSource variation1;
    public AudioSource variation2;
    public AudioSource variation3;

    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !groundSound.isPlaying)
        {
            groundSound.Play();

        }else if (groundSound.isPlaying)
        {
            groundSound.isPlaying
        }



    }
}

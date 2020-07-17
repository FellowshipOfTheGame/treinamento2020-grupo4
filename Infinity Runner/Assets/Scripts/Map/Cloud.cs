using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    public AudioSource cloudSound;
    public AudioSource fellGroundSound;

    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !cloudSound.isPlaying)
        {
            cloudSound.Play();
            fellGroundSound.Play();
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && cloudSound.isPlaying)
        {
            cloudSound.Pause();

        }

    }
}

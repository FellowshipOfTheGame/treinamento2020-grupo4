using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class River : MonoBehaviour
{
    public AudioSource deathSound;
    public static event Action PlayerDeath;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            deathSound.Play();
            PlayerDeath();
            Debug.Log("Dei play");
        }
    }
}

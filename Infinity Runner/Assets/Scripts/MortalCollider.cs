using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortalCollider : MonoBehaviour
{
    // Start is called before the first frame update

    public static event Action PlayerDeath;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        {
            if (collider.CompareTag("Player"))
            {
                if (PlayerDeath != null)
                {
                    PlayerDeath();
                }
            }
        }
    }

}

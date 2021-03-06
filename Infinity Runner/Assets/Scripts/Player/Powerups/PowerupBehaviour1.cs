﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupBehaviour1 : MonoBehaviour
{
    
    public PowerupController controller;

    [SerializeField]
    private Powerup powerup;

    private Transform transform_;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
        
            ActivatePowerup();
            gameObject.SetActive(false);
        }
    }

    private void ActivatePowerup()
    {
        controller.ActivatePowerup(powerup);
    }

    public void SetPowerup(Powerup powerup)
    {
        this.powerup = powerup;
        gameObject.name = powerup.name;
    }
}

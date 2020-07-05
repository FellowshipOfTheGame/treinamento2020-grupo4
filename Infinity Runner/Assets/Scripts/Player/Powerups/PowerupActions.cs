using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupActions : MonoBehaviour
{
    [SerializeField]
    public PlayerControl playerController;

    public AudioSource superJumpSound;
    public AudioSource flySound;

    public void SuperJumpStartAction()
    {
        playerController.jumpForce *= 0.75f;
        playerController.getRigidBody().gravityScale = 1.9f;
        superJumpSound.Play();
    }

    public void SuperJumpEndAction()
    {
        playerController.jumpForce = playerController.defaultJump;
        playerController.getRigidBody().gravityScale = playerController.defaultGravity;
    }

    public void FlyingTapStartAction()
    {      
        
        playerController.gameObject.AddComponent<FlyingTapPower>();
    }

    public void FlyingTapEndAction()
    {
        Destroy(playerController.GetComponent<FlyingTapPower>());
    }

    public void FlyingHoldStartAction()
    {
        playerController.gameObject.AddComponent<FlyingHoldPower>();
    }

    public void FlyingHoldEndAction()
    {
        Destroy(playerController.GetComponent<FlyingHoldPower>());
    }

    public void FlyingControlledStartAction()
    {
        flySound.Play();
        playerController.gameObject.AddComponent<FlyingControlledPower>();
    }

    public void FlyingControlledEndAction()
    {
        Destroy(playerController.GetComponent<FlyingControlledPower>());
    }

}

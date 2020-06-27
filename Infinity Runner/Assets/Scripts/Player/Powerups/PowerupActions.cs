using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupActions : MonoBehaviour
{
    [SerializeField]
    public PlayerControl playerController;

    public void SuperJumpStartAction()
    {
        playerController.jumpForce *= 2;
    }

    public void SuperJumpEndAction()
    {
        playerController.jumpForce = playerController.defaultJump;
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
        playerController.gameObject.AddComponent<FlyingControlledPower>();
    }

    public void FlyingControlledEndAction()
    {
        Destroy(playerController.GetComponent<FlyingControlledPower>());
    }

}

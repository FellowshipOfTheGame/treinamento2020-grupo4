using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{

    public AudioSource breathing;
    public AudioSource runningCloud;
    public AudioSource runningGround;
    public AudioSource breakingBranch1;
    public AudioSource breakingBranch2;
    public AudioSource breakingBranch3;
    private static int numVariations = 3;

    public AudioSource fallingGround;
    public AudioSource fallingRiver;
    public AudioSource fallingCloud;


    private void Start()
    {
        breathing.Play();
    }

    public void PlayerRunning()
    {
        PlayerRunningGround();
    }

    public void PlayerFell()
    {
        //check where it is faling
    }


    public void PlayerRunningGround()
    {

        if (runningGround.isPlaying)
            return;
        
        runningGround.Play();
        
        int _rand = Random.Range(0, numVariations);

        switch (_rand)
        {
            case 0:
                breakingBranch1.Play();
                break;
            case 1:
                breakingBranch2.Play();
                break;
            case 2:
                breakingBranch3.Play();
                break;
        }

    }

    public void PlayerRunningCloud()
    {
        runningCloud.Play();

    }

    public void PlayerFallingGround()
    {
        fallingGround.Play();
    }

    public void PlayerFallingCloud()
    {
        fallingCloud.Play();
    }

    public void  PlayerFallingRiver()
    {
        fallingRiver.Play();
    }
}

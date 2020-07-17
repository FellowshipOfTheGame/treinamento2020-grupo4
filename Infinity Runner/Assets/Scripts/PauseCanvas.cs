using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseCanvas : MonoBehaviour
{
    public GameObject soundButton;
    public GameObject musicButton;

    public GameManager gm;

    public AudioSource music;
    public GameObject sfx;

    public void MusicControl()
    {
        if (gm.musicActive)
        {
            gm.musicActive = false;
            music.enabled = false;
        }
        else
        {
            gm.musicActive = true;
            music.enabled = true;
            music.Stop();
        }
    }

    public void SoundControl()
    {
        if (gm.soundEnabled)
        {
            gm.soundEnabled = false;
            sfx.SetActive(false);
        }
        else
        {
            gm.musicActive = true;

            Transform[] children = sfx.GetComponentsInChildren<Transform>();
            Debug.Log(children.Length);
            foreach (Transform child in children){
                child.gameObject.SetActive(true);
            }
                
   
        }
    }
}

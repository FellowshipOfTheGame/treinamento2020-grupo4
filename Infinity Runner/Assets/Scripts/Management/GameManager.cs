using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private bool isPaused = false;

    public static event Action OnPause;
    public static event Action OnResume;
    public static event Action OnLost;
    public static event Action OnWon;

    public AudioSource soundtrack;
    public GameObject soundEffects;

    private void Awake()
    {
        MortalCollider.PlayerDeath += PlayerLost;
        Enemies.PlayerDeath += PlayerLost;
        River.PlayerDeath += PlayerLost;
        FinishPoint.PlayerWon += PlayerWon;
        Time.timeScale = 1;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    private void OnDestroy()
    {
        MortalCollider.PlayerDeath -= PlayerLost;
        FinishPoint.PlayerWon -= PlayerWon;
        Enemies.PlayerDeath -= PlayerLost;
        River.PlayerDeath -= PlayerLost;
    }

    private void PlayerLost()
    {
        Time.timeScale = 0f;
        soundtrack.Pause();
        OnLost();
        Debug.Log("Perdeuu");
    }

    private void PlayerWon()
    {
        Time.timeScale = 0f;
        soundtrack.Pause();
        soundEffects.SetActive(false);
        OnWon();
        Debug.Log("Ganhouu");
    }


    public void Pause()
    {
        if (isPaused)
        {
            soundtrack.Play();
            isPaused = false;
            Time.timeScale = 1f;
            soundEffects.SetActive(true);
            OnResume();
        }
        else
        {
            soundtrack.Pause();
            isPaused = true;
            Time.timeScale = 0f;
            soundEffects.SetActive(false);
            OnPause();
        }
    }

    public void Restart()
    {
        Scene _scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(_scene.name);
    }

    public void BackToMenu()
    {
        int buildIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(buildIndex - 1);
        
    }

    
}

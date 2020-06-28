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

    private void Awake()
    {
        MortalCollider.PlayerDeath += PlayerLost;
        FinishPoint.PlayerWon += PlayerWon;
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
    }

    private void PlayerLost()
    {
        Time.timeScale = 0f;
        OnLost();
        Debug.Log("Perdeuu");
    }

    private void PlayerWon()
    {
        Time.timeScale = 0f;
        OnWon();
        Debug.Log("Ganhouu");
    }


    public void Pause()
    {
        if (isPaused)
        {
            isPaused = false;
            Time.timeScale = 1f;
            OnResume();
        }
        else
        {
            isPaused = true;
            Time.timeScale = 0f;
            OnPause();
        }
    }

    public void Restart()
    {
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
        Time.timeScale = 1f;
    }
}

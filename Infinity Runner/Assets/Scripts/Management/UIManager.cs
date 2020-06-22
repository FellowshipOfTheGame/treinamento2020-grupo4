using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject lostScreen;
    public GameObject pauseScreen;
    // Start is called before the first frame update
    void Awake()
    {
        RegisterEvents();
    }

    private void OnDestroy()
    {
        UnregisterEvents();
    }

    private void RegisterEvents()
    {
        GameManager.OnPause += PauseGame;
        GameManager.OnResume += ResumeGame;
        GameManager.OnLost += LostGame;
    }

    private void UnregisterEvents()
    {
        GameManager.OnPause -= PauseGame;
        GameManager.OnResume -= ResumeGame;
        GameManager.OnLost -= LostGame;
    }


    private void ResumeGame()
    {
        pauseScreen.SetActive(false);
    }

    private void PauseGame()
    {
        pauseScreen.SetActive(true);
    }

    private void LostGame()
    {
        lostScreen.SetActive(true);
    }

}

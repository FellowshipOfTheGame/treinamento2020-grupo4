using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject lostScreen;
    public GameObject pauseScreen;
    public GameObject wonScreen;
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
        GameManager.OnPause += PauseScreenOn;
        GameManager.OnResume += PauseScreenOff;
        GameManager.OnLost += LostGameScreenOn;
        GameManager.OnWon += WonGameScreenOn;
    }

    private void UnregisterEvents()
    {
        GameManager.OnPause -= PauseScreenOn;
        GameManager.OnResume -= PauseScreenOff;
        GameManager.OnLost -= LostGameScreenOn;
        GameManager.OnWon -= WonGameScreenOn;
    }


    private void PauseScreenOff()
    {
        pauseScreen.SetActive(false);
    }

    private void PauseScreenOn()
    {
        pauseScreen.SetActive(true);
    }

    private void LostGameScreenOn()
    {
        lostScreen.SetActive(true);
    }

    private void WonGameScreenOn()
    {
        wonScreen.SetActive(true);
    }

}

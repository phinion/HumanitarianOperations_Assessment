using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIChange : MonoBehaviour
{

    public bool isPaused = false;
    public GameObject pauseMenuUI;
    public GameObject InGameUI;

    //Switches between pause menu UI and in game UI
    public void changeMenu()
    {
        if (isPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
        isPaused = !isPaused;
    }

    //show pause menu ui
    void Pause()
    {
        InGameUI.SetActive(false);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    //Shows ingame ui
    void Resume()
    {
        pauseMenuUI.SetActive(false);
        InGameUI.SetActive(true);
        Time.timeScale = 1f;
    }
}

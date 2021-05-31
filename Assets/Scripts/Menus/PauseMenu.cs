using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MainMenu
{
    [SerializeField]
    private GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameControl.IsGamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameControl.IsGamePaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameControl.IsGamePaused = true;
    }

    public void LoadMainMenu()
    {
        sceneLoader.LoadMainMenu();
        GameControl.IsGamePaused = false;
    }
}

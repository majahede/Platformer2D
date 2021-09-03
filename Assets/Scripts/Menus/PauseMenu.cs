using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MainMenu
{
    [SerializeField]
    private GameObject pauseMenuUI;

    /// <summary>
    /// Update is called once per frame.
    /// </summary>
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

    /// <summary>
    /// Sets pause menu as not active an resumes game.
    /// </summary>
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameControl.IsGamePaused = false;
    }

    /// <summary>
    /// Sets pause menu as active and pauses game.
    /// </summary>
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameControl.IsGamePaused = true;
    }

    /// <summary>
    /// Loads start menu.
    /// </summary>
    public void LoadStartMenu()
    {
        Time.timeScale = 1f;
        GameControl.IsGamePaused = false;
        sceneLoader.LoadMainMenu();
    }
}

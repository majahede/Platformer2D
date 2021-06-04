using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenuUI;
    
    [SerializeField]
    private SceneLoader sceneLoader;

    /**
     * Update is called once per frame.
     */
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

    /*
     * Sets pause menu as not active an resumes game.
     */
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameControl.IsGamePaused = false;
    }

    /*
     * Sets pause menu as active and pauses game.
     */
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameControl.IsGamePaused = true;
    }

    /*
     * Update is called once per frame.
     */
    public void LoadMainMenu()
    {
        sceneLoader.LoadMainMenu();
        GameControl.IsGamePaused = false;
    }

    /*
     * Quits application.
     */
    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_STANDALONE
            Application.Quit();
        #elif UNITY_WEBGL
            Application.OpenURL("https://play.unity.com/u/majhed-zt");
        #endif
    }
}

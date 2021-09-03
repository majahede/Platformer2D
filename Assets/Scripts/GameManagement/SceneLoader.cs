using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    private Animator transition;

    private float transisitonTime = 1f;

    /// <summary>
    /// Loads the next scene.
    /// </summary>
    public void LoadNextScene()
    {
        Time.timeScale = 1f;
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        GameControl.IsGamePaused = false;
    }

    /// <summary>
    /// Reloads the active scene.
    /// </summary>
    public void LoadActiveScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameControl.IsGamePaused = false;
    }

    /// <summary>
    /// Loads start menu.
    /// </summary>
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Start Menu");
    }

    /// <summary>
    /// Loads scene after a specific time.
    /// </summary>
    /// <param name="sceneIndex">The scene to be loaded</param>
    IEnumerator LoadLevel(int sceneIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transisitonTime);

        SceneManager.LoadScene(sceneIndex);
    }
}

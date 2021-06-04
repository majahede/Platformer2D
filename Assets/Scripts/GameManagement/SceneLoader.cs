using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    private Animator transition;

    private float transisitonTime = 1f;

    /**
     * Loads the next scene.
     */
    public void LoadNextScene()
    {
        Time.timeScale = 1f;
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        GameControl.IsGamePaused = false;
    }

    /**
     * Reloads the active scene.
     */
    public void LoadActiveScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameControl.IsGamePaused = false;
    }

    /**
     * Loads start menu.
     */
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Start Menu");
    }

    /**
     * Loads scene after a specific time.
     */
    IEnumerator LoadLevel(int sceneIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transisitonTime);

        SceneManager.LoadScene(sceneIndex);
    }
}

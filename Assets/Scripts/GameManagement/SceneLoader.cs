using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    private Animator transition;

    private float transisitonTime = 1f;

    public void LoadNextScene()
    {
        Time.timeScale = 1f;
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        PauseMenu.GameIsPaused = false;
    }

    public void LoadActiveScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PauseMenu.GameIsPaused = false;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    IEnumerator LoadLevel(int sceneIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transisitonTime);

        SceneManager.LoadScene(sceneIndex);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
    public SceneLoader sceneLoader;
    public GameObject gameOverMenuUI;
    public Player player;
    private IEnumerator coroutine;

    // Update is called once per frame
    void Update()
    {
        coroutine = GameOverDelay(1.0f);

        if (player.PlayerDead())
        {
            StartCoroutine(coroutine);
        }
    }

    public void GameOver()
    {
        StartCoroutine(coroutine);
        gameOverMenuUI.SetActive(true);
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        sceneLoader.LoadActiveScene();
    }

    public void LoadMainMenu()
    {
        sceneLoader.LoadMainMenu();
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_STANDALONE
            Application.Quit();
        #elif UNITY_WEBGL
            Application.OpenURL("https://play.unity.com/mg/other/webglbuild2-1");
        #endif
    }

    private IEnumerator GameOverDelay(float time)
    {
        yield return new WaitForSeconds(time);
        Time.timeScale = 0;
        gameOverMenuUI.SetActive(true);
        PauseMenu.GameIsPaused = true;
    }
}

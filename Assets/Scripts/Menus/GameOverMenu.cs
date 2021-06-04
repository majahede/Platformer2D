using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
    private Player player;
    private IEnumerator coroutine;
    private SceneLoader sceneLoader;

    [SerializeField]
    private GameObject gameOverMenuUI;

    /**
     * Start is called before the first frame update.
     */
    void Start()
    {
        player = FindObjectOfType<Player>();
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    /**
     * Update is called once per frame.
     */
    void Update()
    {
        coroutine = GameOverDelay(1.0f);

        if (player.PlayerDead())
        {
            StartCoroutine(coroutine);
        }
    }

    /**
     * Reloads the current scene and unpauses game.
     */
    public void Retry()
    {
        GameControl.IsGamePaused = false;
        Time.timeScale = 1f;
        sceneLoader.LoadActiveScene();
    }

    /**
     * Loads main menu.
     */
    public void LoadMainMenu()
    {
        sceneLoader.LoadMainMenu();
    }

    /**
     * Activates game over menu after a specific time.
     */
    private IEnumerator GameOverDelay(float time)
    {
        yield return new WaitForSeconds(time);
        Time.timeScale = 0;
        gameOverMenuUI.SetActive(true);
    }

    /**
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

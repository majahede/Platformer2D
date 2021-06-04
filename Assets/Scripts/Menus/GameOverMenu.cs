using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMenu : MainMenu
{
    private Player player;
    private IEnumerator coroutine;

    [SerializeField]
    private GameObject gameOverMenuUI;

    /**
     * Start is called before the first frame update.
     */
    public override void Start()
    {
        base.Start();
        player = FindObjectOfType<Player>();
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
     * Loads start menu.
     */
    public void LoadStartMenu()
    {
        Time.timeScale = 1f;
        GameControl.IsGamePaused = false;
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
}

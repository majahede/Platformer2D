using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMenu : MainMenu
{
    private Player player;
    private IEnumerator coroutine;

    [SerializeField]
    private GameObject gameOverMenuUI;

    /// <summary>
    /// Start is called before the first frame update.
    /// </summary>
    public override void Start()
    {
        base.Start();
        player = FindObjectOfType<Player>();
    }

    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    void Update()
    {
        coroutine = GameOverDelay(1.0f);

        if (player.PlayerDead())
        {
            StartCoroutine(coroutine);
        }
    }

    /// <summary>
    /// Reloads the current scene and unpauses game.
    /// </summary>
    public void Retry()
    {
        GameControl.IsGamePaused = false;
        Time.timeScale = 1f;
        sceneLoader.LoadActiveScene();
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

    /// <summary>
    /// Activates game over menu after a specific time.
    /// </summary>
    /// <param name="time">The amount of time.</param>
    private IEnumerator GameOverDelay(float time)
    {
        yield return new WaitForSeconds(time);
        Time.timeScale = 0;
        gameOverMenuUI.SetActive(true);
    }
}

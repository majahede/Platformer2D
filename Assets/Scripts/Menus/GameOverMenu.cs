using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMenu : MainMenu
{
    private Player player;
    private IEnumerator coroutine;

    [SerializeField]
    private GameObject gameOverMenuUI;

    public override void Start()
    {
        base.Start();
        player = FindObjectOfType<Player>();
    }

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

    private IEnumerator GameOverDelay(float time)
    {
        yield return new WaitForSeconds(time);
        Time.timeScale = 0;
        gameOverMenuUI.SetActive(true);
        PauseMenu.GameIsPaused = true;
    }
}

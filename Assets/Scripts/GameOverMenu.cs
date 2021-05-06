using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
    public SceneLoader sceneLoader;
    public GameObject GameOverMenuUI;
    public Player player;

    // Update is called once per frame
    void Update()
    {
        if (player.PlayerDead())
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        GameOverMenuUI.SetActive(true);
    }

    public void LoadMainMenu()
    {
        sceneLoader.LoadMainMenu();
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}

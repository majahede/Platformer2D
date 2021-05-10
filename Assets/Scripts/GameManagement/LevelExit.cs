using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    private readonly float levelLoadDelay = 1f;
    public Player player;
    public GameSession gameSession;

    public SceneLoader sceneLoader;

    void OnTriggerEnter2D()
    {
        StartCoroutine(LoadNextLevel());
        player.SavePlayer();
        gameSession.SavePickups();
    }

    private IEnumerator LoadNextLevel()
    {
        yield return new WaitForSecondsRealtime(levelLoadDelay);
        sceneLoader.LoadNextScene();
    }
}

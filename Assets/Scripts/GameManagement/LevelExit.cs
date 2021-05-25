using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    public Player player;
    public GameSession gameSession;

    public SceneLoader sceneLoader;

    void OnTriggerEnter2D()
    {
        sceneLoader.LoadNextScene();
        player.SavePlayer();
        gameSession.SaveProgress();
    }
}

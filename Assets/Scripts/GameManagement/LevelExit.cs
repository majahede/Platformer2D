using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    private Player player;
    private GameSession gameSession;
    private SceneLoader sceneLoader;

    void Start() 
    {
        player = FindObjectOfType<Player>();
        gameSession = FindObjectOfType<GameSession>();
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    void OnTriggerEnter2D()
    {
        sceneLoader.LoadNextScene();
        player.SavePlayer();
        gameSession.SaveProgress();
    }
}

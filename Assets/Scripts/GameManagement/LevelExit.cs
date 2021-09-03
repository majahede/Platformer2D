using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    private Player player;
    private GameSession gameSession;
    private SceneLoader sceneLoader;

    /// <summary>
    /// Start is called before the first frame update.
    /// </summary>
    void Start()
    {
        player = FindObjectOfType<Player>();
        gameSession = FindObjectOfType<GameSession>();
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    /// <summary>
    /// Called when another object enters a trigger collider attached to this object.
    /// </summary>
    void OnTriggerEnter2D()
    {
        sceneLoader.LoadNextScene();
        player.SavePlayer();
        gameSession.SaveProgress();
    }
}

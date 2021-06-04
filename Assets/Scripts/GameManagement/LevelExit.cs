using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    private Player player;
    private GameSession gameSession;
    private SceneLoader sceneLoader;

    /**
     * Start is called before the first frame update.
     */
    void Start()
    {
        player = FindObjectOfType<Player>();
        gameSession = FindObjectOfType<GameSession>();
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    /**
     * Called when another object enters a trigger collider attached to this object.
     */
    void OnTriggerEnter2D()
    {
        sceneLoader.LoadNextScene();
        player.SavePlayer();
        gameSession.SaveProgress();
    }
}

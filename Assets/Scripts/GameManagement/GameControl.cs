using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public static GameControl Control;
    public static bool IsGamePaused = true;

    public int currentHealth = 100;
    public int coins;
    public int ammunition;
    public int enemyKills;
    public int patrolKills;

    void Awake()
    {
        if (Control == null)
        {
            DontDestroyOnLoad(gameObject);
            Control = this;
        }
        else if (Control != this)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0 && Control != null)
        {
            Destroy(gameObject);
        }
    }
}

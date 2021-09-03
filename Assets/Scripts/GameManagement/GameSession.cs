using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    private int coins;
    private int ammunition;
    private int enemyKills;
    private int patrolKills;

    [SerializeField]
    private Text coinCount;

    [SerializeField]
    private Text ammunitionCount;

    [SerializeField]
    private Text enemyKillCount;

    [SerializeField]
    private Text patrolKillCount;

    /// <summary>
    /// Start is called before the first frame update.
    /// </summary>
    void Start()
    {
        coins = GameControl.Control.coins;
        coinCount.text = coins.ToString();

        ammunition = GameControl.Control.ammunition;
        ammunitionCount.text = ammunition.ToString();

        enemyKills = GameControl.Control.enemyKills;
        enemyKillCount.text = enemyKills.ToString();

        patrolKills = GameControl.Control.patrolKills;
        patrolKillCount.text = patrolKills.ToString();
    }

    /// <summary>
    /// Saves progress to game control.
    /// </summary>
    public void SaveProgress()
    {
        GameControl.Control.coins = coins;
        GameControl.Control.ammunition = ammunition;
        GameControl.Control.enemyKills = enemyKills;
        GameControl.Control.patrolKills = patrolKills;
    }

    /// <summary>
    /// Add point to pickup counter.
    /// </summary>
    public void AddCoin()
    {
        coins++;
        coinCount.text = coins.ToString();
    }

    /// <summary>
    /// Gets current ammunition count.
    /// </summary>
    /// <returns>Current amount of ammunition</returns>
    public int GetAmmunition()
    {
        return ammunition;
    }

    /// <summary>
    /// Adds ammunition.
    /// </summary>
    public void AddAmmunition()
    {
        ammunition += 10;
        ammunitionCount.text = ammunition.ToString();
    }

    /// <summary>
    /// Removes ammunition.
    /// </summary>
    public void RemoveAmmunition()
    {
        ammunition--;
        ammunitionCount.text = ammunition.ToString();
    }

    /// <summary>
    /// Add kill to count.
    /// </summary>
    /// <param name="type">The type of enemy that is killed.</param>
    public void AddKill(string type)
    {
        if (type == "Patrol")
        {
            patrolKills++;
            patrolKillCount.text = patrolKills.ToString();
        }
        else
        {
            enemyKills++;
            enemyKillCount.text = enemyKills.ToString();
        }
    }
}


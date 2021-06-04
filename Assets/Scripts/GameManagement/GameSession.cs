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

    /**
     * Start is called before the first frame update.
     */
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

    /**
     * Saves progress to game control.
     */
    public void SaveProgress()
    {
        GameControl.Control.coins = coins;
        GameControl.Control.ammunition = ammunition;
        GameControl.Control.enemyKills = enemyKills;
        GameControl.Control.patrolKills = patrolKills;
    }

    /**
     * Add point to pickup counter.
     */
    public void AddCoin()
    {
        coins++;
        coinCount.text = coins.ToString();
    }

    /**
     * Gets current ammunition count.
     */
    public int GetAmmunition()
    {
        return ammunition;
    }

    /**
     * Adds ammunition.
     */
    public void AddAmmunition()
    {
        ammunition += 10;
        ammunitionCount.text = ammunition.ToString();
    }

    /**
     * Removes ammunition.
     */
    public void RemoveAmmunition()
    {
        ammunition--;
        ammunitionCount.text = ammunition.ToString();
    }

    /**
     * Add kill to count.
     */
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


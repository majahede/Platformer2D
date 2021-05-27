using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    public int coins;
    public int ammunition;
    public int enemyKills;
    public int patrolKills;

    [SerializeField]
    public Text coinCount;

    [SerializeField]
    public Text ammunitionCount;

    [SerializeField]
    public Text enemyKillCount;

    [SerializeField]
    public Text patrolKillCount;

    /**
     * Start is called before the first frame update
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

    public void AddAmmunition()
    {
        ammunition += 10;
        ammunitionCount.text = ammunition.ToString();
    }

    public void RemoveAmmunition()
    {
        ammunition--;
        ammunitionCount.text = ammunition.ToString();
    }

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

    public void SetValue(string type)
    {
    }
}


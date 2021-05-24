using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    [SerializeField]
    public Text coinCount;

    [SerializeField]
    public int coins;

    [SerializeField]
    public Text ammunitionCount;

    [SerializeField]
    public int ammunition;

    [SerializeField]
    public int slimeKills;

    [SerializeField]
    public Text slimeKillCount;

    [SerializeField]
    public int scorpioKills;

    [SerializeField]
    public Text scorpioKillCount;

    /**
     * Start is called before the first frame update
     */
    void Start()
    {
        coins = GameControl.Control.coins;
        coinCount.text = coins.ToString();

        ammunition = GameControl.Control.ammunition;
        ammunitionCount.text = ammunition.ToString();

        slimeKills = GameControl.Control.slimeKills;
        slimeKillCount.text = slimeKills.ToString();

        scorpioKills = GameControl.Control.scorpioKills;
        scorpioKillCount.text = scorpioKills.ToString();
    }


    public void SaveProgress()
    {
        GameControl.Control.coins = coins;
        GameControl.Control.ammunition = ammunition;
        GameControl.Control.slimeKills = slimeKills;
        GameControl.Control.scorpioKills = scorpioKills;
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
            scorpioKills++;
            scorpioKillCount.text = scorpioKills.ToString();
        }
        else
        {
            slimeKills++;
            slimeKillCount.text = slimeKills.ToString();
        }
    }
}


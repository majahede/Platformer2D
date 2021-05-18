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

    /**
     * Start is called before the first frame update
     */
    void Start()
    {
        coins = GameControl.Control.coins;
        coinCount.text = coins.ToString();

        ammunition = GameControl.Control.ammunition;
        ammunitionCount.text = ammunition.ToString();
    }

    void Update()
    {
        SavePickups();
    }

    public void SavePickups()
    {
        GameControl.Control.coins = coins;
        GameControl.Control.ammunition = ammunition;
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
}


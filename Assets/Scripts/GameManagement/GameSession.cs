using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    [SerializeField]
    public Text pickupCount;

    [SerializeField]
    public int pickups;

    /**
     * Start is called before the first frame update
     */
    void Start()
    {
        pickups = GameControl.Control.pickups;
        pickupCount.text = pickups.ToString();
    }

    public void SavePickups()
    {
        GameControl.Control.pickups = pickups;
    }

    /**
     * Add point to pickup counter.
     */
    public void AddPoint()
    {
        pickups++;
        pickupCount.text = pickups.ToString();
    }
}


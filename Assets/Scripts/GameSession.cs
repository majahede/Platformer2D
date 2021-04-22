using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    [SerializeField]
    public Text pickupCount;

    [SerializeField]
    private int pickups = 0;

    void Start()
    {
        pickupCount.text = pickups.ToString();
    }

    void OnTriggerEnter2D()
    {
        Destroy(gameObject);
    }

    public void AddPoint()
    {
        pickups++;
        pickupCount.text = pickups.ToString();
    }
}


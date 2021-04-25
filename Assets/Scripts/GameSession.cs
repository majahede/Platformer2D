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

    /**
     * Start is called before the first frame update
     */
    void Start()
    {
        pickupCount.text = pickups.ToString();
    }

    /**
     * Called when another objects enters a trigger collider attached to this object.
     */
    void OnTriggerEnter2D()
    {
        Destroy(gameObject);
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


using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
    public Player player;
    /**
     * Called when another objects enters a trigger collider attached to this object.
     */
    void OnTriggerEnter2D()
    {
        // When player collide with the object, add point and destroy object.
        if (gameObject.tag == "Pickup")
        {
            FindObjectOfType<GameSession>().AddPoint();
        }

        if (gameObject.tag == "LifePickup")
        {
            player.IncreaseHealth(10);
        }

        if (gameObject.tag == "Ammunition")
        {
            Debug.Log("Ammo!!");
        }

        Destroy(gameObject);
    }
}

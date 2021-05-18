using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
    public Player player;
    public Weapon weapon;

    /**
     * Called when another objects enters a trigger collider attached to this object.
     */
    void OnTriggerEnter2D()
    {
        // When player collide with the object, add point and destroy object.
        if (gameObject.tag == "Pickup")
        {
            FindObjectOfType<AudioManager>().Play("Coin");
            FindObjectOfType<GameSession>().AddPoint();
        }

        if (gameObject.tag == "LifePickup")
        {
            player.IncreaseHealth(10);
        }

        if (gameObject.tag == "Ammunition")
        {
            weapon.AddBullets(10);
        }

        Destroy(gameObject);
    }
}

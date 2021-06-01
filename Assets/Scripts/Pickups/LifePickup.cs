using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class LifePickup : Pickup
{
    private int health = 10;

    /**
     * Called when another objects enters a trigger collider attached to this object.
     */
    public override void OnTriggerEnter2D()
    {
        base.OnTriggerEnter2D();
        PlaySound("Heart");
        player.IncreaseHealth(health);
    }
}

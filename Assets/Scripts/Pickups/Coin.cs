using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Coin : Pickup
{
    /**
     * Called when another objects enters a trigger collider attached to this object.
     */
    public override void OnTriggerEnter2D()
    {
        base.OnTriggerEnter2D();
        gameSession.AddCoin();
        PlaySound("Coin");
    }
}

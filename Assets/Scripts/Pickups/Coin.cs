using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Coin : Pickup
{
    /// <summary>
    /// Called when another object enters a trigger collider attached to this object.
    /// </summary>
    public override void OnTriggerEnter2D()
    {
        base.OnTriggerEnter2D();
        gameSession.AddCoin();
        PlaySound("Coin");
    }
}

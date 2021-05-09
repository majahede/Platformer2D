using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
    /**
     * Called when another objects enters a trigger collider attached to this object.
     */
    void OnTriggerEnter2D()
    {
        // When player collide with the object, add point and destroy object.
        FindObjectOfType<GameSession>().AddPoint();
        Destroy(gameObject);
    }
}

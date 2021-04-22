using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
    void OnTriggerEnter2D()
    {
        FindObjectOfType<GameSession>().AddPoint();
        Destroy(gameObject);
    }
}

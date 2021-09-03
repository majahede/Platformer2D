using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    private Player player;

    /// <summary>
    /// Start is called before the first frame update.
    /// </summary>
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    /// <summary>
    /// Called when another object enters a trigger collider attached to this object.
    /// </summary>
    void OnTriggerEnter2D()
    {
        player.SetCurrentHealth(0);
    }
}

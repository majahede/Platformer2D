using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    private Player player;

    /**
     * Start is called before the first frame update.
     */
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    /**
     * Called when another objects enters a trigger collider attached to this object.
     */
    void OnTriggerEnter2D()
    {
        player.SetCurrentHealth(0);
    }
}

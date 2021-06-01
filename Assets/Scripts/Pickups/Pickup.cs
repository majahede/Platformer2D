using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
    protected GameSession gameSession;
    protected Player player;

    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        player = FindObjectOfType<Player>();
    }

    /**
     * Called when another objects enters a trigger collider attached to this object.
     */
    public virtual void OnTriggerEnter2D()
    {
        Destroy(gameObject);
    }

    public void PlaySound(string sound)
    {
        FindObjectOfType<GameAudioManager>().Play(sound);
    }
}

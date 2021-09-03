using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
    protected GameSession gameSession;
    protected Player player;

    /// <summary>
    /// Start is called before the first frame update.
    /// </summary>
    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        player = FindObjectOfType<Player>();
    }

    /// <summary>
    /// Called when another object enters a trigger collider attached to this object.
    /// </summary>
    public virtual void OnTriggerEnter2D()
    {
        Destroy(gameObject);
    }

    /// <summary>
    /// Plays a specified sound.
    /// </summary>
    /// <param name="sound">The sound that should be played.</param>
    public void PlaySound(string sound)
    {
        FindObjectOfType<GameAudioManager>().Play(sound);
    }
}

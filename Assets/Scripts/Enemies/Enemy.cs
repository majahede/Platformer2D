using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int health = 100;

    /// <summary>
    /// Makes the enemy take damage.
    /// </summary>
    /// <param name="damage">The amount of damage.</param>
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    /// <summary>
    /// Destroys game object when health is below zero.
    /// </summary>
    public void Die()
    {
        FindObjectOfType<GameAudioManager>().Play("Enemy");
        FindObjectOfType<GameSession>().AddKill(gameObject.name);
        Destroy(gameObject);
    }

    /// <summary>
    /// Gets enemy health.
    /// </summary>
    /// <returns>The current health</returns>
    public int GetHealth()
    {
        return health;
    }

    /// <summary>
    /// Sets enemy health.
    /// </summary>
    /// <param name="value">The current health</param>
    public void SetHealth(int value)
    {
        health = value;
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int health = 100;

    /**
     * Makes the enemy take damage.
     */
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    /**
     * Destroys game object when health is below zero.
     */
    public void Die()
    {
        FindObjectOfType<GameAudioManager>().Play("Enemy");
        FindObjectOfType<GameSession>().AddKill(gameObject.name);
        Destroy(gameObject);
    }

    /**
     * Gets enemy health.
     */
    public int GetHealth()
    {
        return health;
    }

    /**
     * Sets enemy health.
     */
    public void SetHealth(int value)
    {
        health = value;
    }
}


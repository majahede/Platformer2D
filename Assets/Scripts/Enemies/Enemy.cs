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
    * Destroys game object when enemey health is below zero.
    */
    public void Die()
    {
        if (health <= 0)
        {
            FindObjectOfType<GameAudioManager>().Play("Enemy");
            Destroy(gameObject);
            FindObjectOfType<GameSession>().AddKill(gameObject.name);
        }
    }
}


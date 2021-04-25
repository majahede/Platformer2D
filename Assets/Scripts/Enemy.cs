using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public int damage = 20;

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
     * When called object gets destroyed.
     */
    public void Die()
    {
        Destroy(gameObject);
    }
}

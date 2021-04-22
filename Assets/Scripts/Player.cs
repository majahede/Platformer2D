using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth = 0;
    public HealthBar healthBar;
    private CapsuleCollider2D bodyCollider;
    private float curTime = 0;
    public float nextDamage = 1;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        bodyCollider = this.gameObject.GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerDead();
        EnemyCollision();
    }

    private void EnemyCollision()
    {
        if (curTime <= 0)
        {
            if (bodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemy")))
            {
                TakeDamage(20);
            }

            curTime = nextDamage;
        }
        else
        {
            curTime -= Time.deltaTime + Time.deltaTime;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    private void PlayerDead()
    {
        if (currentHealth <= 0)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }
}

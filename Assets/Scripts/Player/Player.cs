using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int maxHealth = 100;
    private int currentHealth = 100;

    [SerializeField]
    private HealthBar healthBar;

    private CapsuleCollider2D bodyCollider;
    private Animator anim;
    private float currentTime;

    /// <summary>
    /// Start is called before the first frame update.
    /// </summary>
    void Start()
    {
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(GameControl.Control.currentHealth);
        bodyCollider = this.gameObject.GetComponent<CapsuleCollider2D>();
        anim = this.gameObject.GetComponent<Animator>();
        currentHealth = GameControl.Control.currentHealth;
        GameControl.IsGamePaused = false;
    }

    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    void Update()
    {
        PlayerDead();
        EnemyCollision();
    }

    /// <summary>
    /// Save player data to game control.
    /// </summary>
    public void SavePlayer()
    {
        GameControl.Control.currentHealth = currentHealth;
    }

    /// <summary>
    ///  Get player health.
    /// </summary>
    /// <returns>The current amount of health</returns>
    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    /// <summary>
    /// Set player health.
    /// </summary>
    /// <param name="value">The current amount of health</param>
    public void SetCurrentHealth(int value)
    {
        currentHealth = value;
    }

    /// <summary>
    /// Checks if Player is colliding with enemy and makes player take damage continously.
    /// </summary>
    private void EnemyCollision()
    {
        float nextDamage = 1;

        if (currentTime <= 0)
        {
            if (bodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemy")) && currentHealth > 0)
            {
                TakeDamage(20);
            }

            currentTime = nextDamage;
        }
        else
        {
            currentTime -= Time.deltaTime + Time.deltaTime + Time.deltaTime;
        }
    }

    /// <summary>
    /// When called player takes damage.
    /// </summary>
    /// <param name="damage">The amount of damage</param>
    public void TakeDamage(int damage)
    {
        FindObjectOfType<GameAudioManager>().Play("Hurt");
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    /// <summary>
    /// Called when player pick up healing object.
    /// </summary>
    /// <param name="health">The amount of health</param>
    public void IncreaseHealth(int health)
    {
        currentHealth += health;
        healthBar.SetHealth(currentHealth);
    }

    /// <summary>
    /// If players health is below 0 sets player to dead.
    /// </summary>
    /// <returns>A boolean with information about if the player is dead or not.</returns>
    public bool PlayerDead()
    {
        if (currentHealth <= 0)
        {
            GameControl.IsGamePaused = true;
            anim.SetBool("isDead", true);
            return true;
        }
        anim.SetBool("isDead", false);
        return false;
    }
}

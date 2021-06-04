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

    /**
     * Start is called before the first frame update
     */
    void Start()
    {
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(GameControl.Control.currentHealth);
        bodyCollider = this.gameObject.GetComponent<CapsuleCollider2D>();
        anim = this.gameObject.GetComponent<Animator>();
        currentHealth = GameControl.Control.currentHealth;
        GameControl.IsGamePaused = false;
    }

    /**
     *  Update is called once per frame.
     */
    void Update()
    {
        PlayerDead();
        EnemyCollision();
    }

    /**
     *  Save player data to game control.
     */
    public void SavePlayer()
    {
        GameControl.Control.currentHealth = currentHealth;
    }

    /**
     *  Get player health.
     */
    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    /**
     *  Set player health.
     */
    public void SetCurrentHealth(int value)
    {
        currentHealth = value;
    }

    /**
     *  Checks if Player is colliding with enemy and makes player take damage continously.
     */
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

    /**
     *  When called player takes damage.
     */
    public void TakeDamage(int damage)
    {
        FindObjectOfType<GameAudioManager>().Play("Hurt");
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    /**
     *  Called when player pick up healing object.
     */
    public void IncreaseHealth(int health)
    {
        currentHealth += health;
        healthBar.SetHealth(currentHealth);
    }

    /**
     * If players health is below 0 sets player to dead.
     */
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

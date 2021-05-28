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
    }

    /**
     *  Update is called once per frame.
     */
    void Update()
    {
        PlayerDead();
        EnemyCollision();
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            TakeDamage(50);
        }
    }

    // Save data to game control
    public void SavePlayer()
    {
        GameControl.Control.currentHealth = currentHealth;
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    public void SetCurrentHealth(int value)
    {
        currentHealth = value;
    }

    /**
     *  Checks if Player is colliding with enemy.
     */
    private void EnemyCollision()
    {
        float nextDamage = 1;

        if (currentTime <= 0)
        {
            if (bodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemy")))
            {
                TakeDamage(20);
            }

            currentTime = nextDamage;
        }
        else
        {
            currentTime -= Time.deltaTime + Time.deltaTime;
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
     *  When called player pick up healing object.
     */
    public void IncreaseHealth(int health)
    {
        currentHealth += health;
        healthBar.SetHealth(currentHealth);
    }

    /**
     * If players health is below 0, player is dead.
     */
    public bool PlayerDead()
    {
        if (currentHealth <= 0)
        {
            anim.SetTrigger("die");
            return true;
        }
        return false;
    }
}

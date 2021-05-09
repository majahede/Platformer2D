using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth = 100;
    public HealthBar healthBar;
    private CapsuleCollider2D bodyCollider;
    private float curTime = 0;
    public float nextDamage = 1;
    private Animator anim;
    public int level = 1;

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
        level = SceneManager.GetActiveScene().buildIndex;
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

    /**
     *  Checks if Player is colliding with enemy.
     */
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

    /**
     *  When called player takes damage.
     */
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
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

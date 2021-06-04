using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : Enemy
{
    private Rigidbody2D rb;
    private readonly float movementSpeed = 1f;
    private bool isFacingLeft = true;

    /**
     * Start is called before the first frame update.
     */
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    /**
     * Update is called once per frame.
     */
    void Update()
    {
        if (isFacingLeft)
        {
            rb.velocity = new Vector2(-movementSpeed, 0f);
        }
        else
        {
            rb.velocity = new Vector2(movementSpeed, 0f);
        }
    }

    /**
     * Called when another collider has stopped touching the trigger.
     */
    void OnTriggerExit2D(Collider2D collision)
    {
        // Patrol changes direction after colliding with wall.
        if (collision.name == "Foreground")
        {
            if (isFacingLeft)
            {
                transform.Rotate(0f, 180f, 0);
                isFacingLeft = false;
            }
            else
            {
                transform.Rotate(0f, 180f, 0);
                isFacingLeft = true;
            }
        }
    }
}


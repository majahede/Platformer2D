using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : Enemy
{
    private Rigidbody2D rb;
    private readonly float movementSpeed = 1f;
    private bool isFacingLeft = true;

    /// <summary>
    /// Start is called before the first frame update.
    /// </summary>
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Update is called once per frame.
    /// </summary>
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

    /// <summary>
    /// Called when another collider has stopped touching the trigger.
    /// </summary>
    /// <param name="collision">The other collider</param>
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


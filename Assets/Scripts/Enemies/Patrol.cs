using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Patrol : Enemy
{
    private Rigidbody2D rb;
    public float movementSpeed = 1f;
    private bool isFacingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isFacingRight)
        {
            rb.velocity = new Vector2(movementSpeed, 0f);
        }
        else
        {
            rb.velocity = new Vector2(-movementSpeed, 0f);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Foreground")
        {
            if (isFacingRight)
            {
                transform.Rotate(0f, 180f, 0);
                isFacingRight = false;
            }
            else
            {
                transform.Rotate(0f, 180f, 0);
                isFacingRight = true;
            }
        }
    }
}

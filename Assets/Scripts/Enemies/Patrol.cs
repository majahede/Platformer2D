using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Patrol : Enemy
{
    private Rigidbody2D rb;
    public float movementSpeed = 1f;
    private bool isFacingLeft = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

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

    void OnTriggerExit2D(Collider2D collision)
    {
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


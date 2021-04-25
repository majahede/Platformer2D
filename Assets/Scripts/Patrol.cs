using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Patrol : Enemy
{
    public float movementSpeed = 5;
    public float distance = 2f;

    public bool movingRight = true;
    public Transform groundChecker;

    /**
     * Update is called once per frame.
     */
    void Update()
    {
        Move();
    }

    public void Move()
    {
        transform.Translate(Vector2.right * movementSpeed * Time.deltaTime);
        // A raycast with its origin, direction and length.
        var layerMask = LayerMask.GetMask("Ground");
        var groundInfo = Physics2D.Raycast(groundChecker.position, Vector2.down, distance, layerMask);

        if (!groundInfo.collider)
        {
            if (movingRight)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }
}

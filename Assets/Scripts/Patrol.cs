using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Patrol : Enemy
{
    public float movementSpeed = 5;
    public float distance = 2f;

    private bool movingRight = true;
    public Transform groundChecker;

    [SerializeField]
    private bool isGrounded = false;

    public float checkGroundRadius;
    public LayerMask groundLayer;

    /**
     * Update is called once per frame.
     */
    void Update()
    {
        IsGrounded();
        Debug.Log(isGrounded);
        transform.Translate(Vector2.right * movementSpeed * Time.deltaTime);

        /*RaycastHit2D groundInfo = Physics2D.Raycast(groundChecker.position, Vector2.down, distance);

        if (groundInfo.collider)
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
        }*/
    }

    /**
     * Check if object is grounded.
     */
    public void IsGrounded()
    {
        var collider = Physics2D.OverlapCircle(groundChecker.position, checkGroundRadius, groundLayer);
        if (collider != null)
        {
            isGrounded = true;
        } else 
        {
            isGrounded = false;
        }
    }
}

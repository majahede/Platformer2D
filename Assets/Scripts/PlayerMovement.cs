using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private float xMovement;

    [SerializeField]
    private float maxYVelocity;

    [SerializeField]
    public float movementSpeed = 10f;

    [SerializeField]
    private bool isGrounded = false;

    [SerializeField]
    public Player player;

    [SerializeField]
    public float jumpForce = 10f;

    [SerializeField]
    public float checkGroundRadius;

    [SerializeField]
    public Transform groundChecker;

    [SerializeField]
    public LayerMask groundLayer;

    [SerializeField]
    public float fallMultiplier = 2.5f;
    [SerializeField]
    public float lowJumpMultiplier = 2f;

    [SerializeField]
    public float timeDifference;

    private float lastTimeGrounded;
    private bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        anim = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        xMovement = Input.GetAxisRaw("Horizontal");
        Jump();
        ChangeFallSpeed();
        IsGrounded();
        Flip();
        HighFall();
    }

    void FixedUpdate()
    {
        Run();
    }

    public void Jump()
    {
        if (Input.GetButtonDown("Jump") && (isGrounded || Time.time - lastTimeGrounded <= timeDifference))
        {
            var movement = new Vector2(rb.velocity.x, jumpForce);
            rb.velocity = movement;
        }
    }

    public void Run()
    {
        var movement = new Vector2(xMovement * movementSpeed, rb.velocity.y);
        rb.velocity = movement;

        if (Mathf.Abs(xMovement) > 0.05)
        { // Mathf.Abs gör om negtiv till positiv, därför gäller detta även när spelaren går åt vänster
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }

    public void ChangeFallSpeed()
    {
        // if the player is falling
        if (rb.velocity.y < 0)
        {
            rb.gravityScale = fallMultiplier;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        { // Low jump.
            rb.gravityScale = lowJumpMultiplier;
        }
        else
        {
            rb.gravityScale = 1;
        }
    }

    public void HighFall()
    {
        if (rb.velocity.y < maxYVelocity)
        {
            maxYVelocity = rb.velocity.y;
        }

        if (maxYVelocity <= -25 && rb.velocity.y == 0)
        {
            player.TakeDamage(20);
            maxYVelocity = 0;
        }
    }

    public void IsGrounded()
    {
        var collider = Physics2D.OverlapCircle(groundChecker.position, checkGroundRadius, groundLayer);
        if (collider != null)
        {
            isGrounded = true;
        }
        else
        {
            if (isGrounded)
            {
                lastTimeGrounded = Time.time;
            }
            isGrounded = false;
        }
    }

    public void Flip()
    {
        // flip sprite
        if (xMovement > 0f && !facingRight)
        {
            transform.Rotate(0f, 180f, 0);
            facingRight = true;
            //transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (xMovement < 0f && facingRight)
        {
            transform.Rotate(0f, 180f, 0);
            //transform.localScale = new Vector3(-1f, 1f, 1f);
            facingRight = false;
        }

        anim.SetBool("isGrounded", isGrounded);
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private Player player;
    private CapsuleCollider2D bodyCollider;

    [SerializeField]
    private Transform groundChecker;

    private float xMovement;
    private float yMovement;
    private float maxYVelocity;
    private float movementSpeed = 9f;

    private bool isGrounded;
    private float lastTimeGrounded;
    private int additionalJumps;
    private int defaultAdditionalJumps = 1;
    private bool facingRight = true;

    /**
     * Start is called before the first frame update
     */
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        anim = this.gameObject.GetComponent<Animator>();
        bodyCollider = this.gameObject.GetComponent<CapsuleCollider2D>();
        player = this.gameObject.GetComponent<Player>();
    }

    /**
     * Update is called once per frame.
     */
    void Update()
    {
        xMovement = Input.GetAxisRaw("Horizontal");
        yMovement = Input.GetAxisRaw("Vertical");
        Jump();
        ChangeFallSpeed();
        IsGrounded();
        HighFall();
        ClimbLadder();
    }

    /**
     * FixedUpdate is called every fixed frame-rate frame.
     */
    void FixedUpdate()
    {
        Run();
        Flip();
    }

    /**
     * Makes player jump.
     */
    public void Jump()
    {
        float jumpForce = 10f;

        // Check if jump button is pressed and if player is grounded. 
        if (!GameControl.IsGamePaused && Input.GetButtonDown("Jump") && (isGrounded || Time.time - lastTimeGrounded <= 0 || additionalJumps > 0))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            additionalJumps--;
        }
    }

    /**
     * Makes player run.
     */
    public void Run()
    {
        if (!GameControl.IsGamePaused)
        {
            rb.velocity = new Vector2(xMovement * movementSpeed, rb.velocity.y);

            if (Mathf.Abs(xMovement) > 0.05)
            {
                anim.SetBool("isRunning", true);
            }
            else
            {
                anim.SetBool("isRunning", false);
            }
        }
    }

    /**
     * Makes player climb ladder.
     */
    public void ClimbLadder()
    {
        if (!bodyCollider.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            anim.SetBool("isClimbing", false);
            return;
        }

        float climbSpeed = 5f;

        rb.velocity = new Vector2(rb.velocity.x, yMovement * climbSpeed);
        rb.gravityScale = 0f;

        anim.SetBool("isClimbing", true);
    }

    /**
     * Change gravity scale when falling.
     */
    public void ChangeFallSpeed()
    {
        float fallMultiplier = 2.5f;
        float lowJumpMultiplier = 2f;

        // if the player is falling
        if (rb.velocity.y < 0)
        {
            rb.gravityScale = fallMultiplier;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            // Low jump.
            rb.gravityScale = lowJumpMultiplier;
        }
        else
        {
            rb.gravityScale = 1;
        }
    }

    /**
     * Player takes damage when falling from heights.
     */
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

    /**
     * Checks if player is grounded.
     */
    public void IsGrounded()
    {
        float checkGroundRadius = 0.05f;

        var groundCollider = Physics2D.OverlapCircle(groundChecker.position, checkGroundRadius, LayerMask.GetMask("Ground"));
        var enemyCollider = Physics2D.OverlapCircle(groundChecker.position, checkGroundRadius, LayerMask.GetMask("Enemy"));

        if (groundCollider != null || enemyCollider != null)
        {
            isGrounded = true;
            additionalJumps = defaultAdditionalJumps;
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

    /**
     * Rotates player when changing direction.
     */
    public void Flip()
    {
        if (!GameControl.IsGamePaused)
        {
            if (xMovement > 0f && !facingRight)
            {
                transform.Rotate(0f, 180f, 0);
                facingRight = true;
            }
            else if (xMovement < 0f && facingRight)
            {
                transform.Rotate(0f, 180f, 0);
                facingRight = false;
            }

            anim.SetBool("isGrounded", isGrounded);
        }
    }
}


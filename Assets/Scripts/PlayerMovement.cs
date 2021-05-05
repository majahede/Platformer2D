using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private float xMovement;
    private float yMovement;

    [SerializeField]
    private float maxYVelocity;

    public float movementSpeed = 10f;

    [SerializeField]
    private bool isGrounded = false;

    public Player player;
    public float jumpForce = 10f;
    public float checkGroundRadius;
    public Transform groundChecker;
    public LayerMask groundLayer;
    public LayerMask enemyLayer;

    public int additionalJumps;
    public int defaultAdditionalJumps = 1;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public float timeDifference;
    private float lastTimeGrounded;
    private CapsuleCollider2D bodyCollider;
    private bool facingRight = true;

  //  float gravityScaleAtStart;

    /**
     * Start is called before the first frame update
     */
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        anim = this.gameObject.GetComponent<Animator>();
        bodyCollider = this.gameObject.GetComponent<CapsuleCollider2D>();
      //  gravityScaleAtStart = rb.gravityScale;
    }

    /**
     * Update is called once per frame.
     */
    void Update()
    {
        xMovement = Input.GetAxisRaw("Horizontal");
        yMovement = Input.GetAxisRaw("Vertical");
        Run();
        Jump();
        ChangeFallSpeed();
        IsGrounded();
        Flip();
        HighFall();
        ClimbLadder();
    }

    /**
     * Update is called once per frame.
     */
    void FixedUpdate()
    {
        Run();
    }

    /**
     * Makes player jump.
     */
    public void Jump()
    {
        // Check if jump button is pressed and if player is grounded. 
        if (Input.GetButtonDown("Jump") && (isGrounded || Time.time - lastTimeGrounded <= timeDifference || additionalJumps > 0))
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

    public void ClimbLadder()
    {
        if (!bodyCollider.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            anim.SetBool("isClimbing", false);
       //     rb.gravityScale = gravityScaleAtStart;
            return;
        }

        float climbSpeed = 5f;

        Vector2 climbVelocity = new Vector2(rb.velocity.x, yMovement * climbSpeed);
        rb.velocity = climbVelocity;
        rb.gravityScale = 0f;
       // Debug.Log(Mathf.Abs(rb.velocity.y));

       // bool hasVerticalSpeed = Mathf.Abs(rb.velocity.y) > Mathf.Epsilon;
        anim.SetBool("isClimbing", true);
    }

    /**
     * Change gravity scale when falling.
     */
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
        var groundCollider = Physics2D.OverlapCircle(groundChecker.position, checkGroundRadius, groundLayer);
        var enemyCollider = Physics2D.OverlapCircle(groundChecker.position, checkGroundRadius, enemyLayer);
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


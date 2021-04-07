using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
  private Rigidbody2D rb;

  [SerializeField] float movementSpeed = 10f;
  
  bool isGrounded = false;
  private float xMovement;

  [SerializeField] float jumpForce = 10f;

  [SerializeField] float checkGroundRadius; 
  [SerializeField] Transform groundChecker; 
  [SerializeField] LayerMask groundLayer;

  [SerializeField] float fallMultiplier = 2.5f;
  [SerializeField] float lowJumpMultiplier = 2f;

  [SerializeField] float timeDifference;
  float lastTimeGrounded;
   
  // Start is called before the first frame update
  void Start() {
    rb = this.gameObject.GetComponent<Rigidbody2D>();
  }

  // Update is called once per frame
  void Update() {
    xMovement = Input.GetAxisRaw("Horizontal");
    Jump();
    changeFallSpeed();
    IsGrounded();
  }

  private void FixedUpdate() {
    move();
  }

  private void Jump() {
    if (Input.GetButtonDown("Jump") && (isGrounded || Time.time - lastTimeGrounded <= timeDifference)) {
      Vector2 movement = new Vector2(rb.velocity.x, jumpForce);
      rb.velocity = movement;
    }  
  }

  private void move() {
    Vector2 movement = new Vector2(xMovement *  movementSpeed , rb.velocity.y);
    rb.velocity = movement;
  }

  private void changeFallSpeed() {
    // if the player is falling
    if (rb.velocity.y < 0) { 
        rb.gravityScale = fallMultiplier;
    } else if (rb.velocity.y > 0 && !Input.GetButton("Jump")) { // Low jump.
        rb.gravityScale = lowJumpMultiplier;
    } else  {
      rb.gravityScale = 1;
    }
  }

  public void IsGrounded() {
    Collider2D collider = Physics2D.OverlapCircle(groundChecker.position, checkGroundRadius, groundLayer);
    if (collider != null) {
      isGrounded = true;
    } else {
        if(isGrounded) {
          lastTimeGrounded = Time.time;
        }
        isGrounded = false;
    }
  }
}


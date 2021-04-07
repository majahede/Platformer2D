using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
  private Rigidbody2D rb;

  float movementSpeed = 10f;
  float xMovement;

  public float jumpForce = 10f;

  public float checkGroundRadius; 
  public Transform groundChecker; 
  public LayerMask groundLayer;

  public float fallMultiplier = 2.5f;
  public float lowJumpMultiplier = 2f;
   
  // Start is called before the first frame update
  void Start() {
    rb = this.gameObject.GetComponent<Rigidbody2D>();
  }

  // Update is called once per frame
  void Update() {
    xMovement = Input.GetAxisRaw("Horizontal");
    Jump();
    changeFallSpeed();
  }

  private void FixedUpdate() {
    Vector2 movement = new Vector2(xMovement *  movementSpeed , rb.velocity.y);
    rb.velocity = movement;
  }

  private void Jump() {
    if (Input.GetButtonDown("Jump") && IsGrounded()) {
    Vector2 movement = new Vector2(rb.velocity.x, jumpForce);
    rb.velocity = movement;
    }  
  }

  private void changeFallSpeed() {
    // if the player is falling
    if (rb.velocity.y < 0) { 
        rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
    } else if (rb.velocity.y > 0 && !Input.GetButton("Jump")) { // Low jump.
        rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
    }   
  }

  public bool IsGrounded() {
    Collider2D collider = Physics2D.OverlapCircle(groundChecker.position, checkGroundRadius, groundLayer);
    if (collider != null) {
      return true;
    } 
    return false;
  }
}


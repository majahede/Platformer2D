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
   
   
    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        xMovement = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump") && IsGrounded()) {
        Jump();
        } 
    }

    private void FixedUpdate() {
        Vector2 movement = new Vector2(xMovement *  movementSpeed , rb.velocity.y);

        rb.velocity = movement;
    }

    void Jump() {
      Vector2 movement = new Vector2(rb.velocity.x, jumpForce);
      rb.velocity = movement;
    }

    public bool IsGrounded() {
      Collider2D collider = Physics2D.OverlapCircle(groundChecker.position, checkGroundRadius, groundLayer);
      if (collider != null) {
        return true;
      } 
    return false;
  }
}

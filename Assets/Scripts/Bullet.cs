using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb;
    private CapsuleCollider2D bodyCollider;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        bodyCollider = this.gameObject.GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
        if (bodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemy")))
        {
            Debug.Log("hej");
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        // Destroy(gameObject);
    }

    void OnCollsionEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        // Destroy(gameObject);
    }
}

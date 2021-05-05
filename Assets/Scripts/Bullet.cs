using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb;
    public int damage = 30;

    /**
     * Start is called before the first frame update.
     */
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    /**
     * Called when another objects enters a trigger collider attached to this object.
     */
    void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = collision.GetComponent<Enemy>();

        // If the hit object is of type enemy it takes damage.
        enemy?.TakeDamage(damage);
        Destroy(gameObject);
    }
}

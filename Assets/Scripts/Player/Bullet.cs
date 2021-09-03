using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 10f;
    private Rigidbody2D rb;
    private int damage = 30;

    /// <summary>
    /// Start is called before the first frame update.
    /// </summary>
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;

        DestroyBullet(3f);
    }

    /// <summary>
    /// Called when another object enters a trigger collider attached to this object.
    /// </summary>
    /// <param name="collision">The other collider.</param>
    void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = collision.GetComponent<Enemy>();

        // If the hit object is of type enemy it takes damage.
        enemy?.TakeDamage(damage);
        DestroyBullet(0f);
    }

    /// <summary>
    /// Removes Bullet object after an amount of time.
    /// </summary>
    /// <param name="time">The amount of time.</param>
    public void DestroyBullet(float time)
    {
        Destroy(gameObject, time);
    }
}

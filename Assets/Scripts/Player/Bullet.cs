using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 10f;
    private Rigidbody2D rb;
    private int damage = 30;

    /**
     * Start is called before the first frame update.
     */
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;

        DestroyBullet(3f);
    }

    /**
     * Called when another objects enters a trigger collider attached to this object.
     */
    void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = collision.GetComponent<Enemy>();

        // If the hit object is of type enemy it takes damage.
        enemy?.TakeDamage(damage);
        DestroyBullet(0f);
    }

    /**
     * Removes Bullet object after an amount of time..
     */
    public void DestroyBullet(float time)
    {
        Destroy(gameObject, time);
    }
}

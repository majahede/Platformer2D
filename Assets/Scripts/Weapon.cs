using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet;
    private Animator anim;

    void Start() 
    {
        anim = this.gameObject.GetComponent<Animator>();
    }
    /**
     * Update is called once per frame.
     */
    void Update()
    {
        Shoot();
    }

    public void Shoot()
    {
        if (!Input.GetButtonDown("Fire1"))
        {
            anim.SetBool("isShooting", false);
            return;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            // Spawns object at the chosen place (The object to spawn, where to spawn object, which rotation)
            Instantiate(bullet, firePoint.position, firePoint.rotation);
            anim.SetBool("isShooting", true);
        }
    }
}

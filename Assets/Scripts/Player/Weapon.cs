using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet;
    private Animator anim;
    private int ammo = 10;

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
        if (!PauseMenu.GameIsPaused)
        {
            if (!Input.GetButtonDown("Fire1"))
            {
                anim.SetBool("isShooting", false);
                return;
            }

            if (Input.GetButtonDown("Fire1") && ammo > 0)
            {
                // Spawns a specific object at a chosen place.
                Instantiate(bullet, firePoint.position, firePoint.rotation);
                anim.SetBool("isShooting", true);
                ammo--;
            }
        }
    }

    public void AddBullets(int bullets)
    {
        ammo += bullets;
    }
}

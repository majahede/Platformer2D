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
        var gameSession = FindObjectOfType<GameSession>();
        if (!PauseMenu.GameIsPaused)
        {
            if (!Input.GetButtonDown("Fire1"))
            {
                anim.SetBool("isShooting", false);
                return;
            }

            if (Input.GetButtonDown("Fire1") && gameSession.ammunition > 0)
            {
                // Spawns a specific object at a chosen place.
                FindObjectOfType<AudioManager>().Play("Shoot");
                Instantiate(bullet, firePoint.position, firePoint.rotation);
                anim.SetBool("isShooting", true);
                gameSession.RemoveAmmunition();
                Debug.Log(gameSession.ammunition);
            }
        }
    }
}

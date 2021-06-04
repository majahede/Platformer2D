using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private Transform firePoint;

    [SerializeField]
    private GameObject bullet;

    private Animator anim;

    /**
     * Start is called before the first frame update.
     */
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

    /**
     * When pressing fire button, a bullet is spawned.
     */
    public void Shoot()
    {
        var gameSession = FindObjectOfType<GameSession>();

        if (!GameControl.IsGamePaused)
        {
            if (!Input.GetButtonDown("Fire1"))
            {
                anim.SetBool("isShooting", false);
                return;
            }

            if (Input.GetButtonDown("Fire1") && gameSession.GetAmmunition() > 0)
            {
                FindObjectOfType<GameAudioManager>().Play("Shoot");

                // Spawns a specific object at a chosen place.
                Instantiate(bullet, firePoint.position, firePoint.rotation);
                anim.SetBool("isShooting", true);
                gameSession.RemoveAmmunition();
            }
        }
    }
}

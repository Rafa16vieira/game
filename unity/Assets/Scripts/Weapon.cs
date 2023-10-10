using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public GameObject shooter;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public AudioSource shootSound;

    void Start(){
        shootSound = GetComponent<AudioSource>();
    }


    public void Shoot()
    {
        if (bulletPrefab != null && firePoint != null && shooter != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity) as GameObject;

            Bullet bulletComponent = bullet.GetComponent<Bullet>();

            shootSound.Play();


            if (shooter.transform.localScale.x < 0)
            {
                //Left
                bulletComponent.direction = Vector2.left;
            }
            else
            {
                bulletComponent.direction = Vector2.right;
            }
        }
    }
}

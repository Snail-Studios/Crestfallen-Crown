using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mech_Shoot : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform shootingPoint;
    public Transform shootingPoint2;
    public float projectileSpeed = 10f;
    public GameObject[] Array;

    public float attackCooldown = 2.0f; // Adjust the cooldown as needed
    private float timeSinceLastAttack = 0f;

    bool CanAttack()
    {
        // Check if enough time has passed since the last attack
        return timeSinceLastAttack >= attackCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastAttack += Time.deltaTime;

        GameObject[] Mechcount = GameObject.FindGameObjectsWithTag("Mech");
        int Mechnum = Mechcount.Length;

        if (Mechnum >= 3)
        {
            GameObject newestObject = Mechcount[0];
            Array = Mechcount;
            // Destroy the newest object
            Destroy(newestObject);
        }

        if (Input.GetButtonDown("Fire1"))  // You can customize the input button
        {

            if (CanAttack())
            {
                ShootProjectile();
            }
        }
    }

    void ShootProjectile()
    {
        // Instantiate the projectile at the shooting point position and rotation
        GameObject projectile = Instantiate(projectilePrefab, shootingPoint.position, shootingPoint.rotation);
        GameObject projectile2 = Instantiate(projectilePrefab, shootingPoint2.position, shootingPoint2.rotation);


        // Get the Rigidbody2D component of the projectile
        Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();
        Rigidbody2D projectileRb2 = projectile2.GetComponent<Rigidbody2D>();


        // Set the velocity of the projectile to make it move in the forward direction
        projectileRb.velocity = shootingPoint.right * projectileSpeed;
        projectileRb2.velocity = shootingPoint.right * projectileSpeed;


        // Destroy the projectile after a certain time (adjust as needed)
        Destroy(projectile, 2f);
        Destroy(projectile2, 2f);
        timeSinceLastAttack = 0f;
    }
}

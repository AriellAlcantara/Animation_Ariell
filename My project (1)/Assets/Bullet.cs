using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifetime = 3f;  // Bullet will be destroyed after this time

    void Start()
    {
        Destroy(gameObject, lifetime);  // Destroy the bullet after a few seconds if it doesn't hit anything
    }

    // Detect collision with the enemy
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the object the bullet hits is tagged as "Enemy"
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Destroy the enemy
            Destroy(collision.gameObject);

            // Destroy the bullet after hitting the enemy
            Destroy(gameObject);
        }
    }
}


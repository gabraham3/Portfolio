using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    int damage = 1;
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collider belongs to an enemy
        if (other.CompareTag("Enemy"))
        {
            // Get the enemy_health script from the collided enemy
            enemy_health enemyHealth = other.GetComponent<enemy_health>();
            if (enemyHealth != null)
            {
                // Deal damage to the enemy
                enemyHealth.DamageEnemy(damage);
            }

            // Destroy the projectile after hitting an enemy
            Destroy(gameObject);
        }
    }
}

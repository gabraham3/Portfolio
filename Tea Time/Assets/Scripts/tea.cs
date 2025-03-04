using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tea : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collider belongs to an enemy
        if (other.CompareTag("Player"))
        {
            Health health = other.GetComponent<Health>();

            health.HealPlayer(2);
            Destroy(gameObject);
        }
    }
}

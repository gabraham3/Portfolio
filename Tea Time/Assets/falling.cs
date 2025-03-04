using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class falling : MonoBehaviour
{
    public Transform Character;
    public Vector2 newposition;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Health health = other.GetComponent<Health>();

        // Check if the collider belongs to an enemy
        if (other.CompareTag("Player"))
        {
           Character.position = newposition;
           health.DamagePlayer(2);
        }
    }
}

using UnityEngine;

public class Marshmallow : MonoBehaviour
{
    public float detectionRange = 1.5f; // Distance at which the projectile reacts to the player
    public GameObject player;

    private void Start()
    {
        Destroy(gameObject, 3);

        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        // Check if the player is within the detection range
        if (player != null && Vector2.Distance(transform.position, player.transform.position) <= detectionRange)
        {
            // Execute behavior when near player (e.g., deal damage)
            DealDamageToPlayer();
        }

    }

    private void DealDamageToPlayer()
    {
        Health playerHealth = player.GetComponent<Health>();
        if (playerHealth != null)
        {
            playerHealth.DamagePlayer(3);
        }

        // Destroy the projectile after dealing damage
        Destroy(gameObject);
    }
}

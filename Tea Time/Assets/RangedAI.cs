using UnityEngine;

public class RangedAI : MonoBehaviour
{
    public Transform player;
    public GameObject projectilePrefab;
    public float projectileSpeed = 5f;
    public float attackCooldown = 2f;
    public float predictionTime = 0.5f; // Time to predict player's position
    public Animator animator;

    public Transform projectileSpawnPoint;

    private float lastAttackTime;

    private void Start()
    {
        lastAttackTime = -attackCooldown; // Ensure enemy can attack immediately
    }

    private void Update()
    {
        if (Time.time - lastAttackTime >= attackCooldown && player != null)
        {
            Vector2 predictedPosition = PredictPlayerPosition();
            Vector2 direction = (predictedPosition - (Vector2)projectileSpawnPoint.position).normalized;
            StartCoroutine(ThrowProjectileAfterAnimation(direction));
            lastAttackTime = Time.time;
        }
    }

    private Vector2 PredictPlayerPosition()
    {
        if (player == null)
            return Vector2.zero;

        // Predict player's position after predictionTime seconds
        Vector2 velocity = player.GetComponent<Rigidbody2D>().velocity;
        Vector2 predictedPosition = (Vector2)player.position + velocity * predictionTime;

        return predictedPosition;
    }

    private System.Collections.IEnumerator ThrowProjectileAfterAnimation(Vector2 direction)
    {
        // Play the throwing animation
        animator.SetBool("throwing", true);

        // Wait for the animation to finish
        yield return new WaitForSeconds(animator.GetCurrentAnimatorClipInfo(0)[0].clip.length);

        // Spawn the projectile after the animation has finished
        GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.identity);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.velocity = direction * projectileSpeed;

        // Reset the throwing boolean
        animator.SetBool("throwing", false);
    }
}

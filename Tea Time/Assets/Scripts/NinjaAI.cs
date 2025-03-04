using Pathfinding;
using System.Collections;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("Pathfinding")]
    public Animator animator;
    public Transform target;
    public Transform playerTarget;
    public Transform backOffTarget;
    public float pathUpdateSeconds = 0.5f;
    public float stopFollow = 0f;
    [Header("Physics")]
    public float speed = 200f, jumpForce = 100f;
    public float nextWaypointDistance = 3f;
    public float jumpNodeHeightRequirement = 0.8f;
    public float jumpCheckOffset = 0.1f;
    public bool backing = false;
    public bool jumpEnabled = true, isJumping, isInAir;
    public bool directionLookEnabled = true;
    [SerializeField] Vector3 startOffset;
    public float attackDistance = 2f;
    private Path path;
    private int currentWaypoint = 0;
    [SerializeField] public RaycastHit2D isGrounded;
    Seeker seeker;
    Rigidbody2D rb;
    private bool isOnCoolDown;
    public float IdleTime = 0f;
    public float ydist = 0f;
    public float lastJump = 0f;
    public void Start()
    {
        AstarPath.active.Scan();
        target=playerTarget;
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        isJumping = false;
        isInAir = false;
        isOnCoolDown = false; 

        InvokeRepeating("UpdatePath", 0f, pathUpdateSeconds);

    }

    private void FixedUpdate()
    {
        lastJump += Time.deltaTime;
        if(IdleTime< 1.5f){
            IdleTime += Time.deltaTime;
        }
        else{
            animator.SetBool("running", true);
            Attack();
            if(backing == true){
                stopFollow +=Time.deltaTime;
                if(stopFollow >= 3f){
                    target=playerTarget;
                    stopFollow=0f;
                }
            }
            PathFollow();
        }
    }

    private void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }

    private void PathFollow()
    {
        if (path == null)
        {
            return;
        }

        // Reached end of path
        if (currentWaypoint >= path.vectorPath.Count)
        {
            return;
        }

        // See if colliding with anything
        startOffset = transform.position - new Vector3(0f, GetComponent<Collider2D>().bounds.extents.y + jumpCheckOffset, transform.position.z);
        isGrounded = Physics2D.Raycast(startOffset, -Vector3.up, 0.05f);

        // Direction Calculation
        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed;

        // Jump
        if (jumpEnabled && isGrounded && !isInAir && !isOnCoolDown)
        {
            if (direction.y > jumpNodeHeightRequirement)
            {
                if (isInAir) return; 
                lastJump = 0f;
                isJumping = true;
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                StartCoroutine(JumpCoolDown());
                ydist = transform.position.y;
            }
        }
        if (isGrounded)
        {
            isJumping = false;
            isInAir = false; 
            if((ydist - transform.position.y) < .3 && lastJump < .5f){
                force.x = speed;

            }
        }
        else
        {
            isInAir = true;
        }

        // Movement
        rb.velocity = new Vector2(force.x, rb.velocity.y);

        // Next Waypoint
        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        // Direction Graphics Handling
        if (directionLookEnabled)
        {
            if (rb.velocity.x > 0.05f)
            {
                transform.localScale = new Vector3(-1f * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else if (rb.velocity.x < -0.05f)
            {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
        }
    }



    private void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    IEnumerator JumpCoolDown()
    {
        isOnCoolDown = true; 
        yield return new WaitForSeconds(1f);
        isOnCoolDown = false;
    }
    
    public void Attack()
    {
        float distance = Vector2.Distance(transform.position, playerTarget.position);
        Debug.Log(distance);
            // Attack if close enough
        if (distance <= attackDistance)
        {
            DealDamage(); // Call function to deal damage to the player
        }
    }

    public void DealDamage()
    {
        target.GetComponent<Health>().DamagePlayer(4);

        target = backOffTarget;
        backing = true;
    }
}
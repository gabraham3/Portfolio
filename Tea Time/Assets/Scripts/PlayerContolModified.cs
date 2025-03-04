using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContolModified : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpPower = 12f;
    private bool isFacingRight = true;

    public handleManager hm;

    public GameObject projectile;
    public float projectileSpeed = 20f;
    public Transform projectileSpawnPoint;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    // Start is called before the first frame update
    void Start()
    {
        hm = handleManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);

        }
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);

        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            GameObject weapon = Instantiate(projectile, projectileSpawnPoint.position, Quaternion.identity);
            Rigidbody2D weaponrb = weapon.GetComponent<Rigidbody2D>();
            if (weaponrb != null)
            {
                Vector2 dir = isFacingRight ? Vector2.right : Vector2.left;
                weaponrb.velocity = dir * projectileSpeed;
            }

        }
        Flip();
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;

        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("handle"))
        {
            
            hm.handleC++;
            Destroy(other.gameObject);
        }

    }
}
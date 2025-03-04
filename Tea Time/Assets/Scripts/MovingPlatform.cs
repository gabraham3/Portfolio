using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform platform;
    public Transform startPoint;
    public Transform endpoint;
    int direction = 1;
    public float speed = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 target = currentMovmentTarget();
        platform.position = Vector2.Lerp(platform.position, target, speed * Time.deltaTime);
        float distance = (target - (Vector2)platform.position).magnitude;

        if (distance <= 0.1f)
        {
            direction *= -1;
        }
    }
    Vector2 currentMovmentTarget()
    {
        if (direction == 1)
        {
            return startPoint.position;
        }
        else
        {
            return endpoint.position;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.parent = transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.parent = null;
        }
    }
    public void OnDrawGizmos()
    {
        if (platform != null && startPoint != null && endpoint != null)
        {
            Gizmos.DrawLine(platform.transform.position, startPoint.position);
            Gizmos.DrawLine(platform.transform.position, endpoint.position);
        }

    }
}

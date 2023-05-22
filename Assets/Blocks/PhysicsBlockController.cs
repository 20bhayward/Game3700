using UnityEngine;

public class PhysicsBlockController : MonoBehaviour
{
    public Transform waypoint;
    public float speed = 5f;

    private Rigidbody2D rb;
    private Vector2 direction;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        MoveToWaypoint();
    }

    private void MoveToWaypoint()
    {
        direction = (waypoint.position - transform.position).normalized;
        rb.AddForce(direction * speed);
    }
}

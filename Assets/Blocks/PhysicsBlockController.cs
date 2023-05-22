using UnityEngine;

public class PhysicsBlockController : MonoBehaviour
{
    public Transform waypoint;
    public float speed = 5f;
    public bool activatedBySwitch = false;

    private Rigidbody2D rb;
    private Vector2 direction;
    private bool isActivated = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (!activatedBySwitch)
        {
            isActivated = true;
        }
    }

    private void FixedUpdate()
    {
        if (isActivated)
        {
            MoveToWaypoint();
        }
    }

    private void MoveToWaypoint()
    {
        direction = (waypoint.position - transform.position).normalized;
        rb.AddForce(direction * speed);
    }

    // This method can be called by a switch to activate the block's movement
    public void Activate()
    {
        isActivated = true;
    }
}

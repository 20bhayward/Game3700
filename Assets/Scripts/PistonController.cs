using System.Collections;
using UnityEngine;

public class PistonController : MonoBehaviour
{
    public enum Direction { Up, Down, Left, Right }
    public Direction direction; // The direction to push
    public float distance = 1.0f; // The distance to push
    public float force = 10.0f; // The push force
    public float frequency = 1.0f; // The push frequency in seconds
    public bool automatic = true; // Whether the piston operates automatically
    public float speed = 1.0f; // The speed of the piston's movement

    private float timer;
    private bool activated;
    private Vector3 initialPosition;

    private void Start()
    {
        timer = frequency;
        activated = automatic;
        initialPosition = transform.position;
    }

    private void Update()
    {
        if (activated)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                StartCoroutine(ExtendAndRetractPiston());
                timer = frequency;
            }
        }
    }

    private IEnumerator ExtendAndRetractPiston()
    {
        Vector3 targetPosition = GetTargetPosition();
        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            yield return null;
        }
        while (Vector3.Distance(transform.position, initialPosition) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, initialPosition, speed * Time.deltaTime);
            yield return null;
        }
    }

    private Vector3 GetTargetPosition()
    {
        switch (direction)
        {
            case Direction.Up:
                return initialPosition + new Vector3(0, distance, 0);
            case Direction.Down:
                return initialPosition - new Vector3(0, distance, 0);
            case Direction.Left:
                return initialPosition - new Vector3(distance, 0, 0);
            case Direction.Right:
                return initialPosition + new Vector3(distance, 0, 0);
            default:
                return initialPosition;
        }
    }

    // External scripts can call this function to activate the piston
    public void Activate()
    {
        activated = true;
    }

    // External scripts can call this function to deactivate the piston
    public void Deactivate()
    {
        activated = false;
    }

    // External scripts can call this function to toggle the piston
    public void Toggle()
    {
        activated = !activated;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ApplyForce(collision);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        ApplyForce(collision);
    }

    private void ApplyForce(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Object")
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 forceDirection = GetForceDirection();
                rb.AddForce(forceDirection * force, ForceMode2D.Force);
            }
        }
    }


    private Vector2 GetForceDirection()
    {
        switch (direction)
        {
            case Direction.Up:
                return Vector2.up;
            case Direction.Down:
                return Vector2.down;
            case Direction.Left:
                return Vector2.left;
            case Direction.Right:
                return Vector2.right;
            default:
                return Vector2.zero;
        }
    }
}

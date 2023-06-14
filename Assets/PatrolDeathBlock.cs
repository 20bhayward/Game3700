using UnityEngine;

public class PatrolDeathBlock : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 2.0f;
    public bool loop = false;

    private int currentWaypointIndex = 0;
    private bool isMoving = false;
    private bool playerOnBlock = false;

    private void Update()
    {
        if (isMoving)
        {
            MoveTowardsWaypoint(waypoints[currentWaypointIndex]);
        }
    }

    private void MoveTowardsWaypoint(Transform waypoint)
    {
        Vector3 direction = waypoint.position - transform.position;
        float distance = direction.magnitude;
        Vector3 normalizedDirection = direction / distance;

        transform.position += normalizedDirection * speed * Time.deltaTime;

        if (Vector3.Distance(transform.position, waypoint.position) < 0.1f)
        {
            if (currentWaypointIndex < waypoints.Length - 1)
            {
                currentWaypointIndex++;
            }
            else if (loop)
            {
                currentWaypointIndex = 0;
            }
            else
            {
                isMoving = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerOnBlock = true;
            isMoving = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (playerOnBlock && isMoving)
            {
                PlayerController playerController = other.gameObject.GetComponent<PlayerController>();
                if (playerController != null)
                {
                    playerController.Respawn();
                }
            }
            playerOnBlock = false;
        }
    }
}

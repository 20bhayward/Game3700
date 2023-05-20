using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{
    public List<Transform> waypoints; // List of waypoints
    public List<float> waitTimes; // List of wait times at each waypoint
    public float speed = 1.0f; // Speed of the boat

    private int currentIndex = 0;
    private bool isMoving = true;
    private GameObject player;

    private void Start()
    {
        if (waypoints.Count != waitTimes.Count)
        {
            Debug.LogError("The number of waypoints and wait times do not match!");
            return;
        }

        player = GameObject.FindGameObjectWithTag("Player"); // Tag the player object with "Player"
        StartCoroutine(Patrol());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            player.transform.parent = transform; // Set the player object as a child of the boat object
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            player.transform.parent = null; // Set the player object's parent to null
        }
    }

    private IEnumerator Patrol()
    {
        while (true)
        {
            if (isMoving)
            {
                // Move towards the current waypoint
                transform.position = Vector3.MoveTowards(transform.position, waypoints[currentIndex].position, speed * Time.deltaTime);

                // Check if the boat has arrived at the waypoint
                if (Vector3.Distance(transform.position, waypoints[currentIndex].position) < 0.01f)
                {
                    isMoving = false;
                    yield return new WaitForSeconds(waitTimes[currentIndex]);
                    currentIndex = (currentIndex + 1) % waypoints.Count;
                    isMoving = true;
                }
            }
            yield return null;
        }
    }
}

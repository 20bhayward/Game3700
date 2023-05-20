using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{
    public List<Transform> waypoints;
    public List<float> waitTimes;
    public float speed = 1f;

    private int currentWaypoint = 0;

    private void Start()
    {
        StartCoroutine(MoveToNextWaypoint());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.parent = transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.parent = null;
        }
    }

    private IEnumerator MoveToNextWaypoint()
    {
        while (true)
        {
            var nextWaypoint = waypoints[currentWaypoint];
            while (Vector2.Distance(transform.position, nextWaypoint.position) > 0.01f)
            {
                transform.position = Vector2.MoveTowards(transform.position, nextWaypoint.position, speed * Time.deltaTime);
                yield return null;
            }

            yield return new WaitForSeconds(waitTimes[currentWaypoint]);

            currentWaypoint = (currentWaypoint + 1) % waypoints.Count;
        }
    }
}

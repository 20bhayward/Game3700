using System.Collections;
using UnityEngine;

public class HunterBlockController : MonoBehaviour
{
    public float speed = 5f;

    private Vector2 startPosition;
    private Vector2 direction;
    private float moveDistance;
    private bool isMoving = false;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        if (isMoving)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, startPosition + direction * moveDistance, step);

            if ((Vector2)transform.position == startPosition + direction * moveDistance)
            {
                isMoving = false;
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, startPosition, speed * Time.deltaTime);
        }
    }

    public void MoveInDirection(Vector2 dir, float distance)
    {
        direction = dir;
        moveDistance = distance;
        isMoving = true;
    }

    public bool IsAtStartPosition()
    {
        return (Vector2)transform.position == startPosition;
    }

    public void ReturnToStartPosition()
    {
        isMoving = false;
    }
}

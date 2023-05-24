using System.Collections;
using UnityEngine;

public class HunterBlockController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector3 startPosition;
    private Vector3 targetPosition;
    private Vector2 directionVector;
    private float pathLength;
    private Coroutine moveCoroutine;
    private bool isMoving;

    private void Start()
    {
        startPosition = transform.position;
    }

    public void MoveInDirection(Vector2 direction, float length)
    {
        if (isMoving) return;

        directionVector = direction;
        pathLength = length;
        targetPosition = startPosition + (Vector3)(direction * length);

        if (moveCoroutine != null)
        {
            StopCoroutine(moveCoroutine);
        }

        moveCoroutine = StartCoroutine(MoveToTarget());
    }

    public bool IsMoving()
    {
        return isMoving;
    }

    private IEnumerator MoveToTarget()
    {
        isMoving = true;

        while (Vector3.Distance(transform.position, targetPosition) > 0.001f)
        {
            float step = moveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
            yield return null;
        }

        isMoving = false;

        // Reached the target, return to the start position
        StartCoroutine(ReturnToStartPosition());
    }

    private IEnumerator ReturnToStartPosition()
    {
        isMoving = true;

        while (Vector3.Distance(transform.position, startPosition) > 0.001f)
        {
            float step = moveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, startPosition, step);
            yield return null;
        }

        isMoving = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            // If collides with a non-player object, stop current movement and return to the start position
            if (moveCoroutine != null)
            {
                StopCoroutine(moveCoroutine);
            }
            StartCoroutine(ReturnToStartPosition());
        }
    }
}

using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    public Transform objectToMove;
    public float speed = 2f;
    public float distance = 5f;

    private Vector3 startPos;
    private float moveDistance;
    private bool movingRight = true;

    private void Start()
    {
        startPos = objectToMove.position;
        moveDistance = distance;
    }

    private void Update()
    {
        float step = speed * Time.deltaTime;

        if (movingRight)
        {
            objectToMove.position = Vector3.MoveTowards(objectToMove.position, startPos + Vector3.right * moveDistance, step);

            if (objectToMove.position.x >= startPos.x + moveDistance)
            {
                movingRight = false;
            }
        }
        else
        {
            objectToMove.position = Vector3.MoveTowards(objectToMove.position, startPos, step);

            if (objectToMove.position.x <= startPos.x)
            {
                movingRight = true;
            }
        }
    }
}

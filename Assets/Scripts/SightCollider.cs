using UnityEngine;

public class SightCollider : MonoBehaviour
{
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    public HunterBlockController hunterBlockController;
    public Direction direction;
    public float sightRange = 5f;

    private Vector2 directionVector;
    private BoxCollider2D collider;

    private void Start()
    {
        hunterBlockController = GetComponentInParent<HunterBlockController>();
        collider = GetComponent<BoxCollider2D>();
        Vector2 offset = Vector2.zero;

        switch (direction)
        {
            case Direction.Up:
                directionVector = Vector2.up;
                collider.size = new Vector2(collider.size.x, sightRange);
                offset.y = sightRange / 2;
                break;
            case Direction.Down:
                directionVector = Vector2.down;
                collider.size = new Vector2(collider.size.x, sightRange);
                offset.y = -sightRange / 2;
                break;
            case Direction.Left:
                directionVector = Vector2.left;
                collider.size = new Vector2(sightRange, collider.size.y);
                offset.x = -sightRange / 2;
                break;
            case Direction.Right:
                directionVector = Vector2.right;
                collider.size = new Vector2(sightRange, collider.size.y);
                offset.x = sightRange / 2;
                break;
        }

        collider.offset = offset;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            hunterBlockController.MoveInDirection(directionVector, collider.size.magnitude);
        }
    }
}

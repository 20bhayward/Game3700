using System.Collections;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMover : MonoBehaviour
{
    public Transform block1; // Reference to the first block
    public Transform block2; // Reference to the second block
    public Transform midPoint; // Reference to the middle point
    public float speed = 1f; // Speed of the movement

    public bool active = false;

    private Vector3 block1StartPos; // Starting position of the first block
    private Vector3 block2StartPos; // Starting position of the second block
    private Vector3 block1Target; // Target position for the first block
    private Vector3 block2Target; // Target position for the second block

    private void Start()
    {
        // Save the starting positions
        block1StartPos = block1.position;
        block2StartPos = block2.position;

        // Calculate the target positions
        float block1Size = block1.GetComponent<Renderer>().bounds.size.x;
        float block2Size = block2.GetComponent<Renderer>().bounds.size.x;

        block1Target = midPoint.position + new Vector3(-block1Size / 2, 0, 0);
        block2Target = midPoint.position + new Vector3(block2Size / 2, 0, 0);
    }

    private void Update()
    {
        if (active)
        {
            // Calculate how far to move this frame
            float step = speed * Time.deltaTime;

            // Move each block towards the middle point
            block1.position = Vector3.MoveTowards(block1.position, block1Target, step);
            block2.position = Vector3.MoveTowards(block2.position, block2Target, step);
        }

    }

    // Call this function to reset the blocks to their starting positions
    public void ResetBlocks()
    {
        block1.position = block1StartPos;
        block2.position = block2StartPos;
        active = false;
    }

    // Call this function to start the blocks moving
    public void StartMoving()
    {
        active = true;
    }
}

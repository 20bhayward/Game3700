using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // speed of the cylinder movement
    private Rigidbody2D rb; // reference to the rigidbody component

    private Vector2 movement; // 2D Vector for storing input

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // get the Rigidbody2D component
    }

    private void Update()
    {
        // Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        // Movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}

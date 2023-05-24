using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

public class TrapdoorTeleport : MonoBehaviour
{
    public Transform teleportLocation; // Location to teleport the player to

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collider is a player
        if (other.gameObject.tag == "Player")
        {
            // Move the player to the teleport location
            other.transform.position = teleportLocation.position;
        }
    }
}

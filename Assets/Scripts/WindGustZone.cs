using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindGustZone : MonoBehaviour
{
    // The strength and direction of the wind
    public Vector2 windForce = new Vector2(5f, 0f);

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Object")
        {
            // If the player is within the wind zone, apply the wind force
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.AddForce(windForce);
            }
        }
    }
}

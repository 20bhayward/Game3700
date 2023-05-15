using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionMechanics : MonoBehaviour
{
    public List<GameObject> objectsToHide; // List of objects to hide

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.name == "Pressure Plate")
        {
            foreach (GameObject obj in objectsToHide)
            {
                if (obj != null)
                {
                    Renderer rend = obj.GetComponent<Renderer>();
                    if (rend != null)
                    {
                        rend.enabled = false;
                    }
                }
            }
        }
    }
}

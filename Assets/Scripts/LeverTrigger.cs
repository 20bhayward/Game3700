using System.Collections.Generic;
using UnityEngine;

public class LeverTrigger : MonoBehaviour
{
    public List<GameObject> objectsToHide; // List of objects to hide

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            foreach (GameObject obj in objectsToHide)
            {
                if (obj != null)
                {
                    Renderer rend = obj.GetComponent<Renderer>();
                    Collider2D coll = obj.GetComponent<Collider2D>();
                    if (rend != null)
                    {
                        rend.enabled = false;
                    }
                    if (coll != null)
                    {
                        coll.enabled = false;
                    }
                }
            }
        }
    }
}

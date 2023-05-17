using System.Collections.Generic;
using UnityEngine;

public class PressurePlateTrigger : MonoBehaviour
{
    public List<GameObject> objectsToHide; // List of objects to hide
    public List<GameObject> objectsToShow; // List of objects to show

    // New material variables
    public Material activeMaterial;
    public Material inactiveMaterial;

    private MeshRenderer meshRenderer;

    private void Start()
    {
        // Get the MeshRenderer component
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Object")
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
                    obj.GetComponent<Collider2D>().enabled = false;
                }
            }
            foreach (GameObject obj in objectsToShow)
            {
                if (obj != null)
                {
                    Renderer rend = obj.GetComponent<Renderer>();
                    Collider2D coll = obj.GetComponent<Collider2D>();
                    if (rend != null)
                    {
                        rend.enabled = true;
                    }
                    if (coll != null)
                    {
                        coll.enabled = true;
                    }
                }
                obj.GetComponent<Collider2D>().enabled = true;
            }

            // Change the material to the active material
            meshRenderer.material = activeMaterial;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Object")
        {
            foreach (GameObject obj in objectsToHide)
            {
                if (obj != null)
                {
                    Renderer rend = obj.GetComponent<Renderer>();
                    Collider2D coll = obj.GetComponent<Collider2D>();
                    if (rend != null)
                    {
                        rend.enabled = true;
                    }
                    if (coll != null)
                    {
                        coll.enabled = true;
                    }
                }
                obj.GetComponent<Collider2D>().enabled = false;
            }
            foreach (GameObject obj in objectsToShow)
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
                obj.GetComponent<Collider2D>().enabled = true;
            }
        }

        // Change the material to the active material
        meshRenderer.material = inactiveMaterial;
    }
}

using System.Collections.Generic;
using UnityEngine;

public class PressurePlateTrigger : MonoBehaviour
{
    public List<GameObject> objectsToHide; // List of objects to hide
    public List<GameObject> objectsToShow; // List of objects to show

    // New material variables
    public Material activeMaterial;
    public Material inactiveMaterial;

    public AudioClip startSound; // Sound to play when the pressure plate is activated
    public AudioClip endSound; // Sound to play when the pressure plate is deactivated


    public MeshRenderer meshRenderer;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
            }
            // Play the start sound
            if (startSound != null)
            {
                audioSource.PlayOneShot(startSound);
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
            }

            // Change the material to the inactive material
            meshRenderer.material = inactiveMaterial;

            // Play the end sound
            if (endSound != null)
            {
                audioSource.PlayOneShot(endSound);
            }
        }
    }
}

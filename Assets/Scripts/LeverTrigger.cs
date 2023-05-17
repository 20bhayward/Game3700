using UnityEngine;
using System.Collections.Generic;


public class LeverTrigger : MonoBehaviour
{
    public List<GameObject> objectsToActivate;
    public List<GameObject> objectsToDeactivate;


    // New material variables
    public Material activeMaterial;
    public Material inactiveMaterial;

    public List<MeshRenderer> meshRenderer;

    public AudioClip startSound; // Sound to play

    private AudioSource audioSource;

    // A flag to check if the lever has been triggered or not
    private bool isTriggered = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && !isTriggered)
        {
            foreach (GameObject obj in objectsToActivate)
            {
                obj.SetActive(true);
                if (obj.GetComponent<Collider2D>() != null)
                {
                    obj.GetComponent<Collider2D>().enabled = true;
                }
            }

            foreach (GameObject obj in objectsToDeactivate)
            {
                obj.SetActive(false);
                if (obj.GetComponent<Collider2D>() != null)
                {
                    obj.GetComponent<Collider2D>().enabled = false;
                }
            }

            // Set the flag to true to prevent further triggering
            isTriggered = true;

            foreach (MeshRenderer obj in meshRenderer)
            {
                // Change the material to the active material
                obj.material = activeMaterial;
            }

            // Play the end sound
            if (startSound != null)
            {
                audioSource.PlayOneShot(startSound);
            }
        }
    }
}

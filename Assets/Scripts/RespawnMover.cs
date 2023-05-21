using UnityEngine;
using System.Collections.Generic;

public class RespawnMover : MonoBehaviour
{
    public List<Transform> transformsToMove;
    public GameObject objectToDeactivate;
    public GameObject objectToActivate;
    public AudioSource audioSource;
    private bool hasBeenActivated = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!hasBeenActivated && other.CompareTag("Player"))
        {
            hasBeenActivated = true;

            foreach (Transform t in transformsToMove)
            {
                t.position = this.transform.position;
            }

            if (objectToDeactivate != null)
            {
                objectToDeactivate.SetActive(false);
            }

            if (objectToActivate != null)
            {
                objectToActivate.SetActive(true);
            }

            if (audioSource != null && audioSource.clip != null)
            {
                audioSource.Play();
            }
            else
            {
                Debug.Log("No audio source or audio clip attached to play sound.");
            }
        }
    }
}
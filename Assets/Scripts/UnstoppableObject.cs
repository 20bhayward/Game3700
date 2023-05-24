using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnstoppableObject : MonoBehaviour
{
    public AudioClip destroySound;
    public Collider2D destructionCollider; // Set this to the specific Collider you want to use

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null) // Make sure AudioSource component exists
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (destructionCollider.IsTouching(other) && other.CompareTag("Object"))
        {
            Destroy(other.gameObject);
            audioSource.PlayOneShot(destroySound);
        }
    }
}
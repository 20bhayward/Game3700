using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnstoppableObject : MonoBehaviour
{
    public AudioClip destroySound;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null) // Make sure AudioSource component exists
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Destructible"))
        {
            Destroy(collision.gameObject);
            audioSource.PlayOneShot(destroySound);
        }
    }
}

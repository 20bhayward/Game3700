using System.Collections;
using UnityEngine;

public class TNT : MonoBehaviour
{
    public float countdownTime = 3.0f; // The time before the TNT block explodes
    public GameObject explosionPrefab; // The prefab to instantiate when the TNT block explodes
    public float explosionRadius = 1.5f; // The radius of the explosion
    private bool isCountdownStarted = false; // Has the countdown started?
    private float countdown; // The countdown timer

    private MeshRenderer meshRenderer;
    private BoxCollider2D boxCollider;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (isCountdownStarted)
        {
            countdown -= Time.deltaTime;
            if (countdown <= 0)
            {
                Explode();
            }
            else if (Mathf.FloorToInt(countdown % 2) == 0)
            {
                meshRenderer.material.color = Color.white;
            }
            else
            {
                meshRenderer.material.color = Color.red;
            }
        }
        else
        {
            Collider2D[] overlaps = Physics2D.OverlapBoxAll(transform.position, boxCollider.size, 0);
            foreach (Collider2D overlap in overlaps)
            {
                if (overlap.gameObject.CompareTag("DeathZone"))
                {
                    Activate();
                    break;
                }
            }
        }
    }

    public void Activate()
    {
        if (!isCountdownStarted)
        {
            isCountdownStarted = true;
            countdown = countdownTime;
            meshRenderer.material.color = Color.red;
        }
    }

    private void Explode()
    {
        // Create a death zone in the explosion radius
        GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        explosion.transform.localScale = new Vector3(explosionRadius * 2, explosionRadius * 2, 1);

        // Destroy the explosion after a delay
        Destroy(explosion, 1f);

        // Destroy all blocks in the explosion radius
        Collider2D[] objectsInRadius = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
        foreach (Collider2D col in objectsInRadius)
        {
            if (col.gameObject.tag == "Object" || col.gameObject.tag == "Destructible")
            {
                Destroy(col.gameObject);
            }
        }

        // Destroy the TNT block itself
        Destroy(gameObject);
    }

}

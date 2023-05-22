using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodvineController : MonoBehaviour
{
    public List<GameObject> frames;
    public float timeBetweenFrames = 0.1f;
    public bool loop = false;
    public float timeBetweenLoops = 1.0f;
    private bool isAnimating = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isAnimating)
        {
            StartCoroutine(Animate());
        }
    }

    private IEnumerator Animate()
    {
        isAnimating = true;

        while (true)
        {
            for (int i = 0; i < frames.Count; i++)
            {
                if (i > 0)
                {
                    frames[i - 1].SetActive(false);
                }

                frames[i].SetActive(true);
                yield return new WaitForSeconds(timeBetweenFrames);
            }

            if (!loop)
            {
                isAnimating = false;
                break;
            }

            frames[frames.Count - 1].SetActive(false);
            yield return new WaitForSeconds(timeBetweenLoops);
        }

        frames[0].SetActive(true);
        isAnimating = false;
    }
}

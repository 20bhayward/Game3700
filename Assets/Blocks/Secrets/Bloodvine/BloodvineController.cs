using System.Collections;
using UnityEngine;

public class BloodvineController : MonoBehaviour
{
    public float frameDuration = 1f;  // duration of each frame in seconds
    public float loopDelay = 1f;  // delay between loops in seconds
    public bool loop = true;  // whether the animation should loop
    public BoxCollider2D collider;

    private GameObject[] frames;
    private int currentFrame = 0;

    private void Start()
    {
        // initialize frames array with child GameObjects
        frames = new GameObject[transform.childCount];
        for (int i = 0; i < frames.Length; i++)
        {
            frames[i] = transform.GetChild(i).gameObject;
        }

        // start the animation
        StartCoroutine(Animate());
    }


    private IEnumerator Animate()
    {
        while (true)
        {
            // deactivate current frame
            if (currentFrame > 0)
            {
                frames[currentFrame - 1].SetActive(false);
            }

            // activate next frame
            frames[currentFrame].SetActive(true);

            // update collider size
            collider.size = frames[currentFrame].GetComponent<BoxCollider2D>().size;

            // wait for the next frame
            yield return new WaitForSeconds(frameDuration);

            // increment current frame
            currentFrame++;

            // if reached the end of the animation
            if (currentFrame == frames.Length)
            {
                // deactivate last frame
                frames[currentFrame - 1].SetActive(false);

                // reset current frame
                currentFrame = 0;

                if (loop)
                {
                    // activate first frame
                    frames[0].SetActive(true);

                    // wait for the loop delay
                    yield return new WaitForSeconds(loopDelay);
                }
                else
                {
                    // stop the animation
                    frames[0].SetActive(true);  // activate first frame
                    yield break;
                }
            }
        }
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // restart the animation
            StopCoroutine(Animate());
            currentFrame = 0;
            StartCoroutine(Animate());
        }
    }
}

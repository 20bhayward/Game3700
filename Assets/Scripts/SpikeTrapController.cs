using System.Collections;
using UnityEngine;

public class SpikeTrapController : MonoBehaviour
{
    public GameObject safeSpike; // Safe state of the spike
    public GameObject fatalSpike; // Fatal state of the spike
    public float delay = 2.0f; // Delay before the fatal version appears
    public float activeTime = 1.0f; // Time the fatal version stays active

    private bool isTriggered = false; // Variable to prevent re-triggering during active state

    private void Start()
    {
        // Ensure that the safe spike is active and the fatal spike is not active at the start
        safeSpike.SetActive(true);
        fatalSpike.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !isTriggered)
        {
            isTriggered = true;
            // Start the sequence of events
            StartCoroutine(TriggerSpikeTrap());
        }
    }

    private IEnumerator TriggerSpikeTrap()
    {
        // Wait for the delay
        yield return new WaitForSeconds(delay);
        // Switch the states of the spikes
        safeSpike.SetActive(false);
        fatalSpike.SetActive(true);
        // Set the trap's tag to "DeathZone"
        gameObject.tag = "DeathZone";

        // Wait for the active time
        yield return new WaitForSeconds(activeTime);
        // Revert the states of the spikes
        safeSpike.SetActive(true);
        fatalSpike.SetActive(false);
        // Remove the "DeathZone" tag
        gameObject.tag = "Untagged";

        // Reset isTriggered
        isTriggered = false;
    }
}

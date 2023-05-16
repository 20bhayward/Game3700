using UnityEngine;
using System.Collections.Generic;


public class LeverTrigger : MonoBehaviour
{
    public List<GameObject> objectsToActivate;
    public List<GameObject> objectsToDeactivate;

    // A flag to check if the lever has been triggered or not
    private bool isTriggered = false;

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
        }
    }
}

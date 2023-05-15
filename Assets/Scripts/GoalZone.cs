using UnityEngine;

public class GoalZone : MonoBehaviour
{
    // Reference to the Animator of the object that will play the animation
    public Animator animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Play the LevelComplete animation
            animator.enabled = true;
            animator.Play("LevelComplete");
        }
    }
}

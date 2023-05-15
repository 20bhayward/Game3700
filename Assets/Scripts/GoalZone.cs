using UnityEngine;

public class GoalZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Notify GoalZoneManager that a player entered a goal zone
            GoalZoneManager.Instance.PlayerEnteredGoalZone();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Notify GoalZoneManager that a player exited a goal zone
            GoalZoneManager.Instance.PlayerExitedGoalZone();
        }
    }
}

using UnityEngine;

public class GoalZoneManager : MonoBehaviour
{
    // Singleton instance
    public static GoalZoneManager Instance { get; private set; }

    // Reference to the Animator of the object that will play the animation
    public Animator animator;

    // Reference to the victory screen that will be shown
    // public GameObject victoryScreen;

    // Variable to keep track of the number of players in any goal zone
    private int playersInGoalZones = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("There should only be one GoalZoneManager in the scene!");
            Destroy(gameObject);
        }
    }

    public void PlayerEnteredGoalZone()
    {
        playersInGoalZones++;

        if (playersInGoalZones == PlayerController.TotalPlayers)
        {
            // Enable the Animator component
            animator.enabled = true;

            // Play the LevelComplete animation
            animator.Play("LevelComplete");

            // Show the victory screen
            // victoryScreen.SetActive(true);
        }
    }

    public void PlayerExitedGoalZone()
    {
        playersInGoalZones--;
    }
}
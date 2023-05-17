using UnityEngine;

public class GoalZoneManager : MonoBehaviour
{
    // Singleton instance
    public static GoalZoneManager Instance { get; private set; }

    public BlockMover blockMover; // Reference to the BlockMover script

    // Reference to the victory screen that will be shown
    // public GameObject victoryScreen;

    // Variable to keep track of the number of players in any goal zone
    private int playersInGoalZones = 0;

    public GameObject VictoryScene;

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

    public void VictoryScreen()
    {
        VictoryScene.SetActive(true);
    }

    public void PlayerEnteredGoalZone()
    {
        playersInGoalZones++;

        if (playersInGoalZones == PlayerController.TotalPlayers)
        {
            blockMover.StartMoving();
            // Show the victory screen
            //VictoryScene.SetActive(true);
            Invoke("VictoryScreen", 1);
        }
    }

    public void PlayerExitedGoalZone()
    {
        playersInGoalZones--;
    }
}

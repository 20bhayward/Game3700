using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();
        }
    }

    public void RestartLevel()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "DeathZone")
        {
            RestartLevel();
        }
    }

    // Static variable to keep track of the total number of players
    public static int TotalPlayers = 0;

    private void Awake()
    {
        // Increment the total number of players when a new player is created
        TotalPlayers++;
    }

    private void OnDestroy()
    {
        // Decrement the total number of players when a player is destroyed
        TotalPlayers--;
    }
}

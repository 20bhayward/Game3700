using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject Settings;
    public Transform RespawnPoint;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OpenSettings();
        }
    }

    public void RestartLevel()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OpenSettings()
    {
        Settings.SetActive(true);
    }

    public void Respawn()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in players)
        {
            PlayerController playerController = player.GetComponent<PlayerController>();
            Vector3 respawnPos = RespawnPoint.position;
            if (playerController != null && playerController.RespawnPoint != null && playerController.RespawnPoint.position != null)
            {
                respawnPos = playerController.RespawnPoint.position;
            }
            float randomNumber = UnityEngine.Random.Range(0.0f, 1.0f);
            player.transform.position = respawnPos + new Vector3(randomNumber, randomNumber, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "DeathZone")
        {
            Respawn();
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "DeathZone")
        {
            Respawn();
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

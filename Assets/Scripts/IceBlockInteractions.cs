using UnityEngine;

public class IceBlockInteractions : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "DeathZone")
        {
            // Destroy the DeathZone GameObject
            Destroy(collision.gameObject);

            // Destroy this cube
            Destroy(gameObject);
        }
    }
}

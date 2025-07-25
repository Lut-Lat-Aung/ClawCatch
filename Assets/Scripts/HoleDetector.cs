using UnityEngine;

public class HoleDetector : MonoBehaviour
{
    public GameManager gameManager;
    public SpawnManager spawnManager;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            gameManager.AddPoint();

            spawnManager.DeductSpawnCount();


            // Optional: destroy the ball after scoring
            Destroy(other.gameObject);
        }
    }
}

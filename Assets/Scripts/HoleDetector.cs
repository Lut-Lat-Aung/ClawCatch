using UnityEngine;

public class HoleDetector : MonoBehaviour
{
    public GameManager gameManager;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            gameManager.AddPoint();


            // Optional: destroy the ball after scoring
            Destroy(other.gameObject);
        }
    }
}

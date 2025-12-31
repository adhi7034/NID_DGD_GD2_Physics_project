using UnityEngine;

public class Scoringplane : MonoBehaviour
{
    private GameManager gameManager;
    private bool scoredThisPass = false;
    private int ballsSpawned = 0; // Counter for balls spawned

    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Ball")) return;
        if (scoredThisPass) return;

        scoredThisPass = true;

        Debug.Log("Ball scored");

        gameManager.AddScore();
        gameManager.SpawnBall(); // Will spawn only if no ball exists

        ballsSpawned++; // Increment counter when a new ball is spawned
        Debug.Log("Balls spawned so far: " + ballsSpawned);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Ball")) return;

        scoredThisPass = false;
        gameManager.ReleaseBall(other.gameObject);
        Debug.Log("Ball exited scoring plane → ready for next");
    }
}

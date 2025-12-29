using UnityEngine;

public class Scoringplane : MonoBehaviour
{
    GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Ball")) return;

        // Score FIRST
        gameManager.AddScore();

        // Destroy LAST
        Destroy(other.gameObject);

        gameManager.SpawnBall();


    }
}

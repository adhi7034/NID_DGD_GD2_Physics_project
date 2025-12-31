using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform[] spawnPoints;
    public TMP_Text scoreText;

    private int score = 0;

    // Count how many times Instantiate actually happened
    private int ballSpawnCount = 0;

    // Only allow one ball at a time
    private GameObject currentBall;

    void Start()
    {
        SpawnBall();
        UpdateScoreText();
    }

    public void AddScore()
    {
        score++;
        UpdateScoreText();
    }

    public void ReduceScore()
    {
        score--;
        UpdateScoreText();
    }

    public void SpawnBall()
    {
        // Prevent multiple balls
        if (currentBall != null)
        {
            Debug.Log("Spawn blocked — ball already exists");
            return;
        }

        int randomIndex = Random.Range(0, spawnPoints.Length);
        currentBall = Instantiate(ballPrefab, spawnPoints[randomIndex].position, Quaternion.identity);

        ballSpawnCount++; //COUNT INSTANTIATE HERE
        Debug.Log("Ball spawned / Total Instantiates: " + ballSpawnCount);
    }

    // Call this when ball leaves the scoring plane
    public void ReleaseBall(GameObject ball)
    {
        if (ball == currentBall)
        {
            currentBall = null;
            Debug.Log("Ball released");
        }
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + (ballSpawnCount - 1).ToString();
    }
}

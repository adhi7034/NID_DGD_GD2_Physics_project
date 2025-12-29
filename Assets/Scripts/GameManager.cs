using UnityEngine;
using TMPro; 

public class GameManager : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform[] spawnPoints;

    public TMP_Text scoreText; 

    private int score = 0;

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
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(ballPrefab, spawnPoints[randomIndex].position, Quaternion.identity);
    }

    void UpdateScoreText()
    {
        if(scoreText != null)
            scoreText.text = "Score: " + score.ToString();
    }
}

using UnityEngine;

public class NegativeScore : MonoBehaviour
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
        gameManager.ReduceScore();


    }
}

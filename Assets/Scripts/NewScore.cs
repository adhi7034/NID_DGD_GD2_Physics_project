using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    private bool scored = false;

    private void OnTriggerEnter(Collider other)
    {
        if (scored) return;

        if (other.CompareTag("Ball"))
        {
            scored = true;
            Debug.Log("Score = 1");
        }
    }
}

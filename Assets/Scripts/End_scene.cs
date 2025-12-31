using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeOnTagHit : MonoBehaviour
{
    // public string myTag;
    public string otherTag;
    public string sceneToLoad;

    private void OnTriggerEnter(Collider other)
{
    if (!other.CompareTag("Ball")) return;
    SceneManager.LoadScene(sceneToLoad);
}
}

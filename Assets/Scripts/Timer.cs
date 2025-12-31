using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SceneCountdownTimer : MonoBehaviour
{
    public TMP_Text timerText;

    [Header("Countdown Settings")]
    public float startTime = 60f;   // seconds
    public string sceneToLoad;      // scene name

    private float currentTime;
    private bool hasLoaded = false;

    void Start()
    {
        currentTime = startTime;
        UpdateTimerText();
    }

    void Update()
    {
        if (hasLoaded) return;

        if (currentTime > 0f)
        {
            currentTime -= Time.deltaTime;
            UpdateTimerText();
        }
        else
        {
            currentTime = 0f;
            UpdateTimerText();
            LoadNextScene();
        }
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);

        timerText.text = $"{minutes:00}:{seconds:00}";
    }

    void LoadNextScene()
    {
        if (hasLoaded) return;

        hasLoaded = true;
        SceneManager.LoadScene(sceneToLoad);
    }
}

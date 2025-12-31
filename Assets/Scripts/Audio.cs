using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class IntervalAudio : MonoBehaviour
{
    public static IntervalAudio Instance;   // Singleton instance

    public AudioClip clip;
    public float interval = 2f;

    private AudioSource audioSource;
    private float timer = 0f;

    void Awake()
    {
        // Singleton logic
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // persists across scenes
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= interval)
        {
            PlaySound();
            timer = 0f;
        }
    }

    void PlaySound()
    {
        if (clip != null)
            audioSource.PlayOneShot(clip);
    }
}

using UnityEngine;

public class Translation : MonoBehaviour
{
    public float speed = 3f;

    public float forwardLimit = 5f;    // how far it can go forward
    public float backwardLimit = 2f;   // how far it can go backward

    private float startZ;

    void Start()
    {
        // Store starting position
        startZ = transform.localPosition.z;
    }

    void Update()
    {
        float input = 0f;

        if (Input.GetKey(KeyCode.S)) input = 1f;
        if (Input.GetKey(KeyCode.W)) input = -1f;

        Vector3 pos = transform.localPosition;
        pos += Vector3.forward * input * speed * Time.deltaTime;

        // Clamp RELATIVE to start position
        pos.z = Mathf.Clamp(
            pos.z,
            startZ - backwardLimit,
            startZ + forwardLimit
        );

        transform.localPosition = pos;
    }
}

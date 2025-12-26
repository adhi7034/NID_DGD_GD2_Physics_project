using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Magnet : MonoBehaviour
{
    public Transform magnet;
    public float pullStrength = 25f;
    public float maxSpeed = 8f;
    public float stopDistance = 0.25f;

    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.interpolation = RigidbodyInterpolation.Interpolate;
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
    }

    void FixedUpdate()
    {
        if (!Input.GetKey(KeyCode.Q)) return;

        Vector3 dir = magnet.position - rb.position;
        float dist = dir.magnitude;

        if (dist < stopDistance)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            return;
        }

        Vector3 force = dir.normalized * pullStrength * Mathf.Clamp01(dist);
        rb.AddForce(force, ForceMode.Acceleration);

        rb.linearVelocity = Vector3.ClampMagnitude(rb.linearVelocity, maxSpeed);
    }
}

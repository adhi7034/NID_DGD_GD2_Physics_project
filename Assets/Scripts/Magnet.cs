using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SimpleMagnet : MonoBehaviour
{
    private Transform magnetPoint;
    public float pullSpeed = 6f;
    public float attachDistance = 0.3f;

    Rigidbody rb;
    bool attached = false;

    void Start()
    {
        magnetPoint = GameObject.FindWithTag("Magnet point").transform;
        rb = GetComponent<Rigidbody>();
        rb.interpolation = RigidbodyInterpolation.Interpolate;
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (!attached)
                MoveTowardsMagnet();
        }
        else
        {
            if (attached)
                Detach();
        }
    }

    void MoveTowardsMagnet()
    {
        Vector3 nextPos = Vector3.MoveTowards(
            rb.position,
            magnetPoint.position,
            pullSpeed * Time.fixedDeltaTime
        );

        rb.MovePosition(nextPos);

        if (Vector3.Distance(rb.position, magnetPoint.position) <= attachDistance)
            Attach();
    }

    void Attach()
    {
        attached = true;

        rb.isKinematic = true;
        rb.interpolation = RigidbodyInterpolation.None;

        transform.parent = magnetPoint;
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }

    void Detach()
    {
        attached = false;

        transform.parent = null;

        rb.isKinematic = false;
        rb.interpolation = RigidbodyInterpolation.Interpolate;
    }
}

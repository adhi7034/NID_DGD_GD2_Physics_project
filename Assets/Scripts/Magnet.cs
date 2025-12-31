using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SimpleMagnet : MonoBehaviour
{
    private Transform magnetPoint;

    [Header("Magnet Settings")]
    public float magnetRange = 5f;      // Maximum range of magnet
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
        float distance = Vector3.Distance(rb.position, magnetPoint.position);

        if (Input.GetKey(KeyCode.LeftShift) && distance <= magnetRange)
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

    // Optional: visualize magnet range in Scene view
    void OnDrawGizmosSelected()
    {
        if (magnetPoint == null) return;

        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(magnetPoint.position, magnetRange);
    }
        void OnCollisionEnter(Collision collision)
{
    

    if (collision.gameObject.name == "CollisionBox")
    {
        

        if (attached)
        {
            
            Detach();
        }

        this.enabled = false;
        
    }
}

}

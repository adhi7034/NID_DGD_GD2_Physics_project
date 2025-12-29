using UnityEngine;

public class Translation : MonoBehaviour
{
    public float speed = 3f;

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.localPosition += Vector3.forward * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.localPosition += Vector3.back * speed * Time.deltaTime;
        }
    }
}

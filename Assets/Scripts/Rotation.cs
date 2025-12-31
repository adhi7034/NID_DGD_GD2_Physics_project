using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float rotationSpeed = 90f;

    void Update()
    {
        // if (Input.GetKey(KeyCode.Z))
        // {
        //     transform.Rotate(new Vector3(1f, 0f, 0f) * rotationSpeed);
        // }

        // if (Input.GetKey(KeyCode.X))
        // {
        //     transform.Rotate(new Vector3(-1f, 0f, 0f) * rotationSpeed);
        // }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0f, 1f, 0f) * rotationSpeed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0f, -1f, 0f) * rotationSpeed);
        }
    }
}


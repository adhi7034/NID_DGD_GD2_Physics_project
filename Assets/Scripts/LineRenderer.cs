using UnityEngine;

public class Linerenderer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private LineRenderer lr;
    public GameObject One;
    public GameObject two;
 
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.positionCount = 2;

    }

    // Update is called once per frame
    void Update()
    {
    
        if (One != null && two!=null)
        {
            Vector3 pointOne = One.transform.position;
            Vector3 pointTwo = two.transform.position;

            lr.SetPosition(0,pointOne);
            lr.SetPosition(1,pointTwo);
        }
     
    }
}
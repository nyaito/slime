using UnityEngine;
using System.Collections;

public class grvi : MonoBehaviour
{

    public Vector3 localGravity;
    public Vector3 catchGravity;
    
    private Rigidbody rb;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void Update()
    {
        if (ball.Goff == false)
        {
            setLocalGravity();
        }
        else if(ball.Goff == true)
        {
            setcatchGravity();
        }
    }

    void setLocalGravity()
    {
        rb.AddForce(localGravity, ForceMode.Acceleration);
    }
    void setcatchGravity()
    {
        rb.AddForce(catchGravity, ForceMode.Acceleration);
    }

}
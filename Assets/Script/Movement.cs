using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    Rigidbody rb;
    [SerializeField] float Thrust = 1000;
    [SerializeField] float RotationThrust = 50;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotate();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Space");
            rb.AddRelativeForce(Vector3.up * Time.deltaTime * Thrust);
        }
        
    }
    void ProcessRotate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(RotationThrust);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-RotationThrust);         
        }
    }

    void ApplyRotation( float rotationThisFrame)
    {
        rb.freezeRotation = true;       //freezing rotation so we can manually rotation
        transform.Rotate(Vector3.forward * Time.deltaTime * rotationThisFrame);
        rb.freezeRotation = false;      
    }
}

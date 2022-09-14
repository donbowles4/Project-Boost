using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float fltRotThrust = 1;
    [SerializeField] float fltMainThrust = 1000;
    Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }
    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * fltMainThrust * Time.deltaTime);
        }
    }
    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(fltRotThrust);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-fltRotThrust);
        }
    }

    void ApplyRotation(float fltRotationThisFrame)
    {
        transform.Rotate(Vector3.forward * fltRotationThisFrame * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] float fltRotThrust = 1;
    [SerializeField] float fltMainThrust = 1000;
    [SerializeField] AudioClip mainEngine;
    Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
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
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(mainEngine);
            }
        }
        else { audioSource.Stop(); }
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
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * fltRotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;
    }
}

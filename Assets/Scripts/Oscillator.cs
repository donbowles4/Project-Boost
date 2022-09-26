using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    [SerializeField] [Range(0,1)] float fltMovementFactor;
    void Start()
    {
        startingPosition = transform.position;
    }

    void Update()
    {
        Vector3 offset = movementVector * fltMovementFactor;
        transform.position = startingPosition + offset;
    }
}

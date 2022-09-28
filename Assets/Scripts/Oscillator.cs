using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    [SerializeField] [Range(0,1)] float fltMovementFactor;
    [SerializeField] float fltPeriod = 2f;
    void Start()
    {
        startingPosition = transform.position;
    }

    void Update()
    {
        if(fltPeriod == 0) { return; }
        float fltCycles = Time.time / fltPeriod; //always growing

        const float fltTau = Mathf.PI * 2; //constant value 6.283
        float fltRawSinWave = Mathf.Sin(fltCycles * fltTau);

        fltMovementFactor = (fltRawSinWave + 1f) / 2f;

        Vector3 offset = movementVector * fltMovementFactor;
        transform.position = startingPosition + offset;
    }
}

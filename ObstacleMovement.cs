using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    
    Vector3 startingPos;
    [SerializeField] Vector3 movementVector;
    [SerializeField] [Range(0,1)] float movementFactor;
    [SerializeField] float period = 2f;
    void Start()
    {
        startingPos = transform.position;
    }

    
    void Update()
    {
        float cycle = Time.time /period;
        const float tau = Mathf.PI * 2f;
        float SinWave = Mathf.Sin(cycle * tau);
        movementFactor = (SinWave + 1f) /2 ; 
        Vector3 offset = movementVector*movementFactor;
        transform.position = startingPos + offset;
    }
}

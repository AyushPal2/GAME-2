using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    AudioSource audio;
    [SerializeField] float upthrust = 100f;
    [SerializeField] float rlthrust = 100f;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem MThrust;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
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
            rb.AddRelativeForce(Vector3.up*upthrust* Time.deltaTime);
            if(!audio.isPlaying)
            {
              audio.PlayOneShot(mainEngine);
              MThrust.Play();
            }
        }
        else
        {
            audio.Stop();
            MThrust.Stop();
        }
    }
    void ProcessRotate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyThrust(rlthrust);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyThrust(-rlthrust);
        }
    }

    void ApplyThrust(float rotate)
        {
            rb.freezeRotation = true;
            transform.Rotate(Vector3.forward*rotate*Time.deltaTime);
            rb.freezeRotation = false;
        }
}


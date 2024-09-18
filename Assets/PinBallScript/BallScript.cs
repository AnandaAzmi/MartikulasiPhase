using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    private Rigidbody rb;
   [SerializeField] private float maxSpeed;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.magnitude > maxSpeed)
        {
           rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }
}

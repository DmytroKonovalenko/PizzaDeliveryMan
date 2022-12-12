using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjects : MonoBehaviour
{
    public float minSpeed, maxSpeed;
    private Rigidbody rb;
    private Vector3 newVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        newVelocity = new Vector3(Random.Range(minSpeed, maxSpeed), 9, 0);
    }

    void FixedUpdate()
    {
        rb.velocity = newVelocity;
        Destroy(gameObject, 9.0f);
    }

}

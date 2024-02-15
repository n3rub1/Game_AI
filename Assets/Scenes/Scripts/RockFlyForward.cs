using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockFlyForward : MonoBehaviour
{
    public float stoneSpeed = 10.0f;
    void Start()
    {
        Rigidbody rb = this.GetComponent<Rigidbody>();
        rb.velocity = transform.forward * stoneSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BorderEnforcer : MonoBehaviour
{
    public float pushForce = 100;
    public float pushForceRamping = 5; // force increases by this for each unit outside the disk
    
    // when this gameObject leaves a cyl as defined below, push back into game area
    public Vector3 origin = Vector3.zero;
    public float radius = 20;
    public float vertical = 5;


    Rigidbody rb;
    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        Vector3 pos = transform.position - origin;
        Vector3 force = Vector3.zero;
        if (pos.y > vertical)
            force.y = -pushForce;
        if (pos.y < -vertical)
            force.y = pushForce;
        pos.y = 0; // this allows for pos.magnitude = disk radius
        if (pos.magnitude > radius)
            force -= pushForce * pos.normalized * rb.mass;
        
        rb.AddForce(force);
    }
}

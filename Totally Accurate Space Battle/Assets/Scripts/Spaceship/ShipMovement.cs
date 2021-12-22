using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(ShipInputs))]
public class ShipMovement : MonoBehaviour
{
    ShipInputs inputs;
    Rigidbody rb;
    void Start() {
        inputs = GetComponent<ShipInputs>();
        rb = GetComponent<Rigidbody>();
    }

    [SerializeField] float moveSpeed;
    [SerializeField] float moveForce;
    [SerializeField] float rotateSpeed;
    [SerializeField] float rotateForce;
    void FixedUpdate() {
        // yuck
        if (rb.velocity.magnitude < moveSpeed) {
            rb.AddForce(transform.TransformDirection(moveForce * inputs.move));
        }
        if (rb.angularVelocity.magnitude < rotateSpeed) {
            rb.AddTorque(transform.TransformDirection(rotateForce * inputs.rotate));
        }
        //rb.angularVelocity = Vector3.Lerp(rb.angularVelocity, transform.TransformDirection(rotateSpeed * inputs.rotate), rotateLerp);
    }
}

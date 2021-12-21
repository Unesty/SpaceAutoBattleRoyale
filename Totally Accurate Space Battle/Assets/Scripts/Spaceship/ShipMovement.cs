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

    [SerializeField] int moveSpeed;
    [SerializeField, Range(0, 1)] float moveLerp;
    [SerializeField] int rotateSpeed;
    [SerializeField, Range(0, 1)] float rotateLerp;
    void FixedUpdate() {
        rb.velocity = Vector3.Lerp(rb.velocity, transform.TransformDirection(moveSpeed * inputs.move), moveLerp);
        rb.angularVelocity = Vector3.Lerp(rb.angularVelocity, transform.TransformDirection(rotateSpeed * inputs.rotate), rotateLerp);
    }
}

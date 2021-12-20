using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelEngine : MonoBehaviour
{
    Rigidbody rb;
    public bool on = true;
    // Start is called before the first frame update
    void Start()
    {
         rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(on)
       rb.AddForce(0f,-100f,0f);
    }
    public void Switch()
    {
        on = !on;
    }
}

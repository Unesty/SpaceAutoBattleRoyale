using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestControls : MonoBehaviour
{
    public GameObject kindaRM;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    public void SetValue()
    {
        kindaRM.GetComponent<FuelEngine>().on = !kindaRM.GetComponent<FuelEngine>().on;
    }
}

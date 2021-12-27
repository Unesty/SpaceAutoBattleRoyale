using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class FuelEngine : MonoBehaviour
{
    Rigidbody rb;
    public bool on = true;
    [SerializeField] float power = 1000f;
    [SerializeField] GameObject Flame;
    // Start is called before the first frame update
    void Start()
    {
         rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(on) {
            rb.AddForce(0f,-power,0f);
            Flame.SetActive(true);
        } else {
            Flame.SetActive(false);
        }
    }
    public void Switch()
    {
        on = !on;
    }
}

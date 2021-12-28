using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class FuelEngine : MonoBehaviour
{
    Rigidbody rb;
    public bool on = true;
    [SerializeField] float power = 10f;
    public GameObject FlamePrefab;
    public GameObject Flame;
    public GameObject FuelTank;
    public ToyProcessor CPU;
    // Start is called before the first frame update
    void Start()
    {
         rb = GetComponent<Rigidbody>();
         Flame = Instantiate(FlamePrefab);
         Flame.transform.position = new Vector3(0f, 2.1f, 0f);
         Flame.transform.rotation = new Quaternion(-0.707106829f,0f,0f,0.707106829f);
         Flame.transform.parent = GetComponent<Health>().DestroyWithThis.transform;
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

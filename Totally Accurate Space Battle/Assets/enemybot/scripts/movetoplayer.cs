using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movetoplayer : MonoBehaviour
{
  
    public bool stopmoving = false;
    public float movespeed;
    public radartofind rtf;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
        if (!stopmoving)
        {
            gameObject.transform.parent.parent.position = Vector3.MoveTowards(transform.position, rtf.focus.transform.position, movespeed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            stopmoving = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            stopmoving = false;
        }
    }
}

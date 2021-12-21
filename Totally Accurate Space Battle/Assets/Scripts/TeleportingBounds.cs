using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportingBounds : MonoBehaviour
{
    [SerializeField] GameObject[] GOKeepInBounds;

    [SerializeField] float BoundRadius = 250;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        //must check positions here because they can escape sphere trigger without triggering it
        foreach(GameObject GO in GOKeepInBounds) {
            float _Distance = Vector3.Distance(transform.position, GO.transform.position);
            if(_Distance > BoundRadius) {
                GO.transform.position = -(GO.transform.position - transform.position)/_Distance*BoundRadius;
                if(GO.transform.parent.gameObject.GetComponent<Rigidbody>() != null) {
                    GO.transform.parent.position = -(GO.transform.parent.position - transform.position)/_Distance*BoundRadius;
                }
                print(GO);
                print(_Distance);
            }
        }
    }
}

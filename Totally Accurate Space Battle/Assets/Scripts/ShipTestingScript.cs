using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipTestingScript : MonoBehaviour
{
    public Health target;
    [SerializeField] NameParser nameParser;
    // Start is called before the first frame update
    void Start()
    {
        nameParser.ParseHierarchy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage() {
        target.ReduceHP(1, GetComponent<StarShip>());
    }
}

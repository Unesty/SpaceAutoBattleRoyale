using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnShips : MonoBehaviour
{
    [SerializeField] float scarsity;
    [SerializeField] StarShipDataManager shipDM;
    //[SerializeField] List<GameObject> ships;
    // Start is called before the first frame update
    void Start()
    {

//         uint cbrt = (uint)Math.Ceiling(Math.Pow(ships.Count, (1.0 / 3.0)));
        uint cbrt = (uint)Math.Ceiling(Math.Pow(10, (1.0 / 3.0)));
        print(cbrt);
        for(uint i = 0; i < cbrt; ++i) {
            for(uint h = 0; h < cbrt; ++h) {
                for(uint v = 0; v < cbrt; ++v) {
//                     var ShipToSpawn = UnityEngine.Random.Range(0, ships.Count);
//                     Instantiate(ships[ShipToSpawn], new Vector3(i*scarsity,v*scarsity,h*scarsity), Quaternion.identity);
//                     Instantiate(shipDM.LoadFile([v*h*i]), new Vector3(i*scarsity,v*scarsity,h*scarsity), Quaternion.identity);
//                     ships.RemoveAt(ShipToSpawn);
//                     if(ships.Count == 0) return;
                    shipDM.LoadFile();
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

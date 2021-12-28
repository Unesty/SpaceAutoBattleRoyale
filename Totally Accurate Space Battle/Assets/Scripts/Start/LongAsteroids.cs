using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongAsteroids : MonoBehaviour
{

    [SerializeField] GenerateAsteroid myScript;
    [SerializeField] Vector3Int sideCount = new Vector3Int(1,1,1);
    [SerializeField] float scarsity = 1000f;
    [SerializeField] float r;
    [SerializeField] float force;

    // Start is called before the first frame update
    void Start()
    {
        for(uint i = 0; i < sideCount[2]; ++i) {
            for(uint h = 0; h < sideCount[1]; ++h) {
                for(uint v = 0; v < sideCount[0]; ++v) {
                    var Spawned = myScript.CreateAsteroid(new Vector3(i*scarsity,v*scarsity,h*scarsity)+new Vector3(Random.Range(-r,r), Random.Range(-r,r), Random.Range(-r,r)));
                    Spawned.GetComponent<Rigidbody>().AddForce(RV3(-force, force));
                    Spawned.GetComponent<Rigidbody>().AddTorque(RV3(-force/10000f, force/10000f));
                }
            }
        }
    }
    static Vector3 RV3(float s, float e) {
        return new Vector3(Random.Range(s,e), Random.Range(s,e), Random.Range(s,e));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaTurret : MonoBehaviour
{
    GameObject projectile;
    public void Shoot() {
        var iGO = Instantiate(projectile);
        iGO.GetComponent<Rigidbody>().AddForce(100,0,0);
    }
}

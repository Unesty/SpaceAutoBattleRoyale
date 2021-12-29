using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaTurret : MonoBehaviour
{
    public GameObject projectile;
    public ToyProcessor CPU;
    public StarShip owner;
    public byte MemoryToRead = 255;
    public int reload = 100;
    public int reloadTime = 100;
    public Rigidbody BodyToRecoil;
    public float power = 100f;
    void Start() {
        var rb = transform.parent.GetComponent<Rigidbody>();
        if(rb != null) {
            BodyToRecoil = rb;
        }
        owner = transform.parent.GetComponent<StarShip>();
    }
    void FixedUpdate() {
        if(reload < reloadTime)
            reload++;
        if(CPU.Memory[MemoryToRead] > 0) {
            Shoot();
        }
    }
    public void Shoot() {
        if(reload >= reloadTime) {
            reload = 0;
            var iGO = Instantiate(projectile, transform.position, transform.rotation);
            iGO.GetComponent<PlasmaBullet>().owner = owner;
            iGO.GetComponent<Rigidbody>().AddForce(transform.forward * -power);
            if(BodyToRecoil != null)
                BodyToRecoil.AddForce(transform.forward * power);
        }
    }
}

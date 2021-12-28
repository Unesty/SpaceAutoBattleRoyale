using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int HP;
    [SerializeField] int MaxHP = 100;
    public GameObject Destroyed;
    public GameObject DestroyWithThis;
    public void ReduceHP(int val, StarShip source) {
        if(val == 0) {
            Debug.Log(transform.name + "avoids damage by" + source.gameObject.transform.name);
        } else {
            if(HP - val < 0)
                HP = 0;
            else
                HP -= val;
            if(HP == 0) {
                if(Destroyed != null) {
                    var instanced = Instantiate(Destroyed,transform.position, transform.rotation);
                }
                Destroy(DestroyWithThis);
                if(transform.childCount > 0) {
                    for(int i = 0; i < transform.childCount; ++i) {
                        transform.GetChild(i).SetParent(transform.parent);
                    }
                }
                Destroy(gameObject);
            }
        }
    }
    public void IncreaseHP(int val,  StarShip source) {
        if(val == 0) {
            Debug.Log(transform.name + "misses heal" + source.gameObject.transform.name);
        } else {
            if(HP + val >= MaxHP) {
                HP = MaxHP;
            } else {
                HP += val;
            }
        }
    }

    void Start()
     {
         Mesh mesh = GetComponent<MeshFilter>().sharedMesh;
         float volume = VolumeOfMesh(mesh);
         string msg = "The volume of the mesh " + transform.name + " is " + volume + " cube units.";
         Debug.Log(msg);
         HP = (int)(volume * 100f);
         MaxHP = HP;
         if(HP == 0) {
            Destroy(DestroyWithThis);
            if(transform.childCount > 0) {
                for(int i = 0; i < transform.childCount; ++i) {
                    transform.GetChild(i).SetParent(transform.parent);
                }
            }
            Destroy(gameObject);
        }
         var rb = GetComponent<Rigidbody>();
         if(rb) {
             rb.mass = volume * 2.6f;
         }
     }

     float SignedVolumeOfTriangle(Vector3 p1, Vector3 p2, Vector3 p3)
     {
         float v321 = p3.x * p2.y * p1.z;
         float v231 = p2.x * p3.y * p1.z;
         float v312 = p3.x * p1.y * p2.z;
         float v132 = p1.x * p3.y * p2.z;
         float v213 = p2.x * p1.y * p3.z;
         float v123 = p1.x * p2.y * p3.z;

         return (1.0f / 6.0f) * (-v321 + v231 + v312 - v132 - v213 + v123);
     }

     float VolumeOfMesh(Mesh mesh)
     {
         float volume = 0;

         Vector3[] vertices = mesh.vertices;
         int[] triangles = mesh.triangles;

         for (int i = 0; i < triangles.Length; i += 3)
         {
             Vector3 p1 = vertices[triangles[i + 0]];
             Vector3 p2 = vertices[triangles[i + 1]];
             Vector3 p3 = vertices[triangles[i + 2]];
             volume += SignedVolumeOfTriangle(p1, p2, p3);
         }
         return Mathf.Abs(volume);
     }
}

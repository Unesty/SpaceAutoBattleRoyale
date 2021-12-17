using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroids : MonoBehaviour
{
//     public Mesh mesh;
//     Vector3[] vertices = new Vector3[44];
//     Vector2[] UV = new Vector2[44];
//     int[] triangles = new int[64];

    [SerializeField] GenerateAsteroid myScript;
    [SerializeField] uint sideCount;
    [SerializeField] float scarsity;
    [SerializeField] float r;

    // Start is called before the first frame update
    void Start()
    {
//         mesh = new Mesh();
//         GetComponent<MeshFilter>().mesh = mesh;
//
//         for(int i=0; i<
//
//         mesh.vertices = vertices;
//         mesh.uv = UV;
//         mesh.triangles = triangles;
        for(uint i = 0; i < sideCount; ++i) {
            for(uint h = 0; h < sideCount; ++h) {
                for(uint v = 0; v < sideCount; ++v) {
                    myScript.CreateAsteroid(new Vector3(i*scarsity,v*scarsity,h*scarsity)+new Vector3(Random.Range(-r,r), Random.Range(-r,r), Random.Range(-r,r)));

                }
            }
        }
    }
}

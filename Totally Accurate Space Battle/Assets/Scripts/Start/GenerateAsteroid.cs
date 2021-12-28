using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateAsteroid : MonoBehaviour
{
    public Material planetMaterial;
    public float planetSize = 1f;
    GameObject planet;
    Mesh planetMesh;
    Vector3[] planetVertices;
    int[] planetTriangles;
    MeshRenderer planetMeshRenderer;
    MeshFilter planetMeshFilter;
    MeshCollider planetMeshCollider;
    Rigidbody planetRigidbody;

    public GameObject CreateAsteroid(Vector3 pos)
    {
        CreatePlanetGameObject();
        //do whatever else you need to do with the sphere mesh
        RecalculateMesh();
        planet.transform.position = pos;
//         planetRigidbody.mass = VolumeOfMesh(planetMesh) * 7.860f;
        return planet;
    }

    void CreatePlanetGameObject()
    {
        planet = new GameObject();
        planet.transform.name = "Asteroid";
        planetMeshFilter = planet.AddComponent<MeshFilter>();
        planetMesh = planetMeshFilter.mesh;
        planetMeshRenderer = planet.AddComponent<MeshRenderer>();
        planetMeshCollider = planet.AddComponent<MeshCollider>();
        planetMeshCollider.convex = true;
//         planetRigidbody = planet.AddComponent<Rigidbody>();
//         planetRigidbody.mass = 1000;//maybe calculate volume for more realism

        //need to set the material up top
        planetMeshRenderer.material = planetMaterial;
        planet.transform.localScale = new Vector3(planetSize, planetSize, planetSize);
        IcoSphere.Create(planet);
    }

    void RecalculateMesh()
    {
        planetMesh.RecalculateBounds();
        planetMesh.RecalculateTangents();
        planetMesh.RecalculateNormals();
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

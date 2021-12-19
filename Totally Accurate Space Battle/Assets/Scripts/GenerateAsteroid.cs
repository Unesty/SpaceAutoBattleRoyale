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
        return planet;
    }

    void CreatePlanetGameObject()
    {
        planet = new GameObject();
        planetMeshFilter = planet.AddComponent<MeshFilter>();
        planetMesh = planetMeshFilter.mesh;
        planetMeshRenderer = planet.AddComponent<MeshRenderer>();
        planetMeshCollider = planet.AddComponent<MeshCollider>();
        planetMeshCollider.convex = true;
//         planetRigidbody = planet.AddComponent<Rigidbody>();
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
}

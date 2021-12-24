using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Siccity.GLTFUtility;
using System.Linq;
using Newtonsoft.Json;


public class TestCustomProperties : MonoBehaviour
{

    public string PathToModel;
    [SerializeField] Material yourMaterial;
    // Start is called before the first frame update
    void Start()
    {
        GameObject result = Importer.LoadFromFile(PathToModel);
        result.GetComponent<Renderer>().material = yourMaterial;
        if(result.transform.name.Contains("CPU")) {
            var CPU = result.AddComponent<ToyProcessor>();
            string[] subStrings = result.transform.name.Split(',');
            CPU.memory = System.Text.Encoding.ASCII.GetBytes(subStrings[1]);
        }
        foreach (Transform child in result.transform)
        {
            if(child.transform.name.Contains("CPU")) {
                var CPU = child.gameObject.AddComponent<ToyProcessor>();
                string[] subStrings = child.name.Split(',');
                CPU.memory = System.Text.Encoding.ASCII.GetBytes(subStrings[1]);
            }
        }
    }
}

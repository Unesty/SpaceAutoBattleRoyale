using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class NameParser
{
    public static void ParseGO(GameObject GO) {
        if(GO.transform.name.Contains("CPU")) {
            var CPU = GO.AddComponent<ToyProcessor>();
            string[] subStrings = GO.transform.name.Split(',');
            CPU.Memory = System.Text.Encoding.ASCII.GetBytes(subStrings[1]);
        }
    }
}

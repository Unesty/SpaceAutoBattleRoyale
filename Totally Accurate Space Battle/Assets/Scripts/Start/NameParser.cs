using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameParser : MonoBehaviour
{
    public GameObject RocketDestroyedPrefab;
    public GameObject RocketFlame;
    public void ParseHierarchy(GameObject Root) {
        ToyProcessor CPU = null;
        foreach (Transform child in Root.transform.GetComponentsInChildren<Transform>()) {
            Health health = null;
            GameObject DestroyWithThis = null;
            var GO = child.gameObject;
            string[] subStrings = GO.transform.name.Split(',');
            // NOTE: this is not a name parsing, but is here because other components are added in this method too
            var mesh = GO.GetComponent<MeshFilter>();
            if(mesh != null) {
                var col = GO.AddComponent<MeshCollider>();
                col.convex = true;
                health = GO.AddComponent<Health>();
                foreach (Transform cc in Root.transform.GetComponentsInChildren<Transform>()) {
                    if(cc.name.Contains("DestroyWithThis")) {
                        DestroyWithThis = cc.gameObject;
                        health.DestroyWithThis= cc.gameObject;
                        break;
                    }
                }
            }
            // Parse names
            if(subStrings[0].Contains("CPU")) {
                if(CPU != null) {
                    Debug.Log("Do you really need more than 1 CPU on this" + Root.transform.name + "star ship? Ask developer if you do.");
                } else {
                    CPU = GO.AddComponent<ToyProcessor>();
//                     CPU.Memory = System.Text.Encoding.ASCII.GetBytes(subStrings[1]);
                }
            } else if(subStrings[0].Contains("Rocket Engine")) {
                var Eng = GO.AddComponent<FuelEngine>();
    //             Eng
//                 foreach (Transform cc in child.GetComponentsInChildren<Transform>()) {
//                     if(cc.name.Contains("Flame")) {
//                         Eng.Flame = cc.gameObject;
//                         break;
//                     }
//                 }
                Eng.Flame = Instantiate(RocketFlame, DestroyWithThis.transform);
                Eng.CPU = CPU;
                if(RocketDestroyedPrefab != null)
                    health.Destroyed = RocketDestroyedPrefab;
            }
        }
    }
    public static void ParseGO(GameObject GO) {
        if(GO.transform.name.Contains("CPU")) {
            var CPU = GO.AddComponent<ToyProcessor>();
            string[] subStrings = GO.transform.name.Split(',');
            CPU.Memory = System.Text.Encoding.ASCII.GetBytes(subStrings[1]);
        } else if(GO.transform.name.Contains("Rocket Engine")) {
            var Eng = GO.AddComponent<FuelEngine>();
            string[] subStrings = GO.transform.name.Split(',');
            foreach(string name in subStrings) {
                if(Eng.CPU == null) {
                    if(GO.transform.name.Contains("CPU")) {
//                         Eng.CPU = ;
                        // how to get these, if hierarhy is hidden from this function?
                    }
                }
                if(Eng.Flame == null) {
                    if(GO.transform.name.Contains("Flame")) {
//                         Eng.Flame = ;
                    }
                }
            }
        }
    }
}

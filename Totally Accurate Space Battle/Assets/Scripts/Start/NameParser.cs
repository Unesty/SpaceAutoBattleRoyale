using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class NameParser : MonoBehaviour
{
    public GameObject RocketDestroyedPrefab;
    public GameObject RocketFlame;
    public GameObject projectile;
    [SerializeField] Material shipMaterial;

    public void ParseHierarchy(GameObject Root) {
        ToyProcessor CPU = null;
        PlasmaTurret Gun = null;
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
                GO.GetComponent<Renderer>().material = shipMaterial;
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
                    //read program from file specified as second argument
                    if(File.Exists(Application.dataPath + "/Spaceship Programs/" + subStrings[1])) {
                        CPU.Memory = File.ReadAllBytes(Application.dataPath + "/Spaceship Programs/" + subStrings[1]);
                    } else {
                        Debug.Log("No program for " + subStrings[0] + " in " + Application.persistentDataPath + "/Spaceship Programs" + subStrings[1]);
                    }
                }
                if(Gun)
                    Gun.CPU = CPU;
            } else if(subStrings[0].Contains("RocketEngine")) {
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
            } else if(subStrings[0].Contains("Plasma")) {
                Gun = GO.AddComponent<PlasmaTurret>();
                Gun.projectile = projectile;
                if(CPU)
                    Gun.CPU = CPU;
            }
        }
    }
//     public static void ParseGO(GameObject GO) {
//         if(GO.transform.name.Contains("CPU")) {
//             var CPU = GO.AddComponent<ToyProcessor>();
//             string[] subStrings = GO.transform.name.Split(',');
//             CPU.Memory = System.Text.Encoding.ASCII.GetBytes(subStrings[1]);
//         } else if(GO.transform.name.Contains("RocketEngine")) {
//             var Eng = GO.AddComponent<FuelEngine>();
//             string[] subStrings = GO.transform.name.Split(',');
//             foreach(string name in subStrings) {
//                 if(Eng.CPU == null) {
//                     if(GO.transform.name.Contains("CPU")) {
// //                         Eng.CPU = ;
//                         // how to get these, if hierarhy is hidden from this function?
//                     }
//                 }
//                 if(Eng.Flame == null) {
//                     if(GO.transform.name.Contains("Flame")) {
// //                         Eng.Flame = ;
//                     }
//                 }
//             }
//         }
//     }
}

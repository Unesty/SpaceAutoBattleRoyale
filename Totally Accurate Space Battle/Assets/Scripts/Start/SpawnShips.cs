using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System;
using Siccity.GLTFUtility;
using System.Linq;
using Newtonsoft.Json;
using TMPro;

public class SpawnShips : MonoBehaviour
{
    [SerializeField] float scarsity;
    [SerializeField] StarShipDataManager shipDM;
    //[SerializeField] List<GameObject> ships;

    //Stuff for gltf loading and name parsing
    public List<string> PathToModel;
    [SerializeField] Material shipMaterial;
    [SerializeField] NameParser nameParser;
    [SerializeField] ParseModelstxt parseModelstxt;
    [SerializeField] TMP_Text tmptxt;
    [SerializeField] TeleportingBounds TB;
    EndStarter endStarter;
    // Start is called before the first frame update
    void Start()
    {
        LoadModels();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void LoadModels() {
        endStarter = GameObject.FindWithTag("Finish").GetComponent<EndStarter>();

//         uint cbrt = (uint)Math.Ceiling(Math.Pow(ships.Count, (1.0 / 3.0)));
        uint cbrt = (uint)Math.Ceiling(Math.Pow(10, (1.0 / 3.0)));
        print(cbrt);
//         string[] ptm = parseModelstxt.Parse();
//         if(ptm[0] == "" || ptm[0] == null) {
//             Debug.Log("check Models.txt");
//         }
//         PathToModel = ptm.ToList();
//         foreach(string line in PathToModel) {
//             Debug.Log(line);
//
//         }
        PathToModel = System.IO.Directory.GetFiles( Application.dataPath + "/Spaceship Models").ToList();
        if(PathToModel.Count == 0) {
            Debug.LogError("No models in " +  Application.dataPath + "/Spaceship Models");
            tmptxt.text = "No models in " +  Application.dataPath + "/Spaceship Models";
            return;
        } else {
            tmptxt.text = "";
        }
        for(uint i = 0; i < cbrt; ++i) {
            for(uint h = 0; h < cbrt; ++h) {
                for(uint v = 0; v < cbrt; ++v) {
//                     var ShipToSpawn = UnityEngine.Random.Range(0, ships.Count);
//                     Instantiate(ships[ShipToSpawn], new Vector3(i*scarsity,v*scarsity,h*scarsity), Quaternion.identity);
//                     Instantiate(shipDM.LoadFile([v*h*i]), new Vector3(i*scarsity,v*scarsity,h*scarsity), Quaternion.identity);
//                     ships.RemoveAt(ShipToSpawn);
//                     if(ships.Count == 0) return;

                    // Load model from save file
//                     shipDM.LoadFile();

                    // Load model from gltf file



                    int rnd = UnityEngine.Random.Range(0, PathToModel.Count-1);
                    Debug.Log(rnd + " " + PathToModel.Count);
                    if (!File.Exists(PathToModel[rnd])) {
                        PathToModel.RemoveAt(rnd);
                        Debug.Log("No file " + PathToModel[rnd]);
                        break;
                    }
                    GameObject result = Importer.LoadFromFile(PathToModel[rnd]);
                    if(result == null) {
                        PathToModel.RemoveAt(rnd);
                        if(PathToModel.Count == 0) return;
                        break;
                    }
                    TB.GOToKeepInBounds.Add(result);
                    StarShip unitStats = result.AddComponent<StarShip>();
                    unitStats.endStarter = endStarter;
                    unitStats.thisSpaceship.naem = result.transform.name;
                    unitStats.thisSpaceship.path = PathToModel[rnd];
                    unitStats.thisSpaceship.body = result;
                    unitStats.thisSpaceshipID = endStarter.spaceships.Count;
                    endStarter.spaceships.Add(unitStats.thisSpaceship);
                    result.GetComponent<Renderer>().material = shipMaterial;
                    result.transform.position = new Vector3(i*scarsity,v*scarsity,h*scarsity);
                    var rb = result.AddComponent<Rigidbody>();
//                     NameParser.ParseGO(result);
//                     for (int c = 0; c < transform.childCount; ++c)
//                     {
//                         NameParser.ParseGO(transform.GetChild(c).gameObject);
//                     }
                    nameParser.ParseHierarchy(result);
                    PathToModel.RemoveAt(rnd);
                    if(PathToModel.Count == 0) return;
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;
using UnityEngine;
using System.Runtime.Serialization;
using System.Xml.Linq;
using System.Text;
using System.Xml.Serialization;
using UnityEditor;

public class StarShipDataManager : MonoBehaviour
{
    //save file  
    string saveFile;

    //StarShipData shipData = new StarShipData();
    public StarShipData shipData;

    GameObject StarShip;

    public void Update() {
        //shipData.StarShip = GameObject.FindWithTag("PlayerStarShip");

    }

    public void SaveFile()
    {
        StarShip = GameObject.FindGameObjectWithTag("PlayerStarShip");
        shipData = new StarShipData(StarShip);

        saveFile = Application.persistentDataPath + "/gamedata.json";

        //AssetDatabase.CreateAsset(StarShip, "Assets/Resources/SavedStarShips/" + StarShip.tag + ".prefab");
        PrefabUtility.SaveAsPrefabAssetAndConnect(StarShip, "Assets/Resources/SavedStarShips/" + StarShip.tag + ".prefab", InteractionMode.UserAction);
        Debug.Log(Application.persistentDataPath);

        // Does the file exist?
        if (File.Exists(saveFile))
        {
            // Read the entire file and its contents.
            string fileContents = File.ReadAllText(saveFile);

            // Deserialize the JSON data 
            //  into a pattern matching the StarShipData class.
            JsonUtility.FromJsonOverwrite(fileContents, shipData);
            Debug.Log("Reading save file...");

        }

        // Serialize the object into JSON and save string.
        string jsonString = JsonUtility.ToJson(shipData);
        if (jsonString == null)
        {
            Debug.Log("jsonString NULL!");
        }

        if (saveFile == null)
        {
            Debug.Log("savefile NULL!");
        }

        // Write JSON to file.
        File.WriteAllText(saveFile, jsonString.ToString());
        Debug.Log("Save complete!");
    }

    public void LoadFile() {
        //StarShip = GameObject.FindGameObjectWithTag("PlayerStarShip");
        shipData = new StarShipData();

        saveFile = Application.persistentDataPath + "/gamedata.json";
        // Read the entire file its contents.
        string fileContents = File.ReadAllText(saveFile);
        Debug.Log(fileContents);

        // Deserialize the JSON data 
        //  into a pattern matching the StarShipData class.
        JsonUtility.FromJsonOverwrite(fileContents, shipData);
        Debug.Log("ship tag: " + shipData.tagName);
        GameObject ssobj = Instantiate(Resources.Load("SavedStarShips/" + shipData.tagName, typeof(GameObject))) as GameObject;

        ssobj.transform.localPosition = new Vector3(shipData.pos.x, shipData.pos.y, shipData.pos.z);
        Debug.Log("Load save file...");
    }
}

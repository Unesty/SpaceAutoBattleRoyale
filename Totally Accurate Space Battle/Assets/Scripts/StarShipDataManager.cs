using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;
using UnityEngine;

public class StarShipDataManager : MonoBehaviour
{
    //save file  
    string saveFile;

    StarShipData shipData = new StarShipData();

    GameObject StarShip;

    void Awake()
    {
        // Update the field once the persistent path exists.
        Debug.Log(Application.persistentDataPath + "/gamedata.json");
    }

    public void ReadFile()
    {
        shipData.GetStarShipObject();
        saveFile = Application.persistentDataPath + "/gamedata.json";

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
    }

    public void WriteFile()
    {
        
        // Serialize the object into JSON and save string.
        string jsonString = JsonUtility.ToJson(shipData);
        if (jsonString == null) {
            Debug.Log("jsonString NULL!");
        }

        if (saveFile == null) {
           Debug.Log("savefile NULL!");
        }

        // Write JSON to file.
        File.WriteAllText(saveFile, jsonString);
        Debug.Log("Save complete!");

    }

    public void LoadFile() {
        Debug.Log("Load save file...");
        saveFile = Application.persistentDataPath + "/gamedata.json";
        // Read the entire file its contents.
        string fileContents = File.ReadAllText(saveFile);

        // Deserialize the JSON data 
        //  into a pattern matching the StarShipData class.
        JsonUtility.FromJsonOverwrite(fileContents, shipData);
        StarShip = shipData.StarShip;
        Debug.Log(StarShip.GetInstanceID());
    }
}

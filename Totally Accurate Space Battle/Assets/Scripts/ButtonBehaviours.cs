using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviours : MonoBehaviour
{
    StarShipDataManager shipData;

    public void Awake() {
        shipData = new StarShipDataManager();
    }

    public void SaveModel()
    {
        Debug.Log("Save Button clicked");
        //StarShipDataManager shipData = new StarShipDataManager();
        shipData.SaveFile();
    }

    public void LoadModel() {
        Debug.Log("Load Button clicked");
        //StarShipDataManager shipData = new StarShipDataManager();
        shipData.LoadFile();
    }

    /*
    * Testing functionality for load/write save file
    */
    public void DeleteShip()
    {
        //JsonUtility.FromJsonOverwrite(file, shipData);
        GameObject StarShip = GameObject.FindGameObjectWithTag("PlayerStarShip");
        Destroy(StarShip);
    }
}

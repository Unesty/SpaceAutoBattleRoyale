using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviours : MonoBehaviour
{
    public void SaveModel()
    {
        Debug.Log("Save Button clicked");
        StarShipDataManager shipData = new StarShipDataManager();
        shipData.ReadFile();
        shipData.WriteFile();
    }

    public void LoadModel() {
        Debug.Log("Load Button clicked");
        StarShipDataManager shipData = new StarShipDataManager();
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

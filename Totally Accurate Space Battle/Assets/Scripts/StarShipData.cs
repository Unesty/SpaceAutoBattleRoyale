using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class StarShipData
{
    /* the object we want to save is the star ship model
    *  and the list of parts added on the star ship
    */
    //public GameObject StarShipObj;
    public GameObject StarShipObj;
    public Vector3 pos;
    public string tagName;
    public string prefabName;

    //List<GameObject> StarShipParts;

    // GetStarShip is called when the player clicks Save Model
    public StarShipData(GameObject StarShip)
    {
        StarShipObj = StarShip;
        //StarShip.ToString();
        if (StarShipObj == null) {
            Debug.Log("Star Ship game object is null.");
        }

        tagName = StarShipObj.tag;
        prefabName = tagName;
        pos.x = StarShipObj.transform.localPosition.x;
        pos.y = StarShipObj.transform.localPosition.y;
        pos.z = StarShipObj.transform.localPosition.z;

        /*StarShipParts = StarShip.GetComponentsInChildren<GameObject>();
        for (int i = 0; i < StarShipParts.Length; i++)
        {
            GameObject shipParts = StarShipParts[i];
            Debug.Log(shipParts);
        }*/
    }
}

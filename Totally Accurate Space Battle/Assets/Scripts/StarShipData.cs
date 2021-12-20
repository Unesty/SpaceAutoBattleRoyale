using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class StarShipData : MonoBehaviour
{
    /* the object we want to save is the star ship model
    *  and the list of parts added on the star ship
    */
    public GameObject StarShip;
    public Vector3 pos;
    public GameObject[] StarShipParts;
    //List<GameObject> StarShipParts;

    // GetStarShip is called when the player clicks Save Model
    public void GetStarShipObject()
    {

        StarShip = GameObject.FindWithTag("PlayerStarShip");
        //StarShip.ToString();
        if (StarShip == null) {
            Debug.Log("Star Ship game object is null.");
        }

        pos.x = StarShip.transform.localPosition.x;
        pos.y = StarShip.transform.localPosition.y;
        pos.z = StarShip.transform.localPosition.z;

        /*StarShipParts = StarShip.GetComponentsInChildren<GameObject>();
        for (int i = 0; i < StarShipParts.Length; i++)
        {
            GameObject shipParts = StarShipParts[i];
            Debug.Log(shipParts);
        }*/
    }
}

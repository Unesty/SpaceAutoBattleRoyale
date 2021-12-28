using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class StarShip : MonoBehaviour
{
    // This script can be used to save statistics of starship

    // This script is the main part for now, so this can be here
    public static int count { get; private set; }
    public EndStarter endStarter;
    public EndStarter.Spaceship thisSpaceship = new EndStarter.Spaceship(); //these values will be set by spawner
    public int thisSpaceshipID;
    // Start is called before the first frame update
    void Start()
    {
        count++;
//         endStarter = GameObject.FindWithTag("Finish").GetComponent<EndStarter>();
//         endStarter.spaceships.Add(thisSpaceship);
    }

    // Update is called once per frame
//     void Update()
//     {
//
//     }

    void OnDestroy()
    {
        MainPartDestroyed();
    }

    public void MainPartDestroyed() {
        --count;
//         endStarter.Survivors.Remove(gameObject);
        endStarter.spaceships[thisSpaceshipID].deathDate = DateTime.Now.ToString("F");
        endStarter.places.Insert(0, endStarter.spaceships[thisSpaceshipID]);
        switch(count) {
            case 0:
                Debug.Log("No survivors");
                break;
            case 1:
                Debug.Log(count);
                endStarter.LastSurvivor();

                break;
            default:
                Debug.Log(count);
                break;
        }
    }
}

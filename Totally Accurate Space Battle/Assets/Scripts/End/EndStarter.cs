using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class EndStarter : MonoBehaviour
{
//     public List<GameObject> Survivors;
//     public List<GameObject> Deads;
    [Serializable]
    public class Spaceship {
        public string naem;
        public string path;
        public GameObject body;
        public string deathDate;
    }
    public List<Spaceship> spaceships = new List<Spaceship>();
    public List<Spaceship> places;
    [SerializeField] TMP_Text tmptxt;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
//     void FixedUpdate() {
//         foreach(GameObject GO in Survivors) {
//             if(GO == null) {
//                 Survivors.Remove(GO);
//             }
//         }
//     }

    public void LastSurvivor() {
//         if(spaceships.Count == 1) {
            List<Spaceship> _Survivors = new List<Spaceship>();
            foreach(Spaceship unit in spaceships) {
                if((unit.body != null) & (string.IsNullOrEmpty(unit.deathDate))) {
                    _Survivors.Add(unit);
                    Debug.Log("id " + spaceships.IndexOf(unit) + " name " + unit.deathDate);
                }
            }
            if(_Survivors.Count > 1) {
                Debug.LogError("There are " + _Survivors.Count + " survivors, but spaceships.Count is 1");
                return;
            } else if(_Survivors.Count == 0) {
                Debug.LogError("There is no survivors, but spaceships.Count is 1");
                return;
            }
            places.Insert(0, _Survivors[0]);
            Debug.Log("The winner is: " + places[0].naem + "!");
            tmptxt.text = "The winner is: " + places[0].naem + "!";
//         } else {
//             Debug.LogError("Survivors Count can't be not 1");
//         }
    }
}

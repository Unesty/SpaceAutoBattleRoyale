using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public void LoadConstructor() {
        SceneManager.LoadScene("Constructor");
    }
    public void LoadAsteroids() {
        SceneManager.LoadScene("Asteroids");
    }

    public int width = 640;
    public int height = 480;
    public bool fullscreen = true;
    public TMP_InputField WidthTMP_IF;
    public TMP_InputField HeightTMP_IF;

    public void WidthTexChange(string input) {
        if(WidthTMP_IF.text != "" || WidthTMP_IF.text != null)
        width = int.Parse(WidthTMP_IF.text);
    }
    public void HeightTexChange(string input) {
        if(HeightTMP_IF.text != "" || HeightTMP_IF.text != null)
        height = int.Parse(HeightTMP_IF.text);
    }
    public void SetReso() {
        Screen.SetResolution(width, height, fullscreen);
    }
    public void SwitchFullscreen() {
        fullscreen = !fullscreen;
        Screen.SetResolution(width, height, fullscreen);
    }

    public void SetVolume(float val) {
        AudioListener.volume = val;
    }
    public void Quit() {
        Application.Quit();
    }
    // Create game
    // Ain't nobody got time for that
//     public TMP_InputField VesselCountTMP_IF;
//     int vesselCount = 2;
//
//     [SerializeField] GameObject InputFieldPrefab;
//     [SerializeField] GameObject MPParent;
//     [SerializeField] int MPDistance = 40;
//     // stuff to create input fields
//     [Serializable] public class PathInp {
//         public string path;
//         public TMP_InputField TMP_IF;
//         public GameObject GO;
//     }
//     List<PathInp> MP = new List<PathInp>(); // MP is Model Path. Models here are GLTF 3d models of spaceships
//
//     public void VesselCountTextChange() {
//         if(VesselCountTMP_IF.text != "" || VesselCountTMP_IF.text != null) {
//             vesselCount = (int)uint.Parse(VesselCountTMP_IF.text);
//         }
//     }
//     public void VesselCountTextEnd() {
//         if(vesselCount == 0) return;
//         if(MP.Count > vesselCount) {
//             for(int i = vesselCount; i < MP.Count; ++i) {
//                 Destroy(MP[i].GO);
//             }
//             MP.RemoveRange(vesselCount, MP.Count - vesselCount);
//         } else {
//             for(int i = MP.Count; i < vesselCount; ++i) {
//                 var GO = Instantiate(InputFieldPrefab,  MPParent.transform.position + new Vector3(0, -i*MPDistance, 0),  MPParent.transform.rotation, MPParent.transform);
//                 GO.GetComponent<TMP_InputField>().OnValueChanged = ModelPathTextChange;
//                 PathInp toAdd = new PathInp();
//                 toAdd.TMP_IF = GO.GetComponent<TMP_InputField>();
//                 toAdd.GO = GO;
//                 MP.Add(toAdd);
//             }
//         }
//     }
//     public void ModelPathTextChange(string _id) {
//         int id = int.Parse(_id);
//         MP[id].path = MP[id].TMP_IF.text;
//     }
}

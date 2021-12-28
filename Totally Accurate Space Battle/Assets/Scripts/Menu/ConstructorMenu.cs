using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using Siccity.GLTFUtility;
using TMPro;

public class ConstructorMenu : MonoBehaviour
{
    public void LoadMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadScene(string scene) {
        SceneManager.LoadScene(scene);
    }
    [SerializeField] Material yourMaterial;
    public TMP_InputField Path;
    public void LoadModel() {
        GameObject result = Importer.LoadFromFile(Path.text);
        result.GetComponent<Renderer>().material = yourMaterial;
    }
    public void OpenModelLoadingDialog() {
        string uri = "file:///";
        //TODO
        GameObject result = Importer.LoadFromFile(uri);
    }
}

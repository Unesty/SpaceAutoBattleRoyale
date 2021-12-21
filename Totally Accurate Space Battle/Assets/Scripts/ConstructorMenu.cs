using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConstructorMenu : MonoBehaviour
{
    public void LoadMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadScene(string scene) {
        SceneManager.LoadScene(scene);
    }
}

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

    public int width = 1920;
    public int height = 1080;
    public bool fullscreen = true;
    public TMP_InputField WidthTMP_IF;
    public TMP_InputField HeightTMP_IF;

    public void WidthTexChange(string input) {
        width = int.Parse(WidthTMP_IF.text);
    }
    public void HeightTexChange(string input) {
        height = int.Parse(HeightTMP_IF.text);
    }
    public void SetReso() {
        Screen.SetResolution(width, height, fullscreen);
    }
    public void SwitchFullscreen() {
        fullscreen = !fullscreen;
    }

    public void SetVolume(float val) {


    }
}

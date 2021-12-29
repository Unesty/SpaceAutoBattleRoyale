using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IngameUI : MonoBehaviour
{
    public void BackToMain() {
        SceneManager.LoadScene("MainMenu");
    }
    public int currentId = 0;
    public GameObject cam;
    public Vector3 offset;
    public EndStarter reff;
    public UnityTemplateProjects.SimpleCameraController scc;
    public void GotoShip() {
        scc.enabled = false;
        cam.transform.position = reff.spaceships[currentId].body.transform.position + offset;
        cam.transform.LookAt(reff.spaceships[currentId].body.transform.position);

        currentId++;
        if(currentId >= reff.spaceships.Count)
            currentId = 0;
        scc.enabled = true;
    }
}

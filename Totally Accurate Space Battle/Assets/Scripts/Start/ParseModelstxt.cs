using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ParseModelstxt : MonoBehaviour
{
    public string[] Parse() {
        string txtpath = Application.persistentDataPath + "/Models.txt";
        // Does the file exist?
        if (File.Exists(txtpath))
        {
            // Read the entire file and its contents.
            string fileContents = File.ReadAllText(txtpath);
            return fileContents.Split('\n');
        } else {
            Debug.LogError("No Models.txt in " + Application.persistentDataPath);
            return null;
        }
    }
}

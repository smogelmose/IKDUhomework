using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TextScript : MonoBehaviour
{
    
    void CreateText()
    {   
        // Path of file
        string path = Application.dataPath + "/Log.txt";
        // Create file if ! exits
        if(!File.Exists(path))
        {
            File.WriteAllText(path, "Results log \n\n");
        }
        // Content of file
        string content = "Results date: " + System.DateTime.Now + "\n ";
                // Add text to file
        File.AppendAllText(path, content);
    }
    // Start is called before the first frame update
    void Start()
    {
        // Initialization
        CreateText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

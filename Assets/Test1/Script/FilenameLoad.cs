using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FilenameLoad : MonoBehaviour
{   
    public static string filename;
    
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("InputFilename"))
        {
            filename = PlayerPrefs.GetString("InputFilename");
            Debug.Log(filename);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

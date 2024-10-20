using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FilenameSave : MonoBehaviour
{
    public InputField inputField;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveFilename()
    {
        string inputText = inputField.text;
        PlayerPrefs.SetString("InputFilename", inputText);
        PlayerPrefs.Save();
    }
}

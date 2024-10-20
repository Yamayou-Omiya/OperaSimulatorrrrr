using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class csvStart : MonoBehaviour
{
    private StreamWriter sw;
    private float timeNow;
    private float timeStart;
    
    // Start is called before the first frame update
    void Start()
    {
        timeStart = Time.realtimeSinceStartup;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MakeFile(string filename)
    {
        sw = new StreamWriter(@"Assets/ExperimentData/"+filename+"_start.csv", false, Encoding.UTF8);
        string[] s1 = {"time"};
        string s2 = string.Join(",", s1);
        sw.WriteLine(s2);
    }
}

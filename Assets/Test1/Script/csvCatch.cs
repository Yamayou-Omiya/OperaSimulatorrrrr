using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class csvCatch : MonoBehaviour
{
    private StreamWriter sw;
    private float timeNow;
    private float timeStart;

    int catchAmount;

    bool IsCheck = false;
    bool IsFileMade = false;

    bool check;

    // Start is called before the first frame update
    void Start()
    {
        timeStart = Time.realtimeSinceStartup;
        catchAmount = 0;
        check = false;    
    }

    // Update is called once per frame
    void Update()
    {
        if(!IsFileMade)
        {
            MakeFile(FilenameLoad.filename);
            IsFileMade = true;
        }

        if(IsCheck)
        {
            timeNow = Time.realtimeSinceStartup - timeStart;
            if(check)
            {
                string[] s1 = {timeNow.ToString(), catchAmount.ToString()};
                string s2 = string.Join(",", s1);
                sw.WriteLine(s2);
                check = false;
            }
        }
    }

    public void CountCatchAmount()
    {
        catchAmount++;
        check = true;
    }

    private void OnApplicationQuit()
    {
        if (IsCheck)
        {
            sw.Close();
        }
    }

    public void MakeFile(string filename)
    {
        sw = new StreamWriter(@"Assets/ExperimentData/"+filename+"_catch_amount.csv", false, Encoding.UTF8);
        string[] s1 = { "time", "catch_amount"};
        string s2 = string.Join(",", s1);
        sw.WriteLine(s2);
        IsCheck = true;
    }
}

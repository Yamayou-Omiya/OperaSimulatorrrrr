using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class csvAnswerTime : MonoBehaviour
{
    private StreamWriter sw;
    private float timeNow;
    private float timeStart;

    float[,] allAnsTime = new float[6, 3];
    float[] ansTime = new float[6];

    bool IsCheck = false;
    bool IsFileMade = false;

    bool check;

    
    // Start is called before the first frame update
    void Start()
    {
        timeStart = Time.realtimeSinceStartup;
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

        allAnsTime = QuestionAndRecord.allAnsTime;
        ansTime = QuestionAndRecord.AnsTime;

        if(IsCheck)
        {
            timeNow = Time.realtimeSinceStartup - timeStart;
            for(int i = 0; i < 6; i++)
            {
                string[] s1 = {timeNow.ToString(), allAnsTime[i, 0].ToString(), allAnsTime[i, 1].ToString(), allAnsTime[i, 2].ToString(), ansTime[i].ToString()};
                string s2 = string.Join(",", s1);
                sw.WriteLine(s2);
            }
        }
    }
    private void OnApplicationQuit()
    {
        if (IsCheck)
        {
            sw.Close();
        }
    }

    public void Catch(string catchNum, string areaDiameter, string areaPosX, string areaPosZ, string sardinePosX, string sardinePosZ)
    {
        if(IsCheck)
        {
            timeNow = Time.realtimeSinceStartup - timeStart;
            string[] s1 = {timeNow.ToString(), catchNum, areaDiameter, areaPosX, areaPosZ, sardinePosX, sardinePosZ};
            string s2 = string.Join(",", s1);
            sw.WriteLine(s2);
        }
    }

    public void MakeFile(string filename)
    {
        sw = new StreamWriter(@"Assets/ExperimentData/"+filename+"_answertime.csv", false, Encoding.UTF8);
        string[] s1 = { "time", "ansTime1", "ansTime2", "ansTime3", "ansTimeAve" };
        string s2 = string.Join(",", s1);
        sw.WriteLine(s2);
        IsCheck = true;
    }
}

using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class csvQuestionRecord : MonoBehaviour
{
    private StreamWriter sw;
    private float timeNow;
    private float timeStart;
    bool IsCheck = false;
    bool IsFileMade = false;
    
    // Start is called before the first frame update
    void Start()
    {
        timeStart = Time.realtimeSinceStartup;
    }

    // Update is called once per frame
    void Update()
    {
        if(!IsFileMade)
        {
            MakeFile(FilenameLoad.filename);
            IsFileMade = true;
        }
    }

    public void LeftAnswerRecord(string question, string c, string ansState, string ansTime)
    {
        if(IsCheck)
        {
            timeNow = Time.realtimeSinceStartup - timeStart;
            string[] s1 = {timeNow.ToString(), "left", question, c, ansState, ansTime};
            string s2 = string.Join(",", s1);
            sw.WriteLine(s2);
        }
    }

    public void RightAnswerRecord(string question, string c, string ansState, string ansTime)
    {
        if(IsCheck)
        {
            timeNow = Time.realtimeSinceStartup - timeStart;
            string[] s1 = {timeNow.ToString(), "right", question, c, ansState, ansTime};
            string s2 = string.Join(",", s1);
            sw.WriteLine(s2);
        }
    }

    private void OnApplicationQuit()
    {
        if(IsCheck)
        {
            sw.Close();
        }
    }

    public void MakeFile(string filename)
    {
        sw = new StreamWriter(@"Assets/ExperimentData/"+filename+"_question_record.csv", false, Encoding.UTF8);
        string[] s1 = { "Time", "LorR", "Question", "Character", "Answer_State", "Answer_Time"};
        string s2 = string.Join(",", s1);
        sw.WriteLine(s2);
        IsCheck = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private int minute;
    private float second;
    private float pastSecond;
    public Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        minute = 0;
        second = 0f;
        pastSecond = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(AreaController.gameStart)
        {
            second += Time.deltaTime;
            if(second >= 60f)
            {
                minute++;
                second = second - 60;
            }
            if((int)second != (int)pastSecond)
            {
                if(minute < 10)
                {
                    if((int)second < 10)
                    {
                        timeText.text = "0" + minute + ":0" + (int)second;            
                    }
                    else
                    {
                        timeText.text = "0" + minute + ":" + (int)second;
                    }
                }
                else
                {
                    if((int)second < 10)
                    {
                        timeText.text = minute + ":0" + (int)second;            
                    }
                    else
                    {
                        timeText.text = minute + ":" + (int)second;
                    }
                }
            }
            pastSecond = second;
        }
    }
}
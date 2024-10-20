using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FootSwitch : MonoBehaviour
{
    GameObject pop1;
    bool leftSw = true;
    bool rightSw = true;
    public AudioClip sound;
    
    // Start is called before the first frame update
    void Start()
    {
        pop1 = GameObject.Find("Sub Task");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.KeypadMinus))
        {
            if(leftSw)
            {
                leftSw = false;
                pop1.GetComponent<QuestionAndRecord>().LeftAnswer();
                pop1.GetComponent<AudioSource>().PlayOneShot(sound);
            }
        }
        else
        {
            leftSw = true;
        }

        if(Input.GetKey(KeyCode.KeypadPlus))
        {
            if(rightSw)
            {
                rightSw = false;
                pop1.GetComponent<QuestionAndRecord>().RightAnswer();
                pop1.GetComponent<AudioSource>().PlayOneShot(sound);
            }
        }
        else
        {
            rightSw = true;
        }
    }
}

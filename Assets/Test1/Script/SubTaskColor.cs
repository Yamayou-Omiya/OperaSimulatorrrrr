using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubTaskColor : MonoBehaviour
{
    public static bool subColor1 = false;
    public static bool subColor2 = false;
    public static bool subColor3 = false;

    public Text subColorText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Button1Clicked()
    {
        subColor1 = true;
        subColor2 = false;
        subColor3 = false;
        subColorText.text = "1";
    }
    public void Button2Clicked()
    {
        subColor1 = false;
        subColor2 = true;
        subColor3 = false;
        subColorText.text = "2";
    }
    public void Button3Clicked()
    {
        subColor1 = false;
        subColor2 = false;
        subColor3 = true;
        subColorText.text = "3";
    }
}
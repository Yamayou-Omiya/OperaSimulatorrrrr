using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubTaskLevel : MonoBehaviour
{
    public static bool subLevel1 = false;
    public static bool subLevel2 = false;
    public static bool subLevel3 = false;

    public Text subLevelText;

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
        subLevel1 = true;
        subLevel2 = false;
        subLevel3 = false;
        subLevelText.text = "1";
    }
    public void Button2Clicked()
    {
        subLevel1 = false;
        subLevel2 = true;
        subLevel3 = false;
        subLevelText.text = "2";
    }
    public void Button3Clicked()
    {
        subLevel1 = false;
        subLevel2 = false;
        subLevel3 = true;
        subLevelText.text = "3";
    }
}
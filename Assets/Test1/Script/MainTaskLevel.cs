using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTaskLevel : MonoBehaviour
{
    public static bool mainLevel1 = false;
    public static bool mainLevel2 = false;
    public static bool mainLevel3 = false;
    public static bool mainLevel4 = false;
    public static bool mainLevel5 = false;


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
        mainLevel1 = true;
        mainLevel2 = false;
        mainLevel3 = false;
        mainLevel4 = false;
        mainLevel5 = false;
    }
    public void Button2Clicked()
    {
        mainLevel1 = false;
        mainLevel2 = true;
        mainLevel3 = false;
        mainLevel4 = false;
        mainLevel5 = false;
    }
    public void Button3Clicked()
    {
        mainLevel1 = false;
        mainLevel2 = false;
        mainLevel3 = true;
        mainLevel4 = false;
        mainLevel5 = false;
    }
    public void Button4Clicked()
    {
        mainLevel1 = false;
        mainLevel2 = false;
        mainLevel3 = false;
        mainLevel4 = true;
        mainLevel5 = false;
    }
    public void Button5Clicked()
    {
        mainLevel1 = false;
        mainLevel2 = false;
        mainLevel3 = false;
        mainLevel4 = false;
        mainLevel5 = true;
    }
}
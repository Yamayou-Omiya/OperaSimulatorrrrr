using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenPosition : MonoBehaviour
{
    public static bool screenPosition1 = false;
    public static bool screenPosition2 = false;
    public static bool screenPosition3 = false;
    public static bool screenPositionFull = false;    
    
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
        screenPosition1 = true;
        screenPosition2 = false;
        screenPosition3 = false;
        screenPositionFull = false;
    }
    public void Button2Clicked()
    {
        screenPosition1 = false;
        screenPosition2 = true;
        screenPosition3 = false;
        screenPositionFull = false;
    }
    public void Button3Clicked()
    {
        screenPosition1 = false;
        screenPosition2 = false;
        screenPosition3 = true;
        screenPositionFull = false;
    }
    public void ButtonFullClicked()
    {
        screenPosition1 = false;
        screenPosition2 = false;
        screenPosition3 = false;
        screenPositionFull = true;
    }
}

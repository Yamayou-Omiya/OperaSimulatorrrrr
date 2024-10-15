using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour
{
    public Camera mainCam;

    public bool Cam0;
    public bool Cam1;
    public bool Cam2;
    public bool Cam3;
    
    // Start is called before the first frame update
    void Start()
    {
        if(ChangeScene.start)
        {
            Cam0 = ScreenPosition.screenPositionFull;
            Cam1 = ScreenPosition.screenPosition1;
            Cam2 = ScreenPosition.screenPosition2;
            Cam3 = ScreenPosition.screenPosition3;
        }

        if(Cam0)
        {
            mainCam.rect = new Rect(0f, 0f, 1f, 1f);
        }
        else if(Cam1)
        {
            mainCam.rect = new Rect(0f, 0.5f, 0.5f, 0.5f);
        }
        else if(Cam2)
        {
            mainCam.rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
        }
        else if(Cam3)
        {
            mainCam.rect = new Rect(0.25f, 0f, 0.5f, 0.5f);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour
{
    public Camera mainCam;
    public Camera subCam1;
    public Camera subCam2;

    public static bool cam0;
    public static bool cam1;
    public static bool cam2;
    public static bool cam3;

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

        cam0 = Cam0;
        cam1 = Cam1;
        cam2 = Cam2;
        cam3 = Cam3;

        if(Cam0)
        {
            mainCam.rect = new Rect(0f, 0f, 1f, 1f);
            //subCam1.SetActive(false);
            //subCam2.SetActive(false);          
        }
        else if(Cam1)
        {
            mainCam.rect = new Rect(0f, 0.5f, 0.5f, 0.5f);
            subCam1.rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
            subCam2.rect = new Rect(0.25f, 0f, 0.5f, 0.5f);
        }
        else if(Cam2)
        {
            mainCam.rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
            subCam1.rect = new Rect(0f, 0.5f, 0.5f, 0.5f);
            subCam2.rect = new Rect(0.25f, 0f, 0.5f, 0.5f);
        }
        else if(Cam3)
        {
            mainCam.rect = new Rect(0.25f, 0f, 0.5f, 0.5f);
            subCam1.rect = new Rect(0f, 0.5f, 0.5f, 0.5f);
            subCam2.rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

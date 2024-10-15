using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    public Text alertText;
    public static bool start = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DebugButtonClicked()
    {
        SceneManager.LoadScene("TestScene2");
    }
    public void StartButtonClicked()
    {
        if(MainTaskLevel.mainLevel1||MainTaskLevel.mainLevel2||MainTaskLevel.mainLevel3||MainTaskLevel.mainLevel4||MainTaskLevel.mainLevel5)
        {
            if(SubTaskLevel.subLevel1||SubTaskLevel.subLevel2||SubTaskLevel.subLevel3)
            {
                if(ScreenPosition.screenPosition1||ScreenPosition.screenPosition2||ScreenPosition.screenPosition3||ScreenPosition.screenPositionFull)
                {
                    SceneManager.LoadScene("TestScene2");
                    start = true;
                }
                else
                {
                    alertText.text = "Select Number!!";
                    alertText.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
                }
            }
            else
            {
                alertText.text = "Select Number!!";
                alertText.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
            }
        }
        else
        {
            alertText.text = "Select Number!!";
            alertText.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
        }
    }
}

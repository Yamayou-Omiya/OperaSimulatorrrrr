using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Globalization;

public class HeatmapDrawer : MonoBehaviour
{
    private float[] AnswerTime = new float[6];
    private string[] AnswerTimeString = new string[6];

    bool main1sub1 = false;
    bool main1sub2 = false;
    bool main1sub3 = false;
    bool main2sub1 = false;
    bool main2sub2 = false;
    bool main2sub3 = false;
    bool main3sub1 = false;
    bool main3sub2 = false;
    bool main3sub3 = false;

    bool hmSwitch = true;

    float red;
    float green;
    float blue;

    [SerializeField] public List<Image> hmImage = new List<Image>();
    [SerializeField] public List<Text> hmText = new List<Text>();

    List<Color> hmColor = new List<Color>();
    List<string> hmTime = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 6; i++)
        {
            hmImage[i].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            hmText[i].text = "";
        }

        if(MainCameraController.cam1)
        {
            if(QuestionAndRecord.subLevel1)
            {
                main1sub1 = true;
            }
            else if(QuestionAndRecord.subLevel2)
            {
                main1sub2 = true;
            }
            else if(QuestionAndRecord.subLevel3)
            {
                main1sub3 = true;
            }
        }
        else if(MainCameraController.cam2)
        {
            if(QuestionAndRecord.subLevel1)
            {
                main2sub1 = true;
            }
            else if(QuestionAndRecord.subLevel2)
            {
                main2sub2 = true;
            }
            else if(QuestionAndRecord.subLevel3)
            {
                main2sub3 = true;
            }
        }
        else if(MainCameraController.cam3)
        {
            if(QuestionAndRecord.subLevel1)
            {
                main3sub1 = true;
            }
            else if(QuestionAndRecord.subLevel2)
            {
                main3sub2 = true;
            }
            else if(QuestionAndRecord.subLevel3)
            {
                main3sub3 = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        AnswerTime = QuestionAndRecord.AnsTime;

        hmSwitch = true;

        if(main1sub1)
        {
            for(int i = 0; i < 6; i++)
            {
                if(AnswerTime[i] > 6.0f)
                {
                    hmSwitch = false;
                }
            }        
            
            if(hmSwitch)
            {
                HeatmapSetting();
                
                hmImage[9].color = hmColor[0];
                hmImage[12].color = hmColor[1];
                hmImage[15].color = hmColor[2];
                hmImage[18].color = hmColor[3];
                hmImage[19].color = hmColor[4];
                hmImage[21].color = hmColor[5];

                hmText[9].text = hmTime[0];
                hmText[12].text = hmTime[1];
                hmText[15].text = hmTime[2];
                hmText[18].text = hmTime[3];
                hmText[19].text = hmTime[4];
                hmText[21].text = hmTime[5];
            }
        }
        if(main1sub2)
        {
            for(int i = 0; i < 6; i++)
            {
                if(AnswerTime[i] > 6.0f)
                {
                    hmSwitch = false;
                }
            }
            
            if(hmSwitch)
            {
                HeatmapSetting();
                
                hmImage[10].color = hmColor[0];
                hmImage[13].color = hmColor[1];
                hmImage[16].color = hmColor[2];
                hmImage[20].color = hmColor[3];
                hmImage[22].color = hmColor[4];
                hmImage[24].color = hmColor[5];

                hmText[10].text = hmTime[0];
                hmText[13].text = hmTime[1];
                hmText[16].text = hmTime[2];
                hmText[20].text = hmTime[3];
                hmText[22].text = hmTime[4];
                hmText[24].text = hmTime[5];
            }
        }
        if(main1sub3)
        {
            for(int i = 0; i < 6; i++)
            {
                if(AnswerTime[i] > 6.0f)
                {
                    hmSwitch = false;
                }
            }        
            
            if(hmSwitch)
            {
                HeatmapSetting();
                
                hmImage[11].color = hmColor[0];
                hmImage[14].color = hmColor[1];
                hmImage[17].color = hmColor[2];
                hmImage[23].color = hmColor[3];
                hmImage[25].color = hmColor[4];
                hmImage[26].color = hmColor[5];

                hmText[11].text = hmTime[0];
                hmText[14].text = hmTime[1];
                hmText[17].text = hmTime[2];
                hmText[23].text = hmTime[3];
                hmText[25].text = hmTime[4];
                hmText[26].text = hmTime[5];
            }
        }
        if(main2sub1)
        {
            for(int i = 0; i < 6; i++)
            {
                if(AnswerTime[i] > 6.0f)
                {
                    hmSwitch = false;
                }
            }        
            
            if(hmSwitch)
            {
                HeatmapSetting();
                
                hmImage[2].color = hmColor[0];
                hmImage[5].color = hmColor[1];
                hmImage[8].color = hmColor[2];
                hmImage[19].color = hmColor[3];
                hmImage[20].color = hmColor[4];
                hmImage[23].color = hmColor[5];

                hmText[2].text = hmTime[0];
                hmText[5].text = hmTime[1];
                hmText[8].text = hmTime[2];
                hmText[19].text = hmTime[3];
                hmText[20].text = hmTime[4];
                hmText[23].text = hmTime[5];

                Debug.Log("hm_in");
            }
        }
        if(main2sub2)
        {
            for(int i = 0; i < 6; i++)
            {
                if(AnswerTime[i] > 6.0f)
                {
                    hmSwitch = false;
                }
            }        
            
            if(hmSwitch)
            {
                HeatmapSetting();
                
                hmImage[1].color = hmColor[0];
                hmImage[4].color = hmColor[1];
                hmImage[7].color = hmColor[2];
                hmImage[18].color = hmColor[3];
                hmImage[22].color = hmColor[4];
                hmImage[26].color = hmColor[5];

                hmText[1].text = hmTime[0];
                hmText[4].text = hmTime[1];
                hmText[7].text = hmTime[2];
                hmText[18].text = hmTime[3];
                hmText[22].text = hmTime[4];
                hmText[26].text = hmTime[5];
            }
        }
        if(main2sub3)
        {
            for(int i = 0; i < 6; i++)
            {
                if(AnswerTime[i] > 6.0f)
                {
                    hmSwitch = false;
                }
            }        
            
            if(hmSwitch)
            {
                HeatmapSetting();
                
                hmImage[0].color = hmColor[0];
                hmImage[3].color = hmColor[1];
                hmImage[6].color = hmColor[2];
                hmImage[21].color = hmColor[3];
                hmImage[24].color = hmColor[4];
                hmImage[25].color = hmColor[5];

                hmText[0].text = hmTime[0];
                hmText[3].text = hmTime[1];
                hmText[6].text = hmTime[2];
                hmText[21].text = hmTime[3];
                hmText[24].text = hmTime[4];
                hmText[25].text = hmTime[5];
            }
        }
        if(main3sub1)
        {
            for(int i = 0; i < 6; i++)
            {
                if(AnswerTime[i] > 6.0f)
                {
                    hmSwitch = false;
                }
            }        
            
            if(hmSwitch)
            {
                HeatmapSetting();
                
                hmImage[5].color = hmColor[0];
                hmImage[7].color = hmColor[1];
                hmImage[8].color = hmColor[2];
                hmImage[12].color = hmColor[3];
                hmImage[15].color = hmColor[4];
                hmImage[16].color = hmColor[5];

                hmText[5].text = hmTime[0];
                hmText[7].text = hmTime[1];
                hmText[8].text = hmTime[2];
                hmText[12].text = hmTime[3];
                hmText[15].text = hmTime[4];
                hmText[16].text = hmTime[5];
            }
        }
        if(main3sub2)
        {
            for(int i = 0; i < 6; i++)
            {
                if(AnswerTime[i] > 6.0f)
                {
                    hmSwitch = false;
                }
            }        
            
            if(hmSwitch)
            {
                HeatmapSetting();
                
                hmImage[2].color = hmColor[0];
                hmImage[4].color = hmColor[1];
                hmImage[6].color = hmColor[2];
                hmImage[9].color = hmColor[3];
                hmImage[13].color = hmColor[4];
                hmImage[17].color = hmColor[5];

                hmText[2].text = hmTime[0];
                hmText[4].text = hmTime[1];
                hmText[6].text = hmTime[2];
                hmText[9].text = hmTime[3];
                hmText[13].text = hmTime[4];
                hmText[17].text = hmTime[5];
            }
        }
        if(main3sub3)
        {
            for(int i = 0; i < 6; i++)
            {
                if(AnswerTime[i] > 6.0f)
                {
                    hmSwitch = false;
                }
            }        
            
            if(hmSwitch)
            {
                HeatmapSetting();
                
                hmImage[0].color = hmColor[0];
                hmImage[1].color = hmColor[1];
                hmImage[3].color = hmColor[2];
                hmImage[10].color = hmColor[3];
                hmImage[11].color = hmColor[4];
                hmImage[14].color = hmColor[5];

                hmText[0].text = hmTime[0];
                hmText[1].text = hmTime[1];
                hmText[3].text = hmTime[2];
                hmText[10].text = hmTime[3];
                hmText[11].text = hmTime[4];
                hmText[14].text = hmTime[5];
            }
        }
    }

    private void HeatmapSetting()
    {
        for(int i = 0; i < 6; i++)
        {
            if(AnswerTime[i] >= 0f && AnswerTime[i] <= 2.0f)
            {
                red = 1.0f;
                green = 0.0f + (1.0f * AnswerTime[i] / 2.0f);
                blue = 1.0f * AnswerTime[i] / 2.0f;
            }
            else if(AnswerTime[i] > 2.0f && AnswerTime[i] <= 6.0f)
            {
                red = 1.0f * (6.0f - AnswerTime[i]) / 4.0f;
                green = 0.3f + (0.7f * (6.0f - AnswerTime[i]) / 4.0f);
                blue = 1.0f;
            }
        
            hmColor.Add(new Color(red, green, blue, 1.0f));

            AnswerTimeString[i] = AnswerTime[i].ToString("F1", CultureInfo.CurrentCulture);
            hmTime.Add(AnswerTimeString[i]);
        }
    }
}

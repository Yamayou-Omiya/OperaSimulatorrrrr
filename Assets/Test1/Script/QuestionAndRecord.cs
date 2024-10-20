using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionAndRecord : MonoBehaviour
{
    //GameObject csv_writer;
    bool startKey = false;
    bool questionKey = true;
    bool inQuestion = false;

    public bool level1 = false;
    public bool level2 = false;
    public bool level3 = false;
    public bool color1 = false;
    public bool color2 = false;
    public bool color3 = false;
    public bool mainPos1 = false;
    public bool mainPos2 = false;
    public bool mainPos3 = false;
    public bool mainPosFull = false;

    [SerializeField, PersistentAmongPlayMode] private bool listResetLevel1;
    [SerializeField, PersistentAmongPlayMode] private List<int> questionLevel1List1 = new List<int>();
    [SerializeField, PersistentAmongPlayMode] private List<int> questionLevel1List2 = new List<int>();
    [SerializeField, PersistentAmongPlayMode] private List<int> questionLevel1List3 = new List<int>();
    [SerializeField, PersistentAmongPlayMode] private List<string> characterLevel1List = new List<string>();

    List<Vector2> textPosList = new List<Vector2>();

    int selectedQuestion;

    Vector2 selectedPos;
    int selectedCharaNum;

    [SerializeField] private GameObject text;
    [SerializeField] private GameObject imageL1;
    [SerializeField] private GameObject imageR1;
    [SerializeField] private GameObject imageL2;
    [SerializeField] private GameObject imageR2;
    [SerializeField] private GameObject imageL3;
    [SerializeField] private GameObject imageR3;

    private GameObject imageL;
    private GameObject imageR;

    private float timeAnswer;
    private float timeQuestion;

    string charaNow;

    float[,] allAnsTime = new float[27, 3];  // 回答時間を各エリア，各回答数毎に記録（エリア０の１回目，２回目，エリア１の１回目，２回目，… の順）
    public float[,] AnsTime = new float[27, 1];  // エリアごとの回答時間の平均（to_heatmap.cs へ）

    // Start is called before the first frame update
    void Start()
    {
        level1 = SubTaskLevel.subLevel1;
        level2 = SubTaskLevel.subLevel2;
        level3 = SubTaskLevel.subLevel3;
        color1 = SubTaskColor.subColor1;
        color2 = SubTaskColor.subColor2;
        color3 = SubTaskColor.subColor3;
        mainPos1 = ScreenPosition.screenPosition1;
        mainPos2 = ScreenPosition.screenPosition2;
        mainPos3 = ScreenPosition.screenPosition3;
        mainPosFull = ScreenPosition.screenPositionFull;
        
        for(int i = 0; i < 27; i++)
        {
            for(int j = 0; j < 3; j++)
            {
                allAnsTime[i, j] = 5.0f;  // 初期値5.0に設定
            }
        }

        //csv_writer = GameObject.Find("CSV writer");

        if(listResetLevel1)
        {
            questionLevel1List1 = new List<int>();
            questionLevel1List2 = new List<int>();
            questionLevel1List3 = new List<int>();
            characterLevel1List = new List<string>();
            for(int i = 0; i < 6; i++)
            {
                questionLevel1List1.Add(i+1);
                questionLevel1List2.Add(i+1);
                questionLevel1List3.Add(i+1);
                characterLevel1List.Add("LR");
            }
            listResetLevel1 = false;
        }

        if(color1)
        {
            imageL = imageL1;
            imageR = imageR1;
        }
        if(color2)
        {
            imageL = imageL2;
            imageR = imageR2;
        }
        if(color3)
        {
            imageL = imageL3;
            imageR = imageR3;
        }


        if(mainPos1)
        {
            if(level1)
            {
                textPosList.AddRange(new Vector2[]
                {
                    new Vector2 (1132.8f, 982.8f), new Vector2 (1132.8f, 810.0f), new Vector2 (1132.8f, 637.2f),
                    new Vector2 (652.8f , 442.8f), new Vector2 (960.0f , 442.8f), new Vector2 (652.8f , 270.0f)
                });
            }
            if(level2)
            {
                textPosList.AddRange(new Vector2[]
                {
                    new Vector2 (1440.0f, 982.8f), new Vector2 (1440.0f, 810.0f), new Vector2 (1440.0f, 637.2f),
                    new Vector2 (1267.2f, 442.8f), new Vector2 (960.0f , 270.0f), new Vector2 (652.8f , 97.2f )
                });
            }
            if(level3)
            {
                textPosList.AddRange(new Vector2[]
                {
                    new Vector2 (1747.2f, 982.8f), new Vector2 (1747.2f, 810.0f), new Vector2 (1747.2f, 637.2f),
                    new Vector2 (1267.2f, 270.0f), new Vector2 (960.0f , 97.2f ), new Vector2 (1267.2f, 97.2f )
                });
            }
        }

        if(mainPos2)
        {
            if(level1)
            {
                textPosList.AddRange(new Vector2[]
                {
                    new Vector2 (787.2f , 982.8f), new Vector2 (787.2f , 810.0f), new Vector2 (787.2f , 637.2f), 
                    new Vector2 (960.0f , 442.8f), new Vector2 (1267.2f, 442.8f), new Vector2 (1267.2f, 270.0f)
                });
            }
            if(level2)
            {
                textPosList.AddRange(new Vector2[]
                {
                    new Vector2 (480.0f , 982.8f), new Vector2 (480.0f , 810.0f), new Vector2 (480.0f , 637.2f),
                    new Vector2 (652.8f , 442.8f), new Vector2 (960.0f , 270.0f), new Vector2 (1267.2f, 97.2f )
                });
            }
            if(level3)
            {
                textPosList.AddRange(new Vector2[]
                {
                    new Vector2 (172.8f , 982.8f), new Vector2 (172.8f , 810.0f), new Vector2 (172.8f , 637.2f), 
                    new Vector2 (652.8f , 270.0f), new Vector2 (652.8f , 97.2f ), new Vector2 (960.0f , 97.2f )
                });
            }
        }

        if(mainPos3)
        {
            if(level1)
            {
                textPosList.AddRange(new Vector2[]
                {
                    new Vector2 (787.2f , 810.0f), new Vector2 (480.0f , 637.2f), new Vector2 (787.2f , 637.2f),
                    new Vector2 (1132.8f, 810.0f), new Vector2 (1132.8f, 637.2f), new Vector2 (1440.0f, 637.2f)
                });
            }
            if(level2)
            {
                textPosList.AddRange(new Vector2[]
                {
                    new Vector2 (787.2f , 982.8f), new Vector2 (480.0f , 810.0f), new Vector2 (172.8f , 637.2f), 
                    new Vector2 (1132.8f, 982.8f), new Vector2 (1440.0f, 810.0f), new Vector2 (1747.2f, 637.2f)
                });
            }
            if(level3)
            {
                textPosList.AddRange(new Vector2[]
                {
                    new Vector2 (172.8f , 982.8f), new Vector2 (480.0f , 982.8f), new Vector2 (172.8f , 810.0f), 
                    new Vector2 (1440.0f, 982.8f), new Vector2 (1747.2f, 982.8f), new Vector2 (1747.2f, 810.0f)
                });
            }
        }

        if(mainPosFull)
        {
            if(level1)
            {
                textPosList.AddRange(new Vector2[]
                {
                    new Vector2 (172.8f , 982.8f), new Vector2 (480.0f , 982.8f), new Vector2 (787.2f , 982.8f),
                    new Vector2 (172.8f , 810.0f), new Vector2 (480.0f , 810.0f), new Vector2 (787.2f , 810.0f),
                    new Vector2 (172.8f , 637.2f), new Vector2 (480.0f , 637.2f), new Vector2 (787.2f , 637.2f),
                    new Vector2 (1132.8f, 982.8f), new Vector2 (1440.0f, 982.8f), new Vector2 (1747.2f, 982.8f),
                    new Vector2 (1132.8f, 810.0f), new Vector2 (1440.0f, 810.0f), new Vector2 (1747.2f, 810.0f),
                    new Vector2 (1132.8f, 637.2f), new Vector2 (1440.0f, 637.2f), new Vector2 (1747.2f, 637.2f),
                    new Vector2 (652.8f , 442.8f), new Vector2 (960.0f , 442.8f), new Vector2 (1267.2f, 442.8f),
                    new Vector2 (652.8f , 270.0f), new Vector2 (960.0f , 270.0f), new Vector2 (1267.2f, 270.0f),
                    new Vector2 (652.8f , 97.2f ), new Vector2 (960.0f , 97.2f ), new Vector2 (1267.2f, 97.2f )
                });
            }
            if(level2)
            {
                textPosList.AddRange(new Vector2[]
                {
                    new Vector2 (172.8f , 982.8f), new Vector2 (480.0f , 982.8f), new Vector2 (787.2f , 982.8f),
                    new Vector2 (172.8f , 810.0f), new Vector2 (480.0f , 810.0f), new Vector2 (787.2f , 810.0f),
                    new Vector2 (172.8f , 637.2f), new Vector2 (480.0f , 637.2f), new Vector2 (787.2f , 637.2f),
                    new Vector2 (1132.8f, 982.8f), new Vector2 (1440.0f, 982.8f), new Vector2 (1747.2f, 982.8f),
                    new Vector2 (1132.8f, 810.0f), new Vector2 (1440.0f, 810.0f), new Vector2 (1747.2f, 810.0f),
                    new Vector2 (1132.8f, 637.2f), new Vector2 (1440.0f, 637.2f), new Vector2 (1747.2f, 637.2f),
                    new Vector2 (652.8f , 442.8f), new Vector2 (960.0f , 442.8f), new Vector2 (1267.2f, 442.8f),
                    new Vector2 (652.8f , 270.0f), new Vector2 (960.0f , 270.0f), new Vector2 (1267.2f, 270.0f),
                    new Vector2 (652.8f , 97.2f ), new Vector2 (960.0f , 97.2f ), new Vector2 (1267.2f, 97.2f )
                });
            }
            if(level3)
            {
                textPosList.AddRange(new Vector2[]
                {
                    new Vector2 (172.8f , 982.8f), new Vector2 (480.0f , 982.8f), new Vector2 (787.2f , 982.8f),
                    new Vector2 (172.8f , 810.0f), new Vector2 (480.0f , 810.0f), new Vector2 (787.2f , 810.0f),
                    new Vector2 (172.8f , 637.2f), new Vector2 (480.0f , 637.2f), new Vector2 (787.2f , 637.2f),
                    new Vector2 (1132.8f, 982.8f), new Vector2 (1440.0f, 982.8f), new Vector2 (1747.2f, 982.8f),
                    new Vector2 (1132.8f, 810.0f), new Vector2 (1440.0f, 810.0f), new Vector2 (1747.2f, 810.0f),
                    new Vector2 (1132.8f, 637.2f), new Vector2 (1440.0f, 637.2f), new Vector2 (1747.2f, 637.2f),
                    new Vector2 (652.8f , 442.8f), new Vector2 (960.0f , 442.8f), new Vector2 (1267.2f, 442.8f),
                    new Vector2 (652.8f , 270.0f), new Vector2 (960.0f , 270.0f), new Vector2 (1267.2f, 270.0f),
                    new Vector2 (652.8f , 97.2f ), new Vector2 (960.0f , 97.2f ), new Vector2 (1267.2f, 97.2f )
                });
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(questionLevel1List1.Count == 0 && questionLevel1List2.Count == 0 && questionLevel1List3.Count == 0)
        {
            questionLevel1List1 = new List<int>();
            questionLevel1List2 = new List<int>();
            questionLevel1List3 = new List<int>();
            characterLevel1List = new List<string>();
            for(int i = 0; i < 6; i++)
            {
                questionLevel1List1.Add(i+1);
                questionLevel1List2.Add(i+1);
                questionLevel1List3.Add(i+1);
                characterLevel1List.Add("LR");
            }
        }

        if(!CountDownController.isCountdownActive)
        {
            startKey = true;
        }

        if(startKey)
        {
            if(questionKey && !inQuestion) // "出題可能" かつ "出題中ではない"
            {
                questionKey = false;
                Invoke("Question", UnityEngine.Random.Range(2.0f, 5.0f)); // 出題間隔設定(2, 5)
            }
        }
    }

    void Question()
    {
        if(questionLevel1List1.Count == 0 && questionLevel1List2.Count == 0 && questionLevel1List3.Count > 0)
        {
            selectedQuestion = questionLevel1List3[UnityEngine.Random.Range(0, questionLevel1List3.Count)];
            questionLevel1List3.Remove(selectedQuestion);
        }
        else if(questionLevel1List1.Count == 0 && questionLevel1List2.Count > 0)
        {
            selectedQuestion = questionLevel1List2[UnityEngine.Random.Range(0, questionLevel1List2.Count)];
            questionLevel1List2.Remove(selectedQuestion);
        }
        else
        {
            selectedQuestion = questionLevel1List1[UnityEngine.Random.Range(0, questionLevel1List1.Count)];
            questionLevel1List1.Remove(selectedQuestion);
        }

        selectedPos = textPosList[selectedQuestion - 1];
        selectedCharaNum = UnityEngine.Random.Range(0, characterLevel1List[selectedQuestion - 1].Length);

        if(characterLevel1List[selectedQuestion - 1].Substring(selectedCharaNum, 1) == "L")
        {
            imageL.GetComponent<RectTransform>().anchoredPosition = selectedPos;
            imageL.SetActive(true);
            charaNow = "L";
        }
        else
        {
            imageR.GetComponent<RectTransform>().anchoredPosition = selectedPos;
            imageR.SetActive(true);
            charaNow = "R";
        }

        inQuestion = true;
        timeQuestion = Time.realtimeSinceStartup;
        Invoke("Disappearance", 2);
        characterLevel1List[selectedQuestion - 1] = characterLevel1List[selectedQuestion - 1].Remove(selectedCharaNum, 1);
        Debug.Log("abcde___" + characterLevel1List[selectedQuestion - 1].Length.ToString());
        Debug.Log("abcde出題しました");
    }

    void Disappearance()
    {
        timeAnswer = Time.realtimeSinceStartup - timeQuestion;
        //csv_writer.GetComponent<csv_character_pop>().RightAnswerRecord(ope_state.ToString(), selectedQuestion.ToString(), charaNow, "ignored", timeAnswer.ToString());
        if(allAnsTime[selectedQuestion - 1, 0] == 5.0f)
        {
            allAnsTime[selectedQuestion - 1, 0] = 4.0f;
        }
        else if(allAnsTime[selectedQuestion - 1, 0] < 5.0f)
        {
            if(allAnsTime[selectedQuestion - 1, 1] == 5.0f)
            {
                allAnsTime[selectedQuestion - 1, 1] = 4.0f;
            }
            else if(allAnsTime[selectedQuestion - 1, 1] < 5.0f)
            {
                allAnsTime[selectedQuestion - 1, 2] = 4.0f;
                AnsTime[selectedQuestion - 1, 0] = (allAnsTime[selectedQuestion - 1, 0] + allAnsTime[selectedQuestion - 1, 1] + allAnsTime[selectedQuestion - 1, 2]) / 3; 
            }
        }
        imageL.SetActive(false);
        imageR.SetActive(false);
        Debug.Log("abcde消失させました");
        questionKey = true;
        inQuestion = false;
    }

    public void LeftAnswer()
    {
        if(!inQuestion)
        {
            // 勝手に押した
            //csv_writer.GetComponent<csv_character_pop>().LeftAnswerRecord("9999","9999","xx", "irrelevant_answer", "9999");
        }
        else
        {
            if(charaNow == "L")
            {
                // 正答
                timeAnswer = Time.realtimeSinceStartup - timeQuestion;
                //csv_writer.GetComponent<csv_character_pop>().LeftAnswerRecord(ope_state.ToString(), selectedQuestion.ToString(), "H", "correct", timeAnswer.ToString());
                if(allAnsTime[selectedQuestion - 1, 0] == 5.0f)
                {
                    allAnsTime[selectedQuestion - 1, 0] = timeAnswer;
                }
                else if(allAnsTime[selectedQuestion - 1, 0] < 5.0f)
                {
                    if(allAnsTime[selectedQuestion - 1, 1] == 5.0f)
                    {
                        allAnsTime[selectedQuestion - 1, 1] = timeAnswer;
                    }
                    else if(allAnsTime[selectedQuestion - 1, 1] < 5.0f)
                    {
                        allAnsTime[selectedQuestion - 1, 2] = timeAnswer;
                        AnsTime[selectedQuestion - 1, 0] = (allAnsTime[selectedQuestion - 1, 0] + allAnsTime[selectedQuestion - 1, 1] + allAnsTime[selectedQuestion - 1, 2]) / 3; 
                    }
                }
                CancelInvoke("Disappearance");
                Debug.Log("abcde__関数の取消");
                imageL.SetActive(false);
                imageR.SetActive(false);
                Debug.Log("abcde消失させました");
                questionKey = true;
                inQuestion = false;
            }
            else if(charaNow == "R")
            {
                // 文字の見間違え
                timeAnswer = Time.realtimeSinceStartup - timeQuestion;
                //csv_writer.GetComponent<csv_character_pop>().LeftAnswerRecord(ope_state.ToString(), selectedQuestion.ToString(), "N","character_mistake", timeAnswer.ToString());
                if(allAnsTime[selectedQuestion - 1, 0] == 5.0f)
                {
                    allAnsTime[selectedQuestion - 1, 0] = 4.0f;
                }
                else if(allAnsTime[selectedQuestion - 1, 0] < 5.0f)
                {
                    if(allAnsTime[selectedQuestion - 1, 1] == 5.0f)
                    {
                        allAnsTime[selectedQuestion - 1, 1] = 4.0f;
                    }
                    else if(allAnsTime[selectedQuestion - 1, 1] < 5.0f)
                    {
                        allAnsTime[selectedQuestion - 1, 2] = 4.0f;
                        AnsTime[selectedQuestion - 1, 0] = (allAnsTime[selectedQuestion - 1, 0] + allAnsTime[selectedQuestion - 1, 1] + allAnsTime[selectedQuestion - 1, 2]) / 3; 
                    }
                }
                CancelInvoke("Disappearance");
                Debug.Log("abcde__関数の取消");
                imageL.SetActive(false);
                imageR.SetActive(false);
                Debug.Log("abcde消失させました");
                questionKey = true;
                inQuestion = false;
            }
        }
    }

    public void RightAnswer()
    {
        if(!inQuestion)
        {
            // 勝手に押した
            //csv_writer.GetComponent<csv_character_pop>().RightAnswerRecord("9999", "9999", "xxx", "irrelevant_answer", "9999");
        }
        else
        {
            if(charaNow == "R")
            {
                // 正答
                timeAnswer = Time.realtimeSinceStartup - timeQuestion;
                //csv_writer.GetComponent<csv_character_pop>().RightAnswerRecord(ope_state.ToString(), selectedQuestion.ToString(), "N", "correct", timeAnswer.ToString());
                if(allAnsTime[selectedQuestion - 1, 0] == 5.0f)
                {
                    allAnsTime[selectedQuestion - 1, 0] = timeAnswer;
                }
                else if(allAnsTime[selectedQuestion - 1, 0] < 5.0f)
                {
                    if(allAnsTime[selectedQuestion - 1, 1] == 5.0f)
                    {
                        allAnsTime[selectedQuestion - 1, 1] = timeAnswer;
                    }
                    else if(allAnsTime[selectedQuestion - 1, 1] < 5.0f)
                    {
                        allAnsTime[selectedQuestion - 1, 2] = timeAnswer;
                        AnsTime[selectedQuestion - 1, 0] = (allAnsTime[selectedQuestion - 1, 0] + allAnsTime[selectedQuestion - 1, 1] + allAnsTime[selectedQuestion - 1, 2]) / 3; 
                    }
                }
                CancelInvoke("Disappearance");
                Debug.Log("abcde__関数の取消");
                imageL.SetActive(false);
                imageR.SetActive(false);
                Debug.Log("abcde消失させました");
                questionKey = true;
                inQuestion = false;
            }
            else if(charaNow == "L")
            {
                // 文字の見間違え
                timeAnswer = Time.realtimeSinceStartup - timeQuestion;
                //csv_writer.GetComponent<csv_character_pop>().RightAnswerRecord(ope_state.ToString(), selectedQuestion.ToString(), "H", "character_mistake", timeAnswer.ToString());
                if(allAnsTime[selectedQuestion - 1, 0] == 5.0f)
                {
                    allAnsTime[selectedQuestion - 1, 0] = 4.0f;
                }
                else if(allAnsTime[selectedQuestion - 1, 0] < 5.0f)
                {
                    if(allAnsTime[selectedQuestion - 1, 1] == 5.0f)
                    {
                        allAnsTime[selectedQuestion - 1, 1] = 4.0f;
                    }
                    else if(allAnsTime[selectedQuestion - 1, 1] < 5.0f)
                    {
                        allAnsTime[selectedQuestion - 1, 2] = 4.0f;
                        AnsTime[selectedQuestion - 1, 0] = (allAnsTime[selectedQuestion - 1, 0] + allAnsTime[selectedQuestion - 1, 1] + allAnsTime[selectedQuestion - 1, 2]) / 3; 
                    }
                }
                CancelInvoke("Disappearance");
                Debug.Log("abcde__関数の取消");
                imageL.SetActive(false);
                imageR.SetActive(false);
                Debug.Log("abcde消失させました");
                questionKey = true;
                inQuestion = false;
            }
        }
    }

    public void StartCheck()
    {
        startKey = true;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionAndRecord : MonoBehaviour
{
    GameObject csvWriter;
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

    [SerializeField, PersistentAmongPlayMode] private bool listReset;
    [SerializeField, PersistentAmongPlayMode] private List<int> questionList1 = new List<int>();
    [SerializeField, PersistentAmongPlayMode] private List<int> questionList2 = new List<int>();
    [SerializeField, PersistentAmongPlayMode] private List<int> questionList3 = new List<int>();
    [SerializeField, PersistentAmongPlayMode] private List<string> characterList = new List<string>();

    List<Vector2> textPosList = new List<Vector2>();

    int selectedQuestion;

    Vector2 selectedPos;
    int selectedCharaNum;

    //[SerializeField] private GameObject text;
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
        if(ChangeScene.start)
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
        }
        
        for(int i = 0; i < 27; i++)
        {
            for(int j = 0; j < 3; j++)
            {
                allAnsTime[i, j] = 5.0f;  // 初期値5.0に設定
            }
        }

        csvWriter = GameObject.Find("CSV Writer");

        if(listReset)
        {
            questionList1 = new List<int>();
            questionList2 = new List<int>();
            questionList3 = new List<int>();
            characterList = new List<string>();
            for(int i = 0; i < 6; i++)
            {
                questionList1.Add(i+1);
                questionList2.Add(i+1);
                questionList3.Add(i+1);
                characterList.Add("LR");
            }
            listReset = false;
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
        if(questionList1.Count == 0 && questionList2.Count == 0 && questionList3.Count == 0)
        {
            ResetLists();
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
        // リストのサイズと内容を確認
        Debug.Log("questionList1 size: " + questionList1.Count);
        Debug.Log("questionList2 size: " + questionList2.Count);
        Debug.Log("questionList3 size: " + questionList3.Count);
        Debug.Log("textPosList size: " + textPosList.Count);
        Debug.Log("characterList size: " + characterList.Count);

        // characterListの状態をチェック
        for (int i = 0; i < characterList.Count; i++)
        {
            if (string.IsNullOrEmpty(characterList[i]))
            {
                // 空の文字列があれば"LR"にリセット
                characterList[i] = "LR";
                Debug.Log($"Reset empty character string at index {i}");
            }
        }

        // 質問を選択
        if (questionList1.Count == 0 && questionList2.Count == 0 && questionList3.Count > 0)
        {
            selectedQuestion = questionList3[UnityEngine.Random.Range(0, questionList3.Count)];
            questionList3.Remove(selectedQuestion);
        }
        else if (questionList1.Count == 0 && questionList2.Count > 0)
        {
            selectedQuestion = questionList2[UnityEngine.Random.Range(0, questionList2.Count)];
            questionList2.Remove(selectedQuestion);
        }
        else if (questionList1.Count > 0)
        {
            selectedQuestion = questionList1[UnityEngine.Random.Range(0, questionList1.Count)];
            questionList1.Remove(selectedQuestion);
        }
        else
        {
            Debug.LogError("All question lists are empty.");
            // すべてのリストをリセット
            ResetLists();
            return;
        }

        Debug.Log("Selected Question: " + selectedQuestion);

        // インデックスの範囲チェック
        if (selectedQuestion - 1 < 0 || selectedQuestion - 1 >= textPosList.Count)
        {
            Debug.LogError($"selectedQuestion index ({selectedQuestion - 1}) is out of range for textPosList.");
            return;
        }

        if (selectedQuestion - 1 < 0 || selectedQuestion - 1 >= characterList.Count)
        {
            Debug.LogError($"selectedQuestion index ({selectedQuestion - 1}) is out of range for characterList.");
            return;
        }

        // 文字列の長さチェック
        string currentCharacters = characterList[selectedQuestion - 1];
        if (string.IsNullOrEmpty(currentCharacters))
        {
            Debug.LogError($"Character string is empty for question {selectedQuestion}. Resetting character options.");
            characterList[selectedQuestion - 1] = "LR"; // 空の場合はリセット
            currentCharacters = "LR";
        }

        selectedPos = textPosList[selectedQuestion - 1];
        selectedCharaNum = UnityEngine.Random.Range(0, currentCharacters.Length);

        if (currentCharacters[selectedCharaNum] == 'L')
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
        
        // 文字列の更新
        characterList[selectedQuestion - 1] = currentCharacters.Remove(selectedCharaNum, 1);
        Debug.Log($"Question {selectedQuestion}: Characters remaining: {characterList[selectedQuestion - 1]}");
    }

    private void ResetLists()
    {
        questionList1.Clear();
        questionList2.Clear();
        questionList3.Clear();
        characterList.Clear();

        for(int i = 0; i < 6; i++)
        {
            questionList1.Add(i+1);
            questionList2.Add(i+1);
            questionList3.Add(i+1);
            characterList.Add("LR");
        }
        Debug.Log("All lists have been reset");
    }

    void Disappearance()
    {
        timeAnswer = Time.realtimeSinceStartup - timeQuestion;
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
            csvWriter.GetComponent<csvQuestionRecord>().LeftAnswerRecord("9999", "xx", "irrelevant_answer", "9999");
        }
        else
        {
            if(charaNow == "L")
            {
                // 正答
                timeAnswer = Time.realtimeSinceStartup - timeQuestion;
                csvWriter.GetComponent<csvQuestionRecord>().LeftAnswerRecord(selectedQuestion.ToString(), "L", "correct", timeAnswer.ToString());
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
                csvWriter.GetComponent<csvQuestionRecord>().LeftAnswerRecord(selectedQuestion.ToString(), "R", "character_mistake", timeAnswer.ToString());
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
            csvWriter.GetComponent<csvQuestionRecord>().RightAnswerRecord("9999", "xxx", "irrelevant_answer", "9999");
        }
        else
        {
            if(charaNow == "R")
            {
                // 正答
                timeAnswer = Time.realtimeSinceStartup - timeQuestion;
                csvWriter.GetComponent<csvQuestionRecord>().RightAnswerRecord(selectedQuestion.ToString(), "R", "correct", timeAnswer.ToString());
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
                csvWriter.GetComponent<csvQuestionRecord>().RightAnswerRecord(selectedQuestion.ToString(), "L", "character_mistake", timeAnswer.ToString());
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

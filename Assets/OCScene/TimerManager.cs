using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    public Text timerText;  // UIのTextコンポーネントをInspectorでアサイン
    private float timer = 0f;  // タイマーの初期値
    private bool isRunning = false;  // タイマーが動作中かどうか
    public static float finalTime = 0f;  // 最終的なタイマーの値

    public static TimerManager Instance;

    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (StartChecker.gameStart)
        {
            if(!GoalChecker.goal)
            {
                timer += Time.deltaTime;
                UpdateTimerText();  // ゲームが開始されたらタイマーを動作中にする
            }
            else
            {
                finalTime = timer;  // 最終的なタイマーの値を保存
                Debug.Log("Final Time: " + finalTime);
            }      
        }
    }
    
    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(timer / 60f);
        int seconds = Mathf.FloorToInt(timer % 60f);

        timerText.text = string.Format("Time  {0:00}:{1:00}", minutes, seconds);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToResult : MonoBehaviour
{
    public GameObject resultPanel;
    private float time = 0f;
    public Text timeText;  // UIのTextコンポーネントをInspectorでアサイン
    public Text missText;
    public Text totalText;

    public float timeValue = 0f; // 例：75.25秒
    public int missCount = 0;
    public float missPenaltyPerHit = 5f;

    public void ShowResultFlow()
    {
        StartCoroutine(ShowResultSequence());
    }

    private IEnumerator ShowResultSequence()
    {
        resultPanel.SetActive(true);  // パネルを表示
        yield return new WaitForSeconds(1f);

        timeValue = TimerManager.finalTime;  // タイマーの最終値を取得
        int minutes = Mathf.FloorToInt(timeValue / 60);
        int seconds = Mathf.FloorToInt(timeValue % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        yield return new WaitForSeconds(1f);

        // 2. Miss表示
        missCount = MissCounter.missCount;  // ScoreManagerからミスカウントを取得
        float penaltyTotal = missCount * missPenaltyPerHit;
        missText.text = $"{missCount} × {missPenaltyPerHit}s = {penaltyTotal}s";
        yield return new WaitForSeconds(1f);

        // 3. Total表示
        float totalTime = timeValue + penaltyTotal;
        int totalMin = Mathf.FloorToInt(totalTime / 60);
        int totalSec = Mathf.FloorToInt(totalTime % 60);
        totalText.text = string.Format("{0:00}:{1:00}", totalMin, totalSec);
    }
}

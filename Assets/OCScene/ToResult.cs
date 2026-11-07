using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Reflection;
using UnityEngine.SceneManagement;
using Unity.Robotics.ROSTCPConnector;

public class ToResult : MonoBehaviour
{
    public GameObject resultPanel;
    public Button retryButton;
    private bool isRestarting = false;
    private bool isShowingResult = false;
    private ROSConnection demoRosConnection;
    public Text timeText;  // UIのTextコンポーネントをInspectorでアサイン
    public Text missText;
    public Text totalText;

    public float timeValue = 0f; // 例：75.25秒
    public int missCount = 0;
    public float missPenaltyPerHit = 5f;

    void Awake()
    {
        // Static fields survive a scene reload, so reset them before any Update runs.
        StartChecker.gameStart = false;
        GoalChecker.goal = false;
        RockManager.rockCount = 0;
        MissCounter.missCount = 0;
        TimerManager.finalTime = 0f;

        // Configure this scene's connection before its Start creates a HUD.
        demoRosConnection = ROSConnection.GetOrCreateInstance();
        demoRosConnection.ShowHud = false;
        if (demoRosConnection.HUDPanel != null)
            demoRosConnection.HUDPanel.enabled = false;
        RemoveDemoRosHudHeaders(null);
    }

    void OnDestroy()
    {
        // v0.7.1 stores HUD callbacks in a static list, which outlives the scene.
        RemoveDemoRosHudHeaders(demoRosConnection);
        if (demoRosConnection != null)
            demoRosConnection.Disconnect();
    }

    private static void RemoveDemoRosHudHeaders(ROSConnection connection)
    {
        // v0.7.1 exposes registration but no public unregister method.
        // Remove only this connection's header and already-destroyed ROS owners.
        var field = typeof(HudPanel).GetField("s_HeaderContents",
            BindingFlags.Static | BindingFlags.NonPublic);
        var headers = field == null ? null :
            field.GetValue(null) as SortedList<int, System.Action>;
        if (headers == null)
            return;

        for (int i = headers.Count - 1; i >= 0; i--)
        {
            var callback = headers.Values[i];
            var owner = callback == null ? null : callback.Target as ROSConnection;
            if (!object.ReferenceEquals(owner, null) &&
                (owner == null || object.ReferenceEquals(owner, connection)))
            {
                headers.RemoveAt(i);
            }
        }
    }

    public void ShowResultFlow()
    {
        if (isShowingResult || isRestarting)
            return;

        isShowingResult = true;
        StartCoroutine(ShowResultSequence());
    }

    public void RetryGame()
    {
        if (isRestarting || !resultPanel.activeSelf)
            return;

        string scenePath = gameObject.scene.path;
        if (!Application.CanStreamedLevelBeLoaded(scenePath))
        {
            Debug.LogError("Cannot retry: add the current scene to Build Settings.");
            return;
        }

        isRestarting = true;
        if (retryButton != null)
            retryButton.interactable = false;

        StopAllCoroutines();
        Time.timeScale = 1f;
        Input.ResetInputAxes();

        // This connector only disconnects automatically when Play mode ends.
        // Stop its connection thread before the scene destroys the old instance.
        foreach (var connection in FindObjectsOfType<ROSConnection>())
            connection.Disconnect();

        SceneManager.LoadSceneAsync(scenePath, LoadSceneMode.Single);
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

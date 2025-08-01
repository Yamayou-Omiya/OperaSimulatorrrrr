using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlayScreen : MonoBehaviour
{
    public GameObject overlayPanel;  // Inspector で設定（非表示状態で）

    private bool hasShown = false;   // 1回だけ表示するためのフラグ

    void Update()
    {
        if (!hasShown && GoalChecker.goal)
        {
            overlayPanel.SetActive(true);  // パネルを表示
            hasShown = true;
            Debug.Log("OverlayPanel 表示！");
        }
    }
}

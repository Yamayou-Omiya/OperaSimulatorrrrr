using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RockBarUI : MonoBehaviour
{
    public Image rockBarImage;         // 伸縮するImage（UIバー）
    public Text rockProgressText;    // ← UI Text を追加
    public int maxRockCount = 6;       // 最大数（6個）

    
    void Update()
    {
        float ratio = Mathf.Clamp01((float)RockManager.rockCount / maxRockCount);

        // 横方向に1/6ずつスケーリング（縦は1のまま）
        rockBarImage.rectTransform.localScale = new Vector3(ratio, 1f, 1f);
        rockProgressText.text = RockManager.rockCount + "/" + maxRockCount;
    }
}

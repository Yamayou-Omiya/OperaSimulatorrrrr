using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartChecker : MonoBehaviour
{
    public GameObject zx120;  // 対象オブジェクトをInspectorでアサイン
    public float thresholdX = -22f;  // A: x座標の閾値
    public float thresholdZ = 8f;   // B: z座標の閾値

    public static bool gameStart = false;

    void Update()
    {
        if (!gameStart)
        {
            Vector3 pos = zx120.transform.position;

            if (pos.x >= thresholdX && pos.z >= thresholdZ)
            {
                gameStart = true;
                Debug.Log("game start");
                // 必要なら他の処理をここに書く
            }
        }
    }
}

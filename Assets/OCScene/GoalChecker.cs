using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalChecker : MonoBehaviour
{
    public GameObject zx120;  // 対象オブジェクトをInspectorでアサイン
    public float thresholdX = -23.5f;  // A: x座標の閾値
    public float thresholdZ = -4.7f;   // B: z座標の閾値

    public static bool goal = false;

    void Update()
    {
        if (!goal)
        {
            if (StartChecker.gameStart)
            {
                if (RockManager.rockCount >= 3)
                {
                    Vector3 pos = zx120.transform.position;
                    //Debug.Log("Current Position: " + pos);
                    if (pos.x >= thresholdX && pos.z <= thresholdZ)
                    {
                        goal = true;
                        Debug.Log("goal");
                        // 必要なら他の処理をここに書く
                    }
                }
            }
        }
    }

}

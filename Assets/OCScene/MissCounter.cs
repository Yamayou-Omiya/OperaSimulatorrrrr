using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissCounter : MonoBehaviour
{
    public static int missCount = 0;  // 衝突しなかった岩の数をカウントする静的変数

    public float missCooldown = 3f; // ミスカウントのクールタイム（秒）
    private float lastMissTime = -Mathf.Infinity; // 最後にミスを記録した時間

    public void MissCount(Collider other)
    {
        if (StartChecker.gameStart && !GoalChecker.goal)
        {
            // obstacle タグのみ処理対象
            if (other.CompareTag("Obstacle"))
            {
                // 現在時刻が前回ミス記録＋クールタイムより大きければ OK
                if (Time.time >= lastMissTime + missCooldown)
                {
                    missCount++;
                    lastMissTime = Time.time;  // 最終ミス時間を更新
                    Debug.Log("Miss Count: " + missCount);
                }
                else
                {
                    Debug.Log("ミスのクールタイム中。カウントしません");
                }
            }
        }
    }
}

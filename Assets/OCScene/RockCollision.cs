using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockCollision : MonoBehaviour
{
    private bool pointAdded = false;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("bucket"))
        {
            Debug.Log("Bucket と衝突したので削除します");
            Destroy(gameObject);  // 自分自身を削除
            if (!pointAdded)
            {
                pointAdded = true;  // ポイント追加フラグを立てる
                RockManager.rockCount++;  // スコアを追加
                Debug.Log("スコアを追加しました: " + RockManager.rockCount);
            }
        }
    }
}

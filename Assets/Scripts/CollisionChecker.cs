using UnityEngine;

public class collisionChecker : MonoBehaviour
{
    private CollisionSound collisionSound;
    //private MissCounter missCounter;

    void Start()
    {
        // 親オブジェクトからCollisionSoundコンポーネントを取得
        collisionSound = GetComponentInParent<CollisionSound>();
        //missCounter = GetComponentInParent<MissCounter>();

        if (collisionSound == null)
        {
            Debug.LogWarning("CollisionSound component not found in parent hierarchy for " + gameObject.name);
        }
        /*if (missCounter == null)
        {
            Debug.LogWarning("MissCounter component not found in parent hierarchy for " + gameObject.name);
        }*/
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collisionSound != null)
        {
            collisionSound.PlaySound(collision.collider);
        }
        else
        {
            Debug.LogWarning("Collision detected, but CollisionSound is not set for " + gameObject.name);
        }

        /*if (missCounter != null)
        {
            missCounter.MissCount(collision.collider);
        }
        else
        {
            Debug.LogWarning("MissCounter is not set for " + gameObject.name);
        }*/
        //タグがObstacleのオブジェクトと衝突した場合にログを出力
        if (collision.collider.tag == "Obstacle")
        {
            //Debug.Log("Obstacle detected: " + this.name);
        }
    }
}
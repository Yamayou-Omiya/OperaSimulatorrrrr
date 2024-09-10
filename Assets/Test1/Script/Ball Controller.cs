using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Rigidbody rigidbody;
    public float ballDiameter = 0.2f;
    public Vector3 ball_transform = new Vector3(0.05f, 0f, 0.05f);
    
    // Start is called before the first frame update
    void Start()
    {
        diameter_changer(ballDiameter);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position += ball_transform;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Frame_R" || collision.gameObject.name == "Frame_L")
        {
            ball_transform.x = -1 * ball_transform.x;
        }
        if(collision.gameObject.name == "Frame_U" || collision.gameObject.name == "Frame_B")
        {
            ball_transform.z = -1 * ball_transform.z;
        }
    }

    private void diameter_changer(float newDiameter)
    {
        Vector3 scale = transform.localScale;

        scale.x = newDiameter;
        scale.y = newDiameter;
        scale.z = newDiameter;

        transform.localScale = scale;
    }

}

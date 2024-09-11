using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Rigidbody rigidbody;
    public float ballDiameter = 0.2f;
    public Vector3 ball_transform = new Vector3(0.05f, 0f, 0.05f);
    public float speed_x = 0.05f;
    public float speed_z = 0.05f; 
    
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
        if(collision.gameObject.name == "Frame_R")
        {
            ball_transform.x = Random.Range(-1 * speed_x, -1 * speed_x / 2);
            int dice = Random.Range(1, 3);
            if(dice == 1)
            {
                ball_transform.z = Random.Range(-1 * speed_z, -1 * speed_z / 2);
            }
            else if(dice == 2)
            {
                ball_transform.z = Random.Range(speed_z, speed_z / 2);
            }     
        }
        if(collision.gameObject.name == "Frame_L")
        {
            ball_transform.x = Random.Range(speed_x / 2, speed_x);
            int dice = Random.Range(1, 3);
            if(dice == 1)
            {
                ball_transform.z = Random.Range(-1 * speed_z, -1 * speed_z / 2);
            }
            else if(dice == 2)
            {
                ball_transform.z = Random.Range(speed_z, speed_z / 2);
            }     
        }
        if(collision.gameObject.name == "Frame_U")
        {
            ball_transform.z = Random.Range(-1 * speed_z, -1 * speed_z / 2);
            int dice = Random.Range(1, 3);
            if(dice == 1)
            {
                ball_transform.x = Random.Range(-1 * speed_x, -1 * speed_x / 2);
            }
            else if(dice == 2)
            {
                ball_transform.x = Random.Range(speed_x, speed_x / 2);
            }     
        }
        if(collision.gameObject.name == "Frame_B")
        {
            ball_transform.z = Random.Range(speed_z / 2, speed_z);
            int dice = Random.Range(1, 3);
            if(dice == 1)
            {
                ball_transform.x = Random.Range(-1 * speed_x, -1 * speed_x / 2);
            }
            else if(dice == 2)
            {
                ball_transform.x = Random.Range(speed_x, speed_x / 2);
            }     
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

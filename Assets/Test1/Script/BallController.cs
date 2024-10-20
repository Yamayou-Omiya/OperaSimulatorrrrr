using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float ballDiameter = 0.2f;
    public Vector3 ballTransform = new Vector3(0.05f, 0f, 0.05f);
    public float speedX = 0.05f;
    public float speedZ = 0.05f; 
    
    // Start is called before the first frame update
    void Start()
    {
        DiameterChanger(ballDiameter);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position += ballTransform;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Frame_R")
        {
            ballTransform.x = Random.Range(-1 * speedX, -1 * speedX / 2);
            int dice = Random.Range(1, 3);
            if(dice == 1)
            {
                ballTransform.z = Random.Range(-1 * speedZ, -1 * speedZ / 2);
            }
            else if(dice == 2)
            {
                ballTransform.z = Random.Range(speedZ, speedZ / 2);
            }     
        }
        if(collision.gameObject.name == "Frame_L")
        {
            ballTransform.x = Random.Range(speedX / 2, speedX);
            int dice = Random.Range(1, 3);
            if(dice == 1)
            {
                ballTransform.z = Random.Range(-1 * speedZ, -1 * speedZ / 2);
            }
            else if(dice == 2)
            {
                ballTransform.z = Random.Range(speedZ, speedZ / 2);
            }     
        }
        if(collision.gameObject.name == "Frame_U")
        {
            ballTransform.z = Random.Range(-1 * speedZ, -1 * speedZ / 2);
            int dice = Random.Range(1, 3);
            if(dice == 1)
            {
                ballTransform.x = Random.Range(-1 * speedX, -1 * speedX / 2);
            }
            else if(dice == 2)
            {
                ballTransform.x = Random.Range(speedX, speedX / 2);
            }     
        }
        if(collision.gameObject.name == "Frame_B")
        {
            ballTransform.z = Random.Range(speedZ / 2, speedZ);
            int dice = Random.Range(1, 3);
            if(dice == 1)
            {
                ballTransform.x = Random.Range(-1 * speedX, -1 * speedX / 2);
            }
            else if(dice == 2)
            {
                ballTransform.x = Random.Range(speedX, speedX / 2);
            }     
        }
    }

    private void DiameterChanger(float newDiameter)
    {
        Vector3 scale = transform.localScale;

        scale.x = newDiameter;
        scale.y = newDiameter;
        scale.z = newDiameter;

        transform.localScale = scale;
    }

}

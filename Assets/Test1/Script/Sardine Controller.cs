using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SardineController : MonoBehaviour
{
    public Rigidbody rigitbody;
    public Vector3 sardineTransform = new Vector3(1.0f, 0, 1.0f);
    private float deg = 0;
    public float speedX = 1.0f;
    public float speedZ = 1.0f; 


    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rotation(sardineTransform.z, sardineTransform.x);
        this.transform.position += sardineTransform * Time.deltaTime;
    }

    private void Rotation(float z, float x)
    {
        deg = 90 - Mathf.Atan2(z, x) * Mathf.Rad2Deg;
        this.gameObject.transform.eulerAngles = new Vector3(0, deg, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Frame_R")
        {
            sardineTransform.x = Random.Range(-1 * speedX, -1 * speedX / 2);
            int dice = Random.Range(1, 3);
            if(dice == 1)
            {
                sardineTransform.z = Random.Range(-1 * speedZ, -1 * speedZ / 2);
            }
            else if(dice == 2)
            {
                sardineTransform.z = Random.Range(speedZ, speedZ / 2);
            }     
        }
        if(collision.gameObject.name == "Frame_L")
        {
            sardineTransform.x = Random.Range(speedX / 2, speedX);
            int dice = Random.Range(1, 3);
            if(dice == 1)
            {
                sardineTransform.z = Random.Range(-1 * speedZ, -1 * speedZ / 2);
            }
            else if(dice == 2)
            {
                sardineTransform.z = Random.Range(speedZ, speedZ / 2);
            }     
        }
        if(collision.gameObject.name == "Frame_U")
        {
            sardineTransform.z = Random.Range(-1 * speedZ, -1 * speedZ / 2);
            int dice = Random.Range(1, 3);
            if(dice == 1)
            {
                sardineTransform.x = Random.Range(-1 * speedX, -1 * speedX / 2);
            }
            else if(dice == 2)
            {
                sardineTransform.x = Random.Range(speedX, speedX / 2);
            }     
        }
        if(collision.gameObject.name == "Frame_B")
        {
            sardineTransform.z = Random.Range(speedZ / 2, speedZ);
            int dice = Random.Range(1, 3);
            if(dice == 1)
            {
                sardineTransform.x = Random.Range(-1 * speedX, -1 * speedX / 2);
            }
            else if(dice == 2)
            {
                sardineTransform.x = Random.Range(speedX, speedX / 2);
            }     
        }
    }
}

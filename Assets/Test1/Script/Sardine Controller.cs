using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SardineController : MonoBehaviour
{
    public Rigidbody rigitbody;
    public Vector3 sardine_transform = new Vector3(0.005f, 0, 0.005f);
    private float deg = 0;
    public float speed_x = 0.005f;
    public float speed_z = 0.005f; 


    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotation(sardine_transform.z, sardine_transform.x);
        this.transform.position += sardine_transform;
    }

    private void rotation(float z, float x)
    {
        deg = Mathf.Atan2(z, x) * Mathf.Rad2Deg;
        if(deg > -90 && deg < 0 || deg > 90 && deg < 180)
        {
            deg = deg + 180;
        }
        this.gameObject.transform.eulerAngles = new Vector3(0, deg, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Frame_R")
        {
            sardine_transform.x = Random.Range(-1 * speed_x, -1 * speed_x / 2);
            int dice = Random.Range(1, 3);
            if(dice == 1)
            {
                sardine_transform.z = Random.Range(-1 * speed_z, -1 * speed_z / 2);
            }
            else if(dice == 2)
            {
                sardine_transform.z = Random.Range(speed_z, speed_z / 2);
            }     
        }
        if(collision.gameObject.name == "Frame_L")
        {
            sardine_transform.x = Random.Range(speed_x / 2, speed_x);
            int dice = Random.Range(1, 3);
            if(dice == 1)
            {
                sardine_transform.z = Random.Range(-1 * speed_z, -1 * speed_z / 2);
            }
            else if(dice == 2)
            {
                sardine_transform.z = Random.Range(speed_z, speed_z / 2);
            }     
        }
        if(collision.gameObject.name == "Frame_U")
        {
            sardine_transform.z = Random.Range(-1 * speed_z, -1 * speed_z / 2);
            int dice = Random.Range(1, 3);
            if(dice == 1)
            {
                sardine_transform.x = Random.Range(-1 * speed_x, -1 * speed_x / 2);
            }
            else if(dice == 2)
            {
                sardine_transform.x = Random.Range(speed_x, speed_x / 2);
            }     
        }
        if(collision.gameObject.name == "Frame_B")
        {
            sardine_transform.z = Random.Range(speed_z / 2, speed_z);
            int dice = Random.Range(1, 3);
            if(dice == 1)
            {
                sardine_transform.x = Random.Range(-1 * speed_x, -1 * speed_x / 2);
            }
            else if(dice == 2)
            {
                sardine_transform.x = Random.Range(speed_x, speed_x / 2);
            }     
        }
    }
}

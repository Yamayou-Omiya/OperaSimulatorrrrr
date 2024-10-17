using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SardineController2 : MonoBehaviour
{
    public Rigidbody rigitbody;
    public SardineGenerator sarGen;
    public Vector3 sardineTransform = new Vector3(1.0f, 0, 1.0f);
    private float deg = 0;
    public float speedX = 1.0f;
    public float speedZ = 1.0f;

    public static bool sardineOut = false;

    // Start is called before the first frame update
    void Start()
    {
        sarGen = GameObject.Find("Sardine Generator").GetComponent<SardineGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        Rotation(sardineTransform.z, sardineTransform.x);
        Vector3 posi = this.transform.position;
        Reflection(posi);
        this.transform.position += sardineTransform * Time.deltaTime;
        
        if(Mathf.Abs(posi.x) > 3.1f || Mathf.Abs(posi.z) > 1.85f)
        {
            sardineOut = true;
            Destroy(this);
        }
    }

    private void Rotation(float z, float x)
    {
        deg = 90 - Mathf.Atan2(z, x) * Mathf.Rad2Deg;
        this.gameObject.transform.eulerAngles = new Vector3(0, deg, 0);
    }

    private void Reflection(Vector3 position)
    {
        if(position.x >= 3.0f)
        {
            sardineTransform.x = Random.Range(-1 * speedX, -1 * speedX / 2);
            int dice = Random.Range(1, 4);
            if(dice <= 2)
            {
                sardineTransform.z = Random.Range(-1 * speedZ, -1 * speedZ / 2);
            }
            else if(dice == 3)
            {
                sardineTransform.z = Random.Range(speedZ, speedZ / 2);
            }     
        }
        if(position.x <= -3.0f)
        {
            sardineTransform.x = Random.Range(speedX / 2, speedX);
            int dice = Random.Range(1, 4);
            if(dice <= 2)
            {
                sardineTransform.z = Random.Range(-1 * speedZ, -1 * speedZ / 2);
            }
            else if(dice == 3)
            {
                sardineTransform.z = Random.Range(speedZ, speedZ / 2);
            }     
        }
        if(position.z >= 1.75f)
        {
            sardineTransform.z = Random.Range(-1 * speedZ, -1 * speedZ / 2);
            int dice = Random.Range(1, 4);
            if(dice <= 2)
            {
                sardineTransform.x = Random.Range(-1 * speedX, -1 * speedX / 2);
            }
            else if(dice == 3)
            {
                sardineTransform.x = Random.Range(speedX, speedX / 2);
            }     
        }
        if(position.z <= -1.75f)
        {
            sardineTransform.z = Random.Range(speedZ / 2, speedZ);
            int dice = Random.Range(1, 4);
            if(dice <= 2)
            {
                sardineTransform.x = Random.Range(-1 * speedX, -1 * speedX / 2);
            }
            else if(dice == 3)
            {
                sardineTransform.x = Random.Range(speedX, speedX / 2);
            }     
        }
    }
}

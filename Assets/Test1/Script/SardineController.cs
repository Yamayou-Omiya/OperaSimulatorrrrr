using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SardineController : MonoBehaviour
{
    public SardineGenerator sarGen;
    public Vector3 sardineTransform = new Vector3(1.0f, 0, 1.0f);
    private float deg = 0;
    public float width = 2.5f;
    public float height = 1.5f;
    public float speedX = 1.0f;
    public float speedZ = 1.0f;
    public float speedX1 = 0.75f;
    public float speedZ1 = 0.75f;
    public float speedX2 = 1.0f;
    public float speedZ2 = 1.0f;
    public float speedX3 = 1.5f;
    public float speedZ3 = 1.5f;

    public static bool sardineOut = false;
    public bool mainLevel1 = false;
    public bool mainLevel2 = false;
    public bool mainLevel3 = false;
    public bool mainLevel4 = false;
    public bool mainLevel5 = false;

    // Start is called before the first frame update
    void Start()
    {
        if(ChangeScene.start)
        {
            mainLevel1 = MainTaskLevel.mainLevel1;
            mainLevel2 = MainTaskLevel.mainLevel2;
            mainLevel3 = MainTaskLevel.mainLevel3;
            mainLevel4 = MainTaskLevel.mainLevel4;
            mainLevel5 = MainTaskLevel.mainLevel5;
        }

        if(mainLevel1 || mainLevel2 || mainLevel3)
        {
            speedX = speedX1;
            speedZ = speedZ1;
        }
        if(mainLevel4)
        {
            speedX = speedX2;
            speedZ = speedZ2;
        }
        if(mainLevel5)
        {
            speedX = speedX3;
            speedZ = speedZ3;
        }
        
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
        if(position.x >= width)
        {
            sardineTransform.x = Random.Range(-1 * speedX * 1.2f, -1 * speedX * 0.8f);
            int dice = Random.Range(1, 5);
            if(dice <= 3)
            {
                sardineTransform.z = Random.Range(-1 * speedZ * 1.2f, -1 * speedZ * 0.8f);
            }
            else if(dice == 4)
            {
                sardineTransform.z = Random.Range(speedZ * 0.8f, speedZ * 1.2f);
            }     
        }
        if(position.x <= -width)
        {
            sardineTransform.x = Random.Range(speedX * 0.8f, speedX * 1.2f);
            int dice = Random.Range(1, 5);
            if(dice <= 3)
            {
                sardineTransform.z = Random.Range(-1 * speedZ * 1.2f, -1 * speedZ * 0.8f);
            }
            else if(dice == 4)
            {
                sardineTransform.z = Random.Range(speedZ * 0.8f, speedZ * 1.2f);
            }     
        }
        if(position.z >= height)
        {
            sardineTransform.z = Random.Range(-1 * speedZ * 1.2f, -1 * speedZ * 0.8f);
            int dice = Random.Range(1, 5);
            if(dice <= 3)
            {
                sardineTransform.x = Random.Range(-1 * speedX * 1.2f, -1 * speedX * 0.8f);
            }
            else if(dice == 4)
            {
                sardineTransform.x = Random.Range(speedX, speedX * 1.2f);
            }     
        }
        if(position.z <= -height)
        {
            sardineTransform.z = Random.Range(speedZ * 0.8f, speedZ * 1.2f);
            int dice = Random.Range(1, 5);
            if(dice <= 3)
            {
                sardineTransform.x = Random.Range(-1 * speedX * 1.2f, -1 * speedX * 0.8f);
            }
            else if(dice == 4)
            {
                sardineTransform.x = Random.Range(speedX * 0.8f, speedX * 1.2f);
            }     
        }
    }
}

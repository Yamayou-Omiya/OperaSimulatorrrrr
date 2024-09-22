using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public Rigidbody rigidbody;
    public ObstacleGenerator obsGen;

    public float obstacleDiameter = 0.2f;
    public float width = 5.2f;
    public float height = 2.9f;

    public int obsNum;
    private GameObject[] obs;

    public float speedX = 0.05f;
    public float speedZ = 0.05f;
    private float moveX = 0;
    private float moveZ = 0;
    public Vector3 obstacleTransform;
    
    // Start is called before the first frame update
    void Start()
    {
        obsGen = GameObject.Find("Obstacle Generator").GetComponent<ObstacleGenerator>();
        
        obsNum = obsGen.obstacleNum;
        width = obsGen.width;
        height = obsGen.height;
        
        if(obsNum > 0)
        {
            obs = new GameObject[obsNum];
            obs = obsGen.obstacle;
        }

        DiameterChanger(obstacleDiameter);
        SpeedSetting();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void SpeedSetting()
    {
        moveX = Random.Range(- speedX, speedX);
        moveZ = Random.Range(- speedZ, speedZ);

        obstacleTransform = new Vector3(moveX, 0, moveZ);
    }

    private void Move()
    {
        this.transform.position += obstacleTransform * Time.deltaTime;
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Frame_R")
        {
            obstacleTransform.x = Random.Range(-1 * speedX, -1 * speedX / 2);
            int dice = Random.Range(1, 3);
            if(dice == 1)
            {
                obstacleTransform.z = Random.Range(-1 * speedZ, -1 * speedZ / 2);
            }
            else if(dice == 2)
            {
                obstacleTransform.z = Random.Range(speedZ, speedZ / 2);
            }     
        }
        if(collision.gameObject.name == "Frame_L")
        {
            obstacleTransform.x = Random.Range(speedX / 2, speedX);
            int dice = Random.Range(1, 3);
            if(dice == 1)
            {
                obstacleTransform.z = Random.Range(-1 * speedZ, -1 * speedZ / 2);
            }
            else if(dice == 2)
            {
                obstacleTransform.z = Random.Range(speedZ, speedZ / 2);
            }     
        }
        if(collision.gameObject.name == "Frame_U")
        {
            obstacleTransform.z = Random.Range(-1 * speedZ, -1 * speedZ / 2);
            int dice = Random.Range(1, 3);
            if(dice == 1)
            {
                obstacleTransform.x = Random.Range(-1 * speedX, -1 * speedX / 2);
            }
            else if(dice == 2)
            {
                obstacleTransform.x = Random.Range(speedX, speedX / 2);
            }     
        }
        if(collision.gameObject.name == "Frame_B")
        {
            obstacleTransform.z = Random.Range(speedZ / 2, speedZ);
            int dice = Random.Range(1, 3);
            if(dice == 1)
            {
                obstacleTransform.x = Random.Range(-1 * speedX, -1 * speedX / 2);
            }
            else if(dice == 2)
            {
                obstacleTransform.x = Random.Range(speedX, speedX / 2);
            }     
        }

    }

    private void DiameterChanger(float newDiameter)
    {
        if(obs != null && obs.Length > 0)
        {
            for(int i = 0; i < obsNum; i++)
            {
                Vector3 scale = new Vector3(newDiameter, newDiameter, newDiameter);
                obs[i].transform.localScale = scale;
            }
        }
    }

}

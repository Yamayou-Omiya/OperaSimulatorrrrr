using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public Rigidbody rigidbody;
    public ObstacleGenerator obsGen;

    public float obstacleDiameter = 0.2f;
    public float width = 5.05f;
    public float height = 2.85f;

    public int obsNum;
    private GameObject[] obs;

    public float speedX = 0.05f;
    public float speedZ = 0.05f;
    private float moveX = 0;
    private float moveZ = 0;
    public Vector3[] obstacleTransform;
    
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
            obstacleTransform = new Vector3[obsNum];
        }

        DiameterChanger(obstacleDiameter);
        SpeedSetting();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        //reflection();
    }

    /*private void obstacle_spawner()
    {
        if(obsNum > obsGen.obstacleNum)
        {
            obstacle = new GameObject[obsNum];
            obstacleTransform = new Vector3[obsNum];
            for(int i = 0; i < obsNum; iobsGen.obstacleNum+)
            {
                obstacle[i] = Instantiate(obstaclePrefab) as GameObject;

                x = Random.Range(- width + obstacleDiameter/2 + 0.2f, width - obstacleDiameter/2 - 0.2f);
                z = Random.Range(- height + obstacleDiameter/2 + 0.2f, height - obstacleDiameter/2 - 0.2f);

                obstacle[i].transform.position = new Vector3(x, 0.05f, z);

                moveX = Random.Range(- speedX, speedX);
                moveZ = Random.Range(- speedZ, speedZ);

                obstacleTransform[i] = new Vector3(moveX, 0, moveZ);
            }
        }
    }*/

    private void SpeedSetting()
    {
        if(obsNum > 0)
        {
            for(int i = 0; i < obsNum; i++)
            {
                moveX = Random.Range(- speedX, speedX);
                moveZ = Random.Range(- speedZ, speedZ);

                obstacleTransform[i] = new Vector3(moveX, 0, moveZ);
            }
        }
    }

    private void Move()
    {
        if(obsNum > 0)
        {
            for(int i = 0; i < obsNum; i++)
            {
                obs[i].transform.position += obstacleTransform[i] * Time.deltaTime;
            }
        }
    }
    
    /*private void reflection()
    {
        if(obsNum > 0)
        {
            for(int i = 0; i < obsNum; i++)
            {
                if(obs[i].transform.position.x >= width - obstacleDiameter/2 || obs[i].transform.position.x <= - width + obstacleDiameter/2)
                {
                    obstacleTransform[i].x = -1 * obstacleTransform[i].x;
                }
                if(obs[i].transform.position.z >= height - obstacleDiameter/2 || obs[i].transform.position.z <= - height + obstacleDiameter/2)
                {
                    obstacleTransform[i].z = -1 * obstacleTransform[i].z;
                }
            }
        }
    }*/

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Frame_R")
        {
            obstacleTransform.x = Random.Range(-1 * speed_x, -1 * speed_x / 2);
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

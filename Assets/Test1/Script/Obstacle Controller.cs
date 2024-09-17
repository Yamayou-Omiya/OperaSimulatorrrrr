using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public Rigidbody rigidbody;
    public ObstacleGenerator obsGen;
    //public GameObject obstaclePrefab;

    public float obstacleDiameter = 0.2f;
    public float width = 5.05f;
    public float height = 2.85f;
    /*public float speed_x = 0.05f;
    public float speed_z = 0.05f;
    private float x = 0;  
    private float z = 0;*/
    private float move_x = 0;
    private float move_z = 0;
    public Vector3[] obstacle_transform;
    
    // Start is called before the first frame update
    void Start()
    {
        //obstacle_spawner();
        public int obsNum = obsGen.obstacleNum;
        private GameObject[] obs;
        public float width = obsGen.width;
        public float height = obsGen.height;
        
        if(obsNum > 0)
        {
            obs = new GameObject[obsNum];
            obs = obuGen.obstacle;
            obstacle_transform = new Vector3[obsNum];
        }

        diameter_changer(obstacleDiameter);
    }

    // Update is called once per frame
    void Update()
    {
        move();
        reflection();
    }

    /*private void obstacle_spawner()
    {
        if(obsNum > obsGen.obstacleNum)
        {
            obstacle = new GameObject[obsNum];
            obstacle_transform = new Vector3[obsNum];
            for(int i = 0; i < obsNum; iobsGen.obstacleNum+)
            {
                obstacle[i] = Instantiate(obstaclePrefab) as GameObject;

                x = Random.Range(- width + obstacleDiameter/2 + 0.2f, width - obstacleDiameter/2 - 0.2f);
                z = Random.Range(- height + obstacleDiameter/2 + 0.2f, height - obstacleDiameter/2 - 0.2f);

                obstacle[i].transform.position = new Vector3(x, 0.05f, z);

                move_x = Random.Range(- speed_x, speed_x);
                move_z = Random.Range(- speed_z, speed_z);

                obstacle_transform[i] = new Vector3(move_x, 0, move_z);
            }
        }
    }*/

    private void move()
    {
        if(obsNum > 0)
        {
            for(int i = 0; i < obsNum; i++)
            {
                obs[i].transform.position += obstacle_transform[i];
            }
        }
    }
    
    private void reflection()
    {
        if(obsNum > 0)
        {
            for(int i = 0; i < obsNum; i++)
            {
                if(obs[i].transform.position.x >= width - obstacleDiameter/2 || obs[i].transform.position.x <= - width + obstacleDiameter/2)
                {
                    obstacle_transform[i].x = -1 * obstacle_transform[i].x;
                }
                if(obs[i].transform.position.z >= height - obstacleDiameter/2 || obs[i].transform.position.z <= - height + obstacleDiameter/2)
                {
                    obstacle_transform[i].z = -1 * obstacle_transform[i].z;
                }
            }
        }
    }

    private void diameter_changer(float newDiameter)
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

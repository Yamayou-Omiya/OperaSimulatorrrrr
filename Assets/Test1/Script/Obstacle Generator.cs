using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public Rigidbody rigidbody;

    public GameObject obstaclePrefab;
    public int obstacleNum = 0;
    private GameObject[] obstacle;

    public float obstacleDiameter = 0.2f;
    public float width = 5.2f;
    public float height = 2.9f;
    public float speed_x = 0.05f;
    public float speed_z = 0.05f;
    private float x = 0;  
    private float z = 0;
    private float move_x = 0;
    private float move_z = 0;
    public Vector3[] obstacle_transform;
    
    // Start is called before the first frame update
    void Start()
    {
        ObstacleSpawner();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void ObstacleSpawner()
    {
        if(obstacleNum > 0)
        {
            obstacle = new GameObject[obstacleNum];
            obstacle_transform = new Vector3[obstacleNum];

            for(int i = 0; i < obstacleNum; i++)
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
    }

}

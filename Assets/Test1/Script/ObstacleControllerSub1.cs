using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleControllerSub1 : MonoBehaviour
{
    public ObstacleGeneratorSub1 obsGen;

    public float obstacleDiameter = 0.2f;
    private float width = 5.15f;
    private float height = 2.8f;

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
        obsGen = GameObject.Find("Sub Obstacle Generator").GetComponent<ObstacleGeneratorSub1>();
        
        obsNum = obsGen.obstacleNum;
        obstacleDiameter = obsGen.obstacleDiameter;
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
        Vector3 posi = this.transform.position;
        Reflection(posi);
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
    
    private void Reflection(Vector3 position)
    {
        if(position.x >= width-obstacleDiameter/2)
        {
            obstacleTransform.x = Random.Range(-1 * speedX, -1 * speedX / 2);
            int dice = Random.Range(1, 4);
            if(dice <= 2)
            {
                obstacleTransform.z = Random.Range(-1 * speedZ, -1 * speedZ / 2);
            }
            else if(dice == 3)
            {
                obstacleTransform.z = Random.Range(speedZ, speedZ / 2);
            }     
        }
        if(position.x <= -width+obstacleDiameter/2)
        {
            obstacleTransform.x = Random.Range(speedX / 2, speedX);
            int dice = Random.Range(1, 4);
            if(dice <= 2)
            {
                obstacleTransform.z = Random.Range(-1 * speedZ, -1 * speedZ / 2);
            }
            else if(dice == 3)
            {
                obstacleTransform.z = Random.Range(speedZ, speedZ / 2);
            }     
        }
        if(position.z >= 10+height-obstacleDiameter/2)
        {
            obstacleTransform.z = Random.Range(-1 * speedZ, -1 * speedZ / 2);
            int dice = Random.Range(1, 4);
            if(dice <= 2)
            {
                obstacleTransform.x = Random.Range(-1 * speedX, -1 * speedX / 2);
            }
            else if(dice == 3)
            {
                obstacleTransform.x = Random.Range(speedX, speedX / 2);
            }     
        }
        if(position.z <= 10-height+obstacleDiameter/2)
        {
            obstacleTransform.z = Random.Range(speedZ / 2, speedZ);
            int dice = Random.Range(1, 4);
            if(dice <= 2)
            {
                obstacleTransform.x = Random.Range(-1 * speedX, -1 * speedX / 2);
            }
            else if(dice == 3)
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

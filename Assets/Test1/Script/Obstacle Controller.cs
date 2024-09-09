using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public Rigidbody rigidbody;
    public float obstacleDiameter = 0.2f;
    public Vector3 obstacle_transform = new Vector3(0.05f, 0f, 0.05f);
    
    // Start is called before the first frame update
    void Start()
    {
        diameter_changer(obstacleDiameter);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void diameter_changer(float newDiameter)
    {
        Vector3 scale = transform.localScale;

        scale.x = newDiameter;
        scale.y = newDiameter;
        scale.z = newDiameter;

        transform.localScale = scale;
    }

}

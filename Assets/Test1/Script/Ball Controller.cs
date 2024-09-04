using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Rigidbody rigidbody;

    public Vector3 ball_transform = new Vector3(0.005f, 0f, 0.005f);
    
    // Start is called before the first frame update
    void Start()
    {
        //rigidbody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //this.transform.position += ball_transform;
        rigidbody.velocity = ball_transform;
    }

    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.name == "Frame_R" || collision.gameObject.name == "Frame_L"){
            ball_transform.x = -1*ball_transform.x;
        }
        if(collision.gameObject.name == "Frame_U" || collision.gameObject.name == "Frame_B"){
            ball_transform.z = -1*ball_transform.z;
        }
    }
}

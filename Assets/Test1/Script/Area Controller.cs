using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaController : MonoBehaviour
{
    //public Rigidbody rigidbody;
    private Vector3 mouse;
    private Vector3 area;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mouse = Input.mousePosition;
        this.transform.position = new Vector3((mouse.x-960)/(960/5), 0, (mouse.y-540)/(540/2.8f));
        Debug.Log("m"+mouse);
        Debug.Log("a"+area);
    }
}

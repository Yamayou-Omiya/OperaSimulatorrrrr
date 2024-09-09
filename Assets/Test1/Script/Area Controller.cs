using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaController : MonoBehaviour
{
    public Rigidbody rigidbody;
    private Vector3 mouse;
    private Vector3 area;
    [SerializeField] GameObject target;
    [SerializeField] bool mouse_control;
    [SerializeField] bool key_control;
    [SerializeField] bool controller_control;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(mouse_control)
        {
            mouse = Input.mousePosition;
            this.transform.position = new Vector3((mouse.x - 960)/(960/5), 0, (mouse.y - 540)/(540/2.8f));
        }

        gameObject.GetComponent<Renderer>().material.color = color_changer();
    }       

    private Color color_changer(){
        float xdistance = target.transform.position.x - this.transform.position.x;
        float zdistance = target.transform.position.z - this.transform.position.z;

        if((xdistance*xdistance + zdistance*zdistance) <= 0.25f)
        {
            return Color.red;
        }
        else
        {
            return Color.yellow;
        }
    }
    
}

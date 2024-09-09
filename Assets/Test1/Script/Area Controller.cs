using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaController : MonoBehaviour
{
    public Rigidbody rigidbody;
    private Vector3 mouse;
    private Vector3 area;
    [SerializeField] GameObject target;
    public float areaDiameter = 1.0f;
    [SerializeField] bool mouse_control;
    [SerializeField] bool controller_control;
    
    // Start is called before the first frame update
    void Start()
    {
        diameter_changer(areaDiameter);
    }

    // Update is called once per frame
    void Update()
    {
        if(mouse_control)
        {
            mouse = Input.mousePosition;
            this.transform.position = new Vector3((mouse.x - 960)/(960/5.05f), 0, (mouse.y - 540)/(540/2.85f));
        }

        gameObject.GetComponent<Renderer>().material.color = color_changer();
    }       

    private Color color_changer(){
        float xdistance = target.transform.position.x - this.transform.position.x;
        float zdistance = target.transform.position.z - this.transform.position.z;

        if((xdistance*xdistance + zdistance*zdistance) <= areaDiameter*areaDiameter/4)
        {
            return Color.red;
        }
        else
        {
            return Color.yellow;
        }
    }

    private void diameter_changer(float newDiameter)
    {
        Vector3 scale = transform.localScale;

        scale.x = newDiameter;
        scale.z = newDiameter;

        transform.localScale = scale;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaController : MonoBehaviour
{
    public Rigidbody rigidbody;
    private Vector3 mouse;
    [SerializeField] GameObject target;
    [SerializeField] GameObject sardine;
    public float areaDiameter = 1.0f;
    [SerializeField] bool mouse_control;
    [SerializeField] bool controller_control;

    private float stayTime = 0;
    public float requiredStayTime = 3.0f;

    public GameObject targetObject;
    
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
            this.transform.position = new Vector3((mouse.x - 960)/(960/5.2f), 0, (mouse.y - 540)/(540/2.9f));
        }

        gameObject.GetComponent<Renderer>().material.color = color_changer();
        color_check();
    }       

    private Color color_changer()
    {
        float xdistance = sardine.transform.position.x - this.transform.position.x;
        float zdistance = sardine.transform.position.z - this.transform.position.z;

        if((xdistance*xdistance + zdistance*zdistance) <= areaDiameter*areaDiameter/4)
        {
            stayTime += Time.deltaTime;
            if(stayTime >= requiredStayTime)
            {
                return Color.green;
            }
            else
            {
                return Color.red;
            }
            
        }
        else
        {
            stayTime = 0;
            return Color.yellow;
        }
    }

    private void color_check()
    {
        Renderer renderer = GetComponent<Renderer>();

        if (renderer != null)
        {
            Color currentColor = renderer.material.color;

            if (IsColorGreen(currentColor))
            {
                if(Input.GetMouseButtonDown(0))
                {
                    Destroy(targetObject);
                }
            }
        }
    }

    bool IsColorGreen(Color color)
    {
        // Color.greenと現在の色が近似しているかを判定
        float tolerance = 0.1f; // 許容誤差
        return Mathf.Abs(color.r - Color.green.r) < tolerance &&
               Mathf.Abs(color.g - Color.green.g) < tolerance &&
               Mathf.Abs(color.b - Color.green.b) < tolerance;
    }

    private void diameter_changer(float newDiameter)
    {
        Vector3 scale = transform.localScale;

        scale.x = newDiameter;
        scale.z = newDiameter;

        transform.localScale = scale;
    }

}

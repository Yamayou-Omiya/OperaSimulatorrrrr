using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaController : MonoBehaviour
{
    public Rigidbody rigidbody;
    public SardineGenerator sarGen;
    private Vector3 mouse;
    [SerializeField] GameObject target;
    public GameObject sardine;
    public float areaDiameter = 1.0f;
    [SerializeField] bool mouseControl;
    [SerializeField] bool controllerControl;

    private float stayTime = 0;
    public float requiredStayTime = 2.0f;

    public GameObject targetObject;

    public int sardineKey = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        DiameterChanger(areaDiameter);
        sarGen = GameObject.Find("Sardine Generator").GetComponent<SardineGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        sardine = sarGen.sardine;
        if(mouseControl)
        {
            mouse = Input.mousePosition;
            this.transform.position = new Vector3((mouse.x - 960)/(960/5.2f), 0, (mouse.y - 540)/(540/2.9f));
        }

        if(sardineKey == 0)
        {
            sardineKey = sarGen.areaKey;
        }

        gameObject.GetComponent<Renderer>().material.color = ColorChanger();
        ColorCheck();
    }       

    private Color ColorChanger()
    {
        float xDistance = sardine.transform.position.x - this.transform.position.x;
        float zDistance = sardine.transform.position.z - this.transform.position.z;

        if((xDistance*xDistance + zDistance*zDistance) <= areaDiameter*areaDiameter/4)
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

    private void ColorCheck()
    {
        Renderer renderer = GetComponent<Renderer>();

        if (renderer != null)
        {
            Color currentColor = renderer.material.color;

            if (IsColorGreen(currentColor))
            {
                if(Input.GetMouseButtonDown(0))
                {
                    Destroy(sardine);
                    gameObject.GetComponent<Renderer>().material.color = Color.yellow;
                    sardineKey = 0;
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

    private void DiameterChanger(float newDiameter)
    {
        Vector3 scale = transform.localScale;

        scale.x = newDiameter;
        scale.z = newDiameter;

        transform.localScale = scale;
    }

}

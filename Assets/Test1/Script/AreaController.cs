using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaController : MonoBehaviour
{
    public SardineGenerator sarGen;
    public MainCameraController mainCamCnt;
    GameObject csvWriter;
    private Vector3 mouse;
    [SerializeField] GameObject target;
    public GameObject sardine;
    public float areaSpeed = 1.5f;
    public float areaDiameter = 1.0f;
    [SerializeField] bool mouseControl;
    [SerializeField] bool controllerControl;

    private float stayTime = 0;
    public float requiredStayTime = 2.0f;

    public GameObject targetObject;

    public int sardineKey = 1;
    public int catchNum = 0;

    public static bool gameStart = false;
    
    // Start is called before the first frame update
    void Start()
    {
        DiameterChanger(areaDiameter);
        sarGen = GameObject.Find("Sardine Generator").GetComponent<SardineGenerator>();
        mainCamCnt = GameObject.Find("Camera Controller").GetComponent<MainCameraController>();
        csvWriter = GameObject.Find("CSV Writer");
    }

    // Update is called once per frame
    void Update()
    {
        sardine = sarGen.sardine;
        if(mouseControl)
        {
            MouseController();
        }
        else if(controllerControl)
        {
            ControllerControl();
        }

        if(sardineKey == 0)
        {
            sardineKey = sarGen.areaKey;
        }

        gameObject.GetComponent<Renderer>().material.color = ColorChanger();
        ColorCheck();
    }       

    private void MouseController()
    {
        mouse = Input.mousePosition;
        if(mainCamCnt.Cam0)
        {
            if(mouse.x > 1920)
            {
                if(mouse.y > 1080)
                {
                    this.transform.position = new Vector3(5.333f, 0, 3.0f); 
                }
                else if(mouse.y < 0)
                {
                    this.transform.position = new Vector3(5.333f, 0, -3.0f); 
                }
                else
                {
                    this.transform.position = new Vector3(5.333f, 0, (mouse.y - 540)/(540/3.0f)); 
                }                   
            }
            else if(mouse.x < 0)
            {
                if(mouse.y > 1080)
                {
                    this.transform.position = new Vector3(-5.333f, 0, 3.0f); 
                }
                else if(mouse.y < 0)
                {
                    this.transform.position = new Vector3(-5.333f, 0, -3.0f); 
                }
                else
                {
                    this.transform.position = new Vector3(-5.333f, 0, (mouse.y - 540)/(540/3.0f)); 
                }
            }
            else
            {
                if(mouse.y > 1080)
                {
                    this.transform.position = new Vector3((mouse.x - 960)/(960/5.333f), 0, 3.0f); 
                }
                else if(mouse.y < 0)
                {
                    this.transform.position = new Vector3((mouse.x - 960)/(960/5.333f), 0, -3.0f); 
                }
                else
                {
                    this.transform.position = new Vector3((mouse.x - 960)/(960/5.333f), 0, (mouse.y - 540)/(540/3.0f)); 
                }
            }
        }
        else if(mainCamCnt.Cam1)
        {
            if(mouse.x > 960)
            {
                if(mouse.y > 1080)
                {
                    this.transform.position = new Vector3(5.333f, 0, 3.0f); 
                }
                else if(mouse.y < 540)
                {
                    this.transform.position = new Vector3(5.333f, 0, -3.0f); 
                }
                else
                {
                    this.transform.position = new Vector3(5.333f, 0, (mouse.y - 810)/(540/6.0f)); 
                }                   
            }
            else if(mouse.x < 0)
            {
                if(mouse.y > 1080)
                {
                    this.transform.position = new Vector3(-5.333f, 0, 3.0f); 
                }
                else if(mouse.y < 540)
                {
                    this.transform.position = new Vector3(-5.333f, 0, -3.0f); 
                }
                else
                {
                    this.transform.position = new Vector3(-5.333f, 0, (mouse.y - 810)/(540/6.0f)); 
                }
            }
            else
            {
                if(mouse.y > 1080)
                {
                    this.transform.position = new Vector3((mouse.x - 480)/(960/10.667f), 0, 3.0f); 
                }
                else if(mouse.y < 540)
                {
                    this.transform.position = new Vector3((mouse.x - 480)/(960/10.667f), 0, -3.0f); 
                }
                else
                {
                    this.transform.position = new Vector3((mouse.x - 480)/(960/10.667f), 0, (mouse.y - 810)/(540/6.0f)); 
                }
            }
        }
        else if(mainCamCnt.Cam2)
        {
            if(mouse.x > 1920)
            {
                if(mouse.y > 1080)
                {
                    this.transform.position = new Vector3(5.333f, 0, 3.0f); 
                }
                else if(mouse.y < 540)
                {
                    this.transform.position = new Vector3(5.333f, 0, -3.0f); 
                }
                else
                {
                    this.transform.position = new Vector3(5.333f, 0, (mouse.y - 810)/(540/6.0f)); 
                }                   
            }
            else if(mouse.x < 960)
            {
                if(mouse.y > 1080)
                {
                    this.transform.position = new Vector3(-5.333f, 0, 3.0f); 
                }
                else if(mouse.y < 540)
                {
                    this.transform.position = new Vector3(-5.333f, 0, -3.0f); 
                }
                else
                {
                    this.transform.position = new Vector3(-5.333f, 0, (mouse.y - 810)/(540/6.0f)); 
                }
            }
            else
            {
                if(mouse.y > 1080)
                {
                    this.transform.position = new Vector3((mouse.x - 1440)/(960/10.667f), 0, 3.0f); 
                }
                else if(mouse.y < 540)
                {
                    this.transform.position = new Vector3((mouse.x - 1440)/(960/10.667f), 0, -3.0f); 
                }
                else
                {
                    this.transform.position = new Vector3((mouse.x - 1440)/(960/10.667f), 0, (mouse.y - 810)/(540/6.0f));
                }
            }                
        }
        else if(mainCamCnt.Cam3)
        {
            if(mouse.x > 1440)
            {
                if(mouse.y > 540)
                {
                    this.transform.position = new Vector3(5.333f, 0, 3.0f); 
                }
                else if(mouse.y < 0)
                {
                    this.transform.position = new Vector3(5.333f, 0, -3.0f); 
                }
                else
                {
                    this.transform.position = new Vector3(5.333f, 0, (mouse.y - 270)/(540/6.0f)); 
                }                   
            }
            else if(mouse.x < 480)
            {
                if(mouse.y > 540)
                {
                    this.transform.position = new Vector3(-5.333f, 0, 3.0f); 
                }
                else if(mouse.y < 0)
                {
                    this.transform.position = new Vector3(-5.333f, 0, -3.0f); 
                }
                else
                {
                    this.transform.position = new Vector3(-5.333f, 0, (mouse.y - 270)/(540/6.0f)); 
                }
            }
            else
            {
                if(mouse.y > 540)
                {
                    this.transform.position = new Vector3((mouse.x - 960)/(960/10.667f), 0, 3.0f); 
                }
                else if(mouse.y < 0)
                {
                    this.transform.position = new Vector3((mouse.x - 960)/(960/10.667f), 0, -3.0f); 
                }
                else
                {
                    this.transform.position = new Vector3((mouse.x - 960)/(960/10.667f), 0, (mouse.y - 270)/(540/6.0f));
                }
            }                
        }
    }

    private void ControllerControl()
    {
        if(this.transform.position.x > 5.333f)
        {
            if(this.transform.position.z > 3.0f)
            {
                this.transform.position = new Vector3(5.333f, 0, 3.0f); 
            }
            else if(this.transform.position.z < -3.0f)
            {
                this.transform.position = new Vector3(5.333f, 0, -3.0f); 
            }
            else
            {
                this.transform.position += new Vector3(0, 0, Input.GetAxis("Joystick1Vertical1")*areaSpeed*Time.deltaTime); 
            }
        }
        else if(this.transform.position.x < -5.333f)
        {
            if(this.transform.position.z > 3.0f)
            {
                this.transform.position = new Vector3(-5.333f, 0, 3.0f); 
            }
            else if(this.transform.position.z < -3.0f)
            {
                this.transform.position = new Vector3(-5.333f, 0, -3.0f); 
            }
            else
            {
                this.transform.position += new Vector3(0, 0, Input.GetAxis("Joystick1Vertical1")*areaSpeed*Time.deltaTime); 
            }
        }
        else
        {
            if(this.transform.position.z > 3.0f)
            {
                this.transform.position += new Vector3(Input.GetAxis("Joystick1Horizontal1")*areaSpeed*Time.deltaTime, 0, 0); 
            }
            else if(this.transform.position.z < -3.0f)
            {
                this.transform.position += new Vector3(Input.GetAxis("Joystick1Horizontal1")*areaSpeed*Time.deltaTime, 0, 0); 
            }
            else
            {
                this.transform.position += new Vector3(Input.GetAxis("Joystick1Horizontal1")*areaSpeed*Time.deltaTime, 0, Input.GetAxis("Joystick1Vertical1")*areaSpeed*Time.deltaTime); 
            }
        }
        
        //Debug.Log("h__" + Input.GetAxis("Joystick1Horizontal1"));
        //Debug.Log("v__" + Input.GetAxis("Joystick1Vertical1"));
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

                    if(gameStart == false)
                    {
                        gameStart = true;
                    }
                    else
                    {
                        catchNum += 1;
                        csvWriter.GetComponent<csvCatch>().Catch(catchNum.ToString(), areaDiameter.ToString(), this.transform.position.x.ToString(), this.transform.position.z.ToString(), sardine.transform.position.x.ToString(), sardine.transform.position.z.ToString());
                    }
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

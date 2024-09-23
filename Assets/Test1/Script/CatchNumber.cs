using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatchNumber : MonoBehaviour
{
    public AreaController areaController;
    public Text catchNumText;
    
    // Start is called before the first frame update
    void Start()
    {
        areaController = GameObject.Find("Controll Area").GetComponent<AreaController>();
    }

    // Update is called once per frame
    void Update()
    {
        catchNumText.text = "Score:" + areaController.catchNum;
    }
}

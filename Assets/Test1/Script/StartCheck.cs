using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCheck : MonoBehaviour
{
    GameObject csvWriter;
    GameObject questionRecord;
    bool check;
    bool sw;
    
    // Start is called before the first frame update
    void Start()
    {
        csvWriter = GameObject.Find("CSV Writer");
        questionRecord = GameObject.Find("Sub Task");
        check = false;
        sw = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(AreaController.gameStart)
        {
            check = true;
        }
        
        if(check && sw)
        {
            csvWriter.GetComponent<csvStart>().StartCheck();
            questionRecord.GetComponent<QuestionAndRecord>().StartCheck();
            sw = false;
        }
    }
}

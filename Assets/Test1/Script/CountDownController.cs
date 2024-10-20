using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownController : MonoBehaviour
{
    public Text countdownText;
    public float countdownTime = 3;

    public static bool isCountdownActive = true;

    // Start is called before the first frame update
    void Start()
    {
        isCountdownActive = true;
        countdownText.text = countdownTime.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(isCountdownActive)
        {
            countdownTime -= Time.deltaTime;

            if(countdownTime <= 0)
            {
                isCountdownActive = false;
                countdownText.text = "";
            }

            countdownText.text = Mathf.Ceil(countdownTime).ToString();
        }
        else
        {
            countdownText.text = "";
        }
    }
}

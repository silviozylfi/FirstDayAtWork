using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchCounter : MonoBehaviour
{

    void Update()
    {
        if (GameManager.touchCounter < 3)
        {
            this.GetComponent<Text>().text = "Touches: " + GameManager.touchCounter.ToString() + ", TOUCH THE PIG!";
        }
        else
        {
            this.GetComponent<Text>().text = "Touches: " + GameManager.touchCounter.ToString() + ", TALK TO THE PRESIDENT!";
        }
    }
}

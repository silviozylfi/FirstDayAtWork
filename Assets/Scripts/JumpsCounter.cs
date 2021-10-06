using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpsCounter : MonoBehaviour
{
    // Start is called before the first frame update
    
    void Update()
    {
        if (GameManager.jumpsCounter < 3)
        {
            this.GetComponent<Text>().text = "Jumps: " + GameManager.jumpsCounter.ToString() + ", JUMP AGAIN!";
        }
        else
        {
            this.GetComponent<Text>().text = "Jumps: " + GameManager.jumpsCounter.ToString() + ", TALK TO THE DESIGNER!";
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDoors : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ElevatorManager.canCloseDoors = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ElevatorManager.lastTimeOpened = Time.time;
            ElevatorManager.canCloseDoors = true;
        }
    }
}   
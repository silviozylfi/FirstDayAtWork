using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteDeveloperMission : MonoBehaviour
{

    [SerializeField] GameObject[] itemsIcons;

    private void OnEnable()
    {
        itemsIcons[0].SetActive(false);
    }

    private void OnDisable()
    {
        itemsIcons[1].SetActive(true);
        GameManager.developerMissionActive = false;
        GameManager.pendriveAcquired = true;
    }
}

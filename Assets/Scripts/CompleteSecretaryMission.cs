using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteSecretaryMission : MonoBehaviour
{
    [SerializeField] GameObject[] itemIcons;

    private void OnEnable()
    {
        itemIcons[0].SetActive(false);
    }

    private void OnDisable()
    {
        GameManager.secretaryMissionActive = false;
        itemIcons[1].SetActive(true);
        GameManager.documentsAcquired = true;
    }
}

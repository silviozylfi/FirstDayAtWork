using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompletePresidentMission : MonoBehaviour
{
    [SerializeField] GameObject touchCounterPanel;
    [SerializeField] GameObject badgeIcon;

    private void OnEnable()
    {
        touchCounterPanel.SetActive(false);
    }

    private void OnDisable()
    {
        badgeIcon.SetActive(true);
        GameManager.badgeAcquired = true;
        GameManager.presidentMissionActive = false;
    }
}

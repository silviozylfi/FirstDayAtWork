using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePresidentMission : MonoBehaviour
{
    [SerializeField] GameObject pendriveItem;
    [SerializeField] GameObject touchCounterPanel;

    private void OnEnable()
    {
        pendriveItem.SetActive(false);
    }

    private void OnDisable()
    {
        GameManager.presidentMissionActive = true;
        touchCounterPanel.SetActive(true);
    }
}

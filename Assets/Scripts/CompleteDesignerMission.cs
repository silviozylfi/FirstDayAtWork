using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteDesignerMission : MonoBehaviour
{
    [SerializeField] GameObject jumpCounterPanel;
    [SerializeField] GameObject graphicsItemPanel;
    [SerializeField] GameObject sphereSystem;

    private void OnEnable()
    {
        jumpCounterPanel.SetActive(false);
        GameManager.designerMissionActive = false;
        GameManager.graphicsAcquired = true;
        sphereSystem.SetActive(true);
    }

    private void OnDisable()
    {
        GameManager.gravityProjectActivated = true;
        graphicsItemPanel.SetActive(true);
    }
}

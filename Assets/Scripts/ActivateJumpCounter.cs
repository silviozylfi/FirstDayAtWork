using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateJumpCounter : MonoBehaviour
{
    [SerializeField] GameObject jumpCounterPanel;

    private void OnDisable()
    {
        jumpCounterPanel.SetActive(true);
    }
}

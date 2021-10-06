using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcquireEntranceCard : MonoBehaviour
{

    [SerializeField] GameObject entranceCardInventoryPanel;

    private void OnDisable()
    {
        GameManager.entranceCardAcquired = true;
        entranceCardInventoryPanel.SetActive(true);
    }
}

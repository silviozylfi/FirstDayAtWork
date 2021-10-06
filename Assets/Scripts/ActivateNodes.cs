using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateNodes : MonoBehaviour
{
    [SerializeField] GameObject nodes;

    private void OnDisable()
    {
        GameManager.developerMissionActive = true;
        nodes.SetActive(true);
    }
}

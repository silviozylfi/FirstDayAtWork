using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public int nodeNumber;
    public bool isConquered;
    private PuzzleManager puzzleManager;
    private AudioSource audioSource;


    [SerializeField] GameObject check;
    [SerializeField] GameObject x;

    private void Start()
    {
        puzzleManager = GetComponentInParent<PuzzleManager>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnMouseDown()
    {
        if (puzzleManager.conqueredNodes == 0)
        {
            puzzleManager.currentNodeNumber = nodeNumber;
            puzzleManager.targetNodeNumber = nodeNumber;
            puzzleManager.conqueredNodes++;
            puzzleManager.SetupPlayerIcon();
            ConquerNode();
        }
        else if (puzzleManager.conqueredNodes > 0 && !puzzleManager.isPlayerMoving)
        {
            puzzleManager.targetNodeNumber = nodeNumber;
        }
    }

    public void DeconquerNode()
    {
        isConquered = false;
        check.SetActive(false);
        x.SetActive(true);
    }

    public void ConquerNode()
    {
        isConquered = true;
        check.SetActive(true);
        x.SetActive(false);
        audioSource.Play();
    }
}

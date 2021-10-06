using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public int conqueredNodes;
    private static int totalNodes = 25;
    private bool[,] edgesMatrix = new bool[totalNodes, totalNodes];
    [SerializeField] Node[] nodes = new Node[totalNodes];

    public int currentNodeNumber;
    public int targetNodeNumber;
    public bool isPlayerMoving;
    private bool isPuzzleCompleted;
    private AudioSource audioSource;

    [SerializeField] GameObject playerIcon;
    [SerializeField] TrailRenderer trail;
    [SerializeField] AudioClip[] sounds;

    //Lerp variables
    private Transform startMarker;
    private Transform endMarker;
    private float speed = 1F;
    private float startTime;
    private float journeyLength;

    private void Awake()
    {

        ResetGame();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && !isPuzzleCompleted)
        {
            ResetGame();
        }

        CheckPlayersChoice();

        if (isPlayerMoving)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.clip = sounds[Random.Range(2, 5)];
                audioSource.Play();
            }
            float distCovered = (Time.time - startTime) * speed;
            float fractionOfJourney = distCovered / journeyLength;
            playerIcon.transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fractionOfJourney);
            if (playerIcon.transform.position == endMarker.position)
            {
                isPlayerMoving = false;
                DeactivateSelectedPath(currentNodeNumber, targetNodeNumber);
                if (!nodes[targetNodeNumber].isConquered)
                {
                    nodes[targetNodeNumber].ConquerNode();
                    conqueredNodes++;
                    Debug.Log("Conquered: " + conqueredNodes);

                    if (conqueredNodes == 25 && !isPuzzleCompleted)
                    {
                        Victory();
                    }
                }
                currentNodeNumber = targetNodeNumber;
            }
        }

    }

    public void ResetGame()
    {
        playerIcon.SetActive(false);
        trail.Clear();
        isPuzzleCompleted = false;
        LoseNodes();
        DeactivateAllEdges();
        ActivateStandardEdges();
        currentNodeNumber = 0;
        targetNodeNumber = 0;
        isPlayerMoving = false;

        if (audioSource != null)
        {
            audioSource.clip = sounds[1];
            audioSource.Play();
        }

    }

    void DeactivateAllEdges()
    {
        for (int i = 0; i < 25; i++)
        {
            for (int j = 0; j < 25; j++)
            {
                edgesMatrix[i, j] = false;
            }
        }
    }

    void ActivateStandardEdges()
    {
        edgesMatrix[0, 6] = true;
        edgesMatrix[0, 8] = true;
        edgesMatrix[1, 4] = true;
        edgesMatrix[1, 5] = true;
        edgesMatrix[2, 5] = true;
        edgesMatrix[2, 6] = true;
        edgesMatrix[3, 8] = true;
        edgesMatrix[3, 9] = true;
        edgesMatrix[4, 1] = true;
        edgesMatrix[4, 5] = true;
        edgesMatrix[4, 11] = true;
        edgesMatrix[5, 1] = true;
        edgesMatrix[5, 2] = true;
        edgesMatrix[5, 4] = true;
        edgesMatrix[5, 6] = true;
        edgesMatrix[6, 0] = true;
        edgesMatrix[6, 2] = true;
        edgesMatrix[6, 5] = true;
        edgesMatrix[6, 7] = true;
        edgesMatrix[6, 11] = true;
        edgesMatrix[6, 12] = true;
        edgesMatrix[7, 6] = true;
        edgesMatrix[7, 8] = true;
        edgesMatrix[8, 0] = true;
        edgesMatrix[8, 3] = true;
        edgesMatrix[8, 7] = true;
        edgesMatrix[8, 9] = true;
        edgesMatrix[8, 13] = true;
        edgesMatrix[8, 14] = true;
        edgesMatrix[9, 3] = true;
        edgesMatrix[9, 8] = true;
        edgesMatrix[9, 14] = true;
        edgesMatrix[10, 12] = true;
        edgesMatrix[10, 13] = true;
        edgesMatrix[11, 4] = true;
        edgesMatrix[11, 6] = true;
        edgesMatrix[11, 12] = true;
        edgesMatrix[11, 16] = true;
        edgesMatrix[12, 6] = true;
        edgesMatrix[12, 10] = true;
        edgesMatrix[12, 11] = true;
        edgesMatrix[12, 15] = true;
        edgesMatrix[12, 16] = true;
        edgesMatrix[12, 17] = true;
        edgesMatrix[13, 8] = true;
        edgesMatrix[13, 10] = true;
        edgesMatrix[13, 14] = true;
        edgesMatrix[13, 15] = true;
        edgesMatrix[13, 18] = true;
        edgesMatrix[13, 19] = true;
        edgesMatrix[14, 8] = true;
        edgesMatrix[14, 9] = true;
        edgesMatrix[14, 13] = true;
        edgesMatrix[14, 19] = true;
        edgesMatrix[15, 12] = true;
        edgesMatrix[15, 13] = true;
        edgesMatrix[16, 11] = true;
        edgesMatrix[16, 12] = true;
        edgesMatrix[16, 17] = true;
        edgesMatrix[16, 21] = true;
        edgesMatrix[17, 12] = true;
        edgesMatrix[17, 16] = true;
        edgesMatrix[17, 21] = true;
        edgesMatrix[17, 22] = true;
        edgesMatrix[18, 13] = true;
        edgesMatrix[18, 19] = true;
        edgesMatrix[18, 22] = true;
        edgesMatrix[18, 23] = true;
        edgesMatrix[19, 13] = true;
        edgesMatrix[19, 14] = true;
        edgesMatrix[19, 18] = true;
        edgesMatrix[19, 20] = true;
        edgesMatrix[19, 23] = true;
        edgesMatrix[19, 24] = true;
        edgesMatrix[20, 19] = true;
        edgesMatrix[20, 24] = true;
        edgesMatrix[21, 16] = true;
        edgesMatrix[21, 17] = true;
        edgesMatrix[22, 17] = true;
        edgesMatrix[22, 18] = true;
        edgesMatrix[23, 18] = true;
        edgesMatrix[23, 19] = true;
        edgesMatrix[24, 19] = true;
        edgesMatrix[24, 20] = true;
    }


    void CheckPlayersChoice()
    {
        if (edgesMatrix[currentNodeNumber, targetNodeNumber] && !isPlayerMoving)
        {
            startMarker = nodes[currentNodeNumber].transform;
            endMarker = nodes[targetNodeNumber].transform;
            startTime = Time.time;
            journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
            isPlayerMoving = true;
        }
    }

    void DeactivateSelectedPath(int nodeA, int nodeB)
    {
        edgesMatrix[nodeA, nodeB] = false;
        edgesMatrix[nodeB, nodeA] = false;
    }

    void LoseNodes()
    {
        for (int i = 0; i < totalNodes; i++)
        {
            nodes[i].DeconquerNode();
        }

        conqueredNodes = 0;
    }

    public void SetupPlayerIcon()
    {
        playerIcon.SetActive(true);
        playerIcon.transform.position = nodes[currentNodeNumber].transform.position;
    }

    void Victory()
    {
        isPuzzleCompleted = true;
        DeactivateAllEdges();

        audioSource.clip = sounds[0];
        audioSource.Play();
        GameManager.puzzleSolved = true;
        
    }

}

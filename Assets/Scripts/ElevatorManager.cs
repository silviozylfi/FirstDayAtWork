using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorManager : MonoBehaviour
{
    private Animator elevatorAnim;

    private AudioSource playerAudio;
    [SerializeField] AudioClip[] sounds;

    private bool areDoorsClosed;
    public static int currentFloor;
    public static int targetFloor;
    public static bool isMoving;
    public static bool canCloseDoors;

    public static float lastTimeOpened;
    private float timeToClose = 5f;

    [SerializeField] GameObject[] floors;

    //lerp variables
    private Transform startMarker;
    private Transform endMarker;
    [SerializeField] Transform[] landingPoints;
    private float speed = 0.25F;
    private float startTime;
    private float journeyLength;


    // Start is called before the first frame update
    void Start()
    {
        elevatorAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        areDoorsClosed = true;
        canCloseDoors = true;
        currentFloor = 0;
        targetFloor = 0;
        isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfCanClose();

        if (isMoving)
        {
            GameManager.canPlayerMove = false;
            float distCovered = (Time.time - startTime) * speed;
            float fractionOfJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fractionOfJourney);
            if (startMarker.position == endMarker.position)
            {
                playerAudio.Stop();
                isMoving = false;
                GameManager.canPlayerMove = true;
                Invoke("OpenDoors", 1f);
                currentFloor = targetFloor;
            }
        }
    }

    void MoveElevator()
    {
        if (currentFloor != targetFloor && !isMoving && (!areDoorsClosed && canCloseDoors || areDoorsClosed))
        {
            if (!areDoorsClosed)
            {
                CloseDoors();
            }
            StartCoroutine(ChangeFloor());

        }
        else if (currentFloor == targetFloor && !isMoving && areDoorsClosed)
        {
            OpenDoors();
        }
    }

    void CloseDoors()
    {
        elevatorAnim.SetTrigger("CloseDoors");
        playerAudio.clip = sounds[0];
        playerAudio.Play();
        areDoorsClosed = true;
    }

    IEnumerator ChangeFloor()
    {
        yield return new WaitForSeconds(1f);
        startMarker = GetComponent<Transform>();
        endMarker = landingPoints[targetFloor];
        startTime = Time.time;
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
        playerAudio.clip = sounds[1];
        playerAudio.Play();
        isMoving = true;
    }

    void OpenDoors()
    {
        elevatorAnim.SetTrigger("OpenDoors");
        playerAudio.clip = sounds[2];
        playerAudio.Play();
        areDoorsClosed = false;
        lastTimeOpened = Time.time;
    }

    void CheckIfCanClose()
    {
        if (!isMoving && !areDoorsClosed && canCloseDoors)
        {
            if (Time.time - lastTimeOpened > timeToClose)
            {
                CloseDoors();
            }
        }
    }
}

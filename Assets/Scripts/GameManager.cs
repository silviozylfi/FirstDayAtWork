using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] GameObject pausePanel;

    public static bool canPlayerMove;
    public static bool canPlayerLook;

    //items and missions
    public static bool entranceCardAcquired;
    public static bool entranceOpened;
    public static bool secretaryMissionActive;
    public static bool coffeePrepared;
    public static bool documentsAcquired;
    public static bool designerMissionActive;
    public static int jumpsCounter;
    public static bool graphicsAcquired;
    public static bool gravityProjectActivated;
    public static bool puzzleSolved;
    public static bool developerMissionActive;
    public static bool pendriveAcquired;
    public static bool presidentMissionActive;
    public static int touchCounter;
    public static bool badgeAcquired;

    // Start is called before the first frame update
    void Start()
    {
        pausePanel.SetActive(false);
        canPlayerMove = true;
        canPlayerLook = true;
        entranceCardAcquired = false;
        entranceOpened = false;
        secretaryMissionActive = false;
        coffeePrepared = false;
        documentsAcquired = false;
        designerMissionActive = false;
        jumpsCounter = 0;
        graphicsAcquired = false;
        gravityProjectActivated = false;
        puzzleSolved = false;
        developerMissionActive = false;
        pendriveAcquired = false;
        presidentMissionActive = false;
        touchCounter = 0;
        badgeAcquired = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pausePanel.gameObject.active = !pausePanel.gameObject.active;
        }
    }
}

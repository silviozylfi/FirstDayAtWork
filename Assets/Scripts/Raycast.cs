using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Raycast : MonoBehaviour
{

    RaycastHit hit;
    [SerializeField] GameObject elevator;
    [SerializeField] GameObject[] labelPanels;
    [SerializeField] GameObject[] dialoguePanels;

    [SerializeField] GameObject[] itemsIcons;

    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, 3))
        {
            if (hit.transform.tag == "Thief")
            {
                ActivateTalkLabelPanel();
                labelPanels[1].SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {

                    if (Time.timeScale == 1)
                    {
                        hit.transform.GetComponent<AudioSource>().Play();
                    }

                    dialoguePanels[0].SetActive(true);
                }
            }
            else if (hit.transform.tag == "Cop")
            {
                ActivateTalkLabelPanel();
                labelPanels[2].SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (Time.timeScale == 1)
                    {
                        hit.transform.GetComponent<AudioSource>().Play();
                    }

                    if (!GameManager.entranceCardAcquired)
                    {
                        dialoguePanels[1].SetActive(true);
                    }
                    else
                    {
                        dialoguePanels[2].SetActive(true);
                    }
                }
            }
            else if (hit.transform.tag == "Secretary")
            {
                ActivateTalkLabelPanel();
                labelPanels[3].SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {

                    if (Time.timeScale == 1)
                    {
                        hit.transform.GetComponent<AudioSource>().Play();
                    }

                    if (!GameManager.coffeePrepared)
                    {
                        dialoguePanels[4].SetActive(true);
                        GameManager.secretaryMissionActive = true;
                    }
                    else if (GameManager.secretaryMissionActive && GameManager.coffeePrepared)
                    {
                        dialoguePanels[5].SetActive(true);
                    }
                    else if (!GameManager.secretaryMissionActive && GameManager.coffeePrepared)
                    {
                        dialoguePanels[6].SetActive(true);
                    }
                }
            }
            else if (hit.transform.tag == "Entrance")
            {
                DeactivateAllLabelPanels();
                if (!GameManager.entranceCardAcquired)
                {
                    labelPanels[4].SetActive(true);
                }
                else
                {
                    if (!GameManager.entranceOpened)
                    {
                        labelPanels[5].SetActive(true);
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            hit.transform.gameObject.GetComponent<Animator>().SetTrigger("OpenEntrance");
                            hit.transform.gameObject.GetComponent<AudioSource>().Play();
                            GameManager.entranceOpened = true;
                        }
                    }
                }
            }
            else if (hit.transform.tag == "CoffeeDrinker")
            {
                ActivateTalkLabelPanel();
                labelPanels[6].SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {

                    if (Time.timeScale == 1)
                    {
                        hit.transform.GetComponent<AudioSource>().Play();
                    }

                    dialoguePanels[3].SetActive(true);
                }

            }
            else if (hit.transform.tag == "CoffeeMachine")
            {
                DeactivateAllLabelPanels();
                labelPanels[7].SetActive(true);

                if (GameManager.secretaryMissionActive && !GameManager.coffeePrepared)
                {

                    labelPanels[8].SetActive(true);

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        hit.transform.GetComponent<AudioSource>().Play();
                        GameManager.coffeePrepared = true;
                        GameManager.canPlayerLook = false;
                        GameManager.canPlayerMove = false;
                        StartCoroutine(AcquireCoffee());

                    }
                }

            }
            else if (hit.transform.tag == "Call")
            {
                DeactivateAllLabelPanels();
                labelPanels[9].SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        elevator.gameObject.transform.SendMessage("OpenDoors");
                    }
                }

            }
            else if (hit.transform.tag == "Gentleman")
            {
                ActivateTalkLabelPanel();
                labelPanels[10].SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (Time.timeScale == 1)
                    {
                        hit.transform.GetComponent<AudioSource>().Play();
                    }

                    dialoguePanels[7].SetActive(true);
                }
            }
            else if (hit.transform.tag == "Wall")
            {
                DeactivateAllLabelPanels();
            }
            else if (hit.transform.tag == "FirstButton" && !ElevatorManager.isMoving)
            {
                DeactivateAllLabelPanels();
                labelPanels[11].SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    //SendMessage to changefloor
                    ElevatorManager.targetFloor = 0;
                    elevator.gameObject.transform.SendMessage("MoveElevator");
                }
            }
            else if (hit.transform.tag == "SecondButton" && !ElevatorManager.isMoving)
            {
                DeactivateAllLabelPanels();
                labelPanels[12].SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    //SendMessage to changefloor
                    ElevatorManager.targetFloor = 1;
                    elevator.gameObject.transform.SendMessage("MoveElevator");
                }
            }
            else if (hit.transform.tag == "ThirdButton" && !ElevatorManager.isMoving)
            {
                DeactivateAllLabelPanels();
                labelPanels[13].SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    //SendMessage to changefloor
                    ElevatorManager.targetFloor = 2;
                    elevator.gameObject.transform.SendMessage("MoveElevator");
                }

            }
            else if (hit.transform.tag == "Designer")
            {
                ActivateTalkLabelPanel();
                labelPanels[14].SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (Time.timeScale == 1)
                    {
                        hit.transform.GetComponent<AudioSource>().Play();
                    }

                    if (!GameManager.documentsAcquired)
                    {
                        dialoguePanels[8].SetActive(true);
                    }else if(GameManager.documentsAcquired && !GameManager.designerMissionActive && !GameManager.graphicsAcquired)
                    {
                        GameManager.designerMissionActive = true;
                        itemsIcons[1].SetActive(false);
                        dialoguePanels[9].SetActive(true);
                    }else if(GameManager.designerMissionActive && GameManager.jumpsCounter < 3 && Time.timeScale==1)
                    {
                        dialoguePanels[10].SetActive(true);
                    }
                    else if(GameManager.designerMissionActive && GameManager.jumpsCounter >= 3 && !GameManager.gravityProjectActivated)
                    {
                        dialoguePanels[11].SetActive(true);
                    }
                    else if(!GameManager.designerMissionActive && GameManager.gravityProjectActivated)
                    {
                        dialoguePanels[12].SetActive(true);
                    }
                }
            }
            else if (hit.transform.tag == "Developer")
            {
                ActivateTalkLabelPanel();
                labelPanels[15].SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (Time.timeScale == 1)
                    {
                        hit.transform.GetComponent<AudioSource>().Play();
                    }

                    if (!GameManager.graphicsAcquired)
                    {
                        dialoguePanels[13].SetActive(true);
                    }else if(GameManager.graphicsAcquired && !GameManager.puzzleSolved)
                    {
                        dialoguePanels[14].SetActive(true);
                    }else if(GameManager.developerMissionActive && GameManager.puzzleSolved)
                    {
                        dialoguePanels[15].SetActive(true);
                    }else if (GameManager.pendriveAcquired)
                    {
                        dialoguePanels[16].SetActive(true);
                    }
                }

            }else if (hit.transform.tag == "Rules" && GameManager.developerMissionActive)
            {
                labelPanels[16].SetActive(true);
                labelPanels[17].SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    dialoguePanels[17].SetActive(true);
                }
            }else if (hit.transform.tag == "RealNurse")
            {
                ActivateTalkLabelPanel();
                labelPanels[18].SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (Time.timeScale == 1)
                    {
                        hit.transform.GetComponent<AudioSource>().Play();
                    }

                    dialoguePanels[18].SetActive(true);
                }
            }else if (hit.transform.tag == "FakeNurse")
            {
                ActivateTalkLabelPanel();
                labelPanels[19].SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (Time.timeScale == 1)
                    {
                        hit.transform.GetComponent<AudioSource>().Play();
                    }

                    dialoguePanels[19].SetActive(true);
                }
            }else if (hit.transform.tag == "President")
            {
                ActivateTalkLabelPanel();
                labelPanels[20].SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (Time.timeScale == 1)
                    {
                        hit.transform.GetComponent<AudioSource>().Play();
                    }

                    if (!GameManager.pendriveAcquired)
                    {
                        dialoguePanels[20].SetActive(true);
                    }else if(GameManager.pendriveAcquired && !GameManager.presidentMissionActive && !GameManager.badgeAcquired)
                    {
                        dialoguePanels[21].SetActive(true);
                    }else if(GameManager.presidentMissionActive && GameManager.touchCounter < 3)
                    {
                        dialoguePanels[22].SetActive(true);
                    }else if (GameManager.presidentMissionActive && GameManager.touchCounter >= 3)
                    {
                        dialoguePanels[23].SetActive(true);
                    }else if (GameManager.badgeAcquired)
                    {
                        dialoguePanels[24].SetActive(true);
                    }
                    
                }
            }else if (hit.transform.tag == "Pig")
            {
                labelPanels[21].SetActive(true);
                if (GameManager.presidentMissionActive)
                {

                    labelPanels[22].SetActive(true);

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        GameManager.touchCounter++;
                    }
                }
            }
            else if (hit.transform.tag == "Clown")
            {
                ActivateTalkLabelPanel();
                labelPanels[25].SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {

                    if (Time.timeScale == 1)
                    {
                        hit.transform.GetComponent<AudioSource>().Play();
                    }

                    dialoguePanels[25].SetActive(true);
                }
            }
            else if (hit.transform.tag == "Naked")
            {
                ActivateTalkLabelPanel();
                labelPanels[26].SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {

                    if (Time.timeScale == 1)
                    {
                        hit.transform.GetComponent<AudioSource>().Play();
                    }

                    dialoguePanels[26].SetActive(true);
                }
            }
            else if (hit.transform.tag == "Exit")
            {
                labelPanels[23].SetActive(true);
                if (GameManager.badgeAcquired)
                {
                    labelPanels[24].SetActive(true);
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        SceneManager.LoadScene(2);
                    }
                }
            }

        }
        else
        {
            DeactivateAllLabelPanels();
        }
    }

    void ActivateTalkLabelPanel()
    {
        DeactivateAllLabelPanels();
        labelPanels[0].SetActive(true);
    }

    void DeactivateAllLabelPanels()
    {
        foreach(GameObject panel in labelPanels)
        {
            panel.gameObject.SetActive(false);
        }
    }

    IEnumerator AcquireCoffee()
    {
        yield return new WaitForSeconds(4);
        itemsIcons[0].SetActive(true);
        GameManager.canPlayerLook = true;
        GameManager.canPlayerMove = true;
    }
}

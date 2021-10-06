using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panels : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        PauseGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ClosePanel();
        }
    }
    
    public void PauseGame()
    {
        Time.timeScale = 0;
        GameManager.canPlayerLook = false;
        GameManager.canPlayerMove = false;
    }

    public void ClosePanel()
    {
        Cursor.visible = false;
        Time.timeScale = 1;
        GameManager.canPlayerLook = true;
        GameManager.canPlayerMove = true;
        this.gameObject.SetActive(false);
    }
}

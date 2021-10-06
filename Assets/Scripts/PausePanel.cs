using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePanel : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        PauseThisGame();
    }

    private void OnDisable()
    {
        CloseThisPanel();
    }

    public void PauseThisGame()
    {
        Time.timeScale = 0;
        GameManager.canPlayerLook = false;
        GameManager.canPlayerMove = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void CloseThisPanel()
    {
        Cursor.visible = false;
        Time.timeScale = 1;
        GameManager.canPlayerLook = true;
        GameManager.canPlayerMove = true;
        this.gameObject.SetActive(false);
    }
}

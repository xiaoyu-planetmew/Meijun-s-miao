using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager: MonoBehaviour
{
    public GameObject exitBG;
    public GameObject exitButton;

    private void Start()
    {
        //inventoryMenu.gameObject.SetActive(true);
    }

    private void Update()
    {
        InventoryControl();
    }

    private void InventoryControl()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && GameObject.Find("GameManager"))
        {
            //if Game is Paused, press Escape, Resume the Game
            if (GameManager.instance.isPaused)
            {
                Resume();
            }
            else
            {
                Pause();//if Game is Reusme, Press Escape, Pasue the Game 
            }

        }
    }

    public void Resume()
    {
        //inventoryMenu.gameObject.SetActive(false);
        Time.timeScale = 1.0f;//Real time is 1.0f
        GameManager.instance.isPaused = false;
        exitBG.SetActive(false);
        exitButton.SetActive(false);
    }

    private void Pause()
    {
        //inventoryMenu.gameObject.SetActive(true);
        Time.timeScale = 0.0f;//STOP THE TIME
        GameManager.instance.isPaused = true;
        exitBG.SetActive(true);
        exitButton.SetActive(true);
    }


}

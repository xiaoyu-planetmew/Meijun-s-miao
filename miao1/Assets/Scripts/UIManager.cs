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
        if (Input.GetKeyDown(KeyCode.Escape) && (GameObject.Find("GameManager") || GameObject.Find("GameManager2")))
        {
            if(GameObject.Find("GameManager") ){
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
            if(GameObject.Find("GameManager2") ){
            //if Game is Paused, press Escape, Resume the Game
            if (GameManager2.instance.isPaused)
            {
                Resume2();
            }
            else
            {
                Pause2();//if Game is Reusme, Press Escape, Pasue the Game 
            }
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
public void Resume2()
    {
        //inventoryMenu.gameObject.SetActive(false);
        Time.timeScale = 1.0f;//Real time is 1.0f
        GameManager2.instance.isPaused = false;
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
private void Pause2()
    {
        //inventoryMenu.gameObject.SetActive(true);
        Time.timeScale = 0.0f;//STOP THE TIME
        GameManager2.instance.isPaused = true;
        exitBG.SetActive(true);
        exitButton.SetActive(true);
    }

}

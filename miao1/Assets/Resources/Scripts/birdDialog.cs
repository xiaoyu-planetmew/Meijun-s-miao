using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdDialog : MonoBehaviour
{
    public GameObject player;
    public GameObject bird;
    public GameObject startButton;
    public GameObject nextPageButton;
    public GameObject dialogBox;
    public GameObject finalPoint;
    public GameObject buttonLocation;
    public GameObject inventoryMenu;
    private bool isTalk = false;
    private bool tradeFinish = false;
    public Item upload;
    public Item download;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if((bird.transform.position == finalPoint.transform.position) && !isTalk && !tradeFinish)
        {
            startButton.SetActive(true);
        }
    }
    public void dialogStart()
    {
        startButton.SetActive(false);
        isTalk = true;
        Time.timeScale = 0.0f;
        GameManager.instance.isPaused = true;
        dialogBox.gameObject.SetActive(true);
        nextPageButton.SetActive(true);
    }
    public void nextDialog()
    {
        nextPageButton.SetActive(false);
        buttonLocation.gameObject.SetActive(true);
        inventoryMenu.gameObject.SetActive(true);
    }
    public void helpBird()
    {
        GameManager.instance.TradeItem(upload, download);
        isTalk = false;
        Time.timeScale = 1.0f;
        dialogBox.gameObject.SetActive(false);
        buttonLocation.gameObject.SetActive(false);
        inventoryMenu.gameObject.SetActive(false);
        Debug.Log("You have got a flint");
        tradeFinish = true;
    }
    public void dontHelpBird()
    {
        dialogBox.gameObject.SetActive(false);
        buttonLocation.gameObject.SetActive(false);
        inventoryMenu.gameObject.SetActive(false);
        isTalk = false;
        Time.timeScale = 1.0f;
    }
}

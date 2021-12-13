using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class birdDialog : MonoBehaviour
{
    public GameObject player;
    public GameObject playerTip;
    public GameObject playerChooseBox;
    public string playerRespond;
    public GameObject bird;
    public GameObject startButton;
    public GameObject nextPageButton;
    public GameObject dialogBox;
    public GameObject dialog2Box;
    public GameObject finalPoint;
    public GameObject buttonLocation;
    //public GameObject inventoryMenu;
    public bool isTalk = false;
    public bool tradeFinish = false;
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
        //Time.timeScale = 0.0f;
        //GameManager.instance.isPaused = true;
        dialogBox.gameObject.SetActive(true);
        nextPageButton.SetActive(true);
    }
    public void nextDialog()
    {
        if(isTalk && !tradeFinish)
        {
            Debug.Log("1");
            dialog2Box.SetActive(true);
        }
        
    }
    public void helpBird()
    {
        inventoryResponse.instance.becomeUseful(upload, this.gameObject);
    }
    
    void getMessage()
    {
        playerChooseBox.SetActive(false);
        playerTip.transform.GetChild(0).GetComponent<Text>().text = playerRespond;
        playerTip.SetActive(true);
    }
    public void finishDialog()
    {
        if(isTalk && !tradeFinish)
        {
            GameManager.instance.TradeItem(upload, download);
            isTalk = false;
            Time.timeScale = 1.0f;
            dialogBox.gameObject.SetActive(false);
            buttonLocation.gameObject.SetActive(false);
            //inventoryMenu.gameObject.SetActive(false);
            Debug.Log("You have got a flint");
            tradeFinish = true;
            inventoryResponse.instance.becomeUseless(upload);
        }
    }
    /*
    public void helpBird()
    {
        GameManager.instance.TradeItem(upload, download);
        isTalk = false;
        Time.timeScale = 1.0f;
        dialogBox.gameObject.SetActive(false);
        buttonLocation.gameObject.SetActive(false);
        //inventoryMenu.gameObject.SetActive(false);
        Debug.Log("You have got a flint");
        tradeFinish = true;
    }
    */
    public void dontHelpBird()
    {
        inventoryResponse.instance.becomeUseless(upload);
        dialogBox.gameObject.SetActive(false);
        buttonLocation.gameObject.SetActive(false);
        //inventoryMenu.gameObject.SetActive(false);
        isTalk = false;
        Time.timeScale = 1.0f;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class birdDialog : MonoBehaviour
{
    public GameObject player;
    public GameObject playerTip;
    public GameObject playerChooseBox;
    public string playerRespondJ;
    public string playerRespondE;
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
    public string wrongTipJ;
    public string wrongTipE;
    public string emptyTip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player = GameManager.instance.player;
        playerTip = player.transform.Find("Canvas").GetChild(0).gameObject;
        playerChooseBox = player.transform.Find("Canvas").GetChild(1).gameObject;
        if((bird.transform.position == finalPoint.transform.position) && !isTalk && !tradeFinish)
        {
            startButton.SetActive(true);
        }
        /*
        if(isTalk)
        {
            GameManager.instance.player.GetComponent<FinalMovement>().stopMoving();
        }else{
            GameManager.instance.player.GetComponent<FinalMovement>().continueMoving();
        }
        */
    }
    public void dialogStart()
    {
        startButton.SetActive(false);
        isTalk = true;
        GameManager.instance.player.GetComponent<FinalMovement>().stopMoving();
        //Time.timeScale = 0.0f;
        //GameManager.instance.isPaused = true;
        dialogBox.gameObject.SetActive(true);
        nextPageButton.SetActive(true);
        inventoryResponse.instance.becomeUseless(upload);
        GameObject.Find("Content").GetComponent<slotsState>().turnOffInventory();
        GameManager.instance.player.GetComponent<FinalMovement>().stopMoving();
    }
    public void nextDialog()
    {
        if(isTalk && !tradeFinish)
        {
            Debug.Log("1");
            //GameManager.instance.RemoveItem(upload);
            dialog2Box.SetActive(true);
        }
        
    }
    public void helpBird()
    {
        if(GameManager.instance.items.Count == 0)
        {
            inventoryResponse.instance.emptyItems(emptyTip);
        }else{
            if(GameManager.instance.languageNum == 0)
            {
                inventoryResponse.instance.becomeUseful(upload, this.gameObject, wrongTipJ);
            }       
            if(GameManager.instance.languageNum == 1)
            {
                inventoryResponse.instance.becomeUseful(upload, this.gameObject, wrongTipE);
            }
        }
    }
    
    void getMessage()
    {
        
        GameManager.instance.player.GetComponent<FinalMovement>().stopMoving();
        playerChooseBox.SetActive(false);
        if(GameManager.instance.languageNum == 0)
        {
            playerTip.transform.GetChild(0).GetComponent<Text>().text = playerRespondJ;
        }
        if(GameManager.instance.languageNum == 1)
        {
            playerTip.transform.GetChild(0).GetComponent<Text>().text = playerRespondE;
        }
        playerTip.SetActive(true);
        GameManager.instance.RemoveItem(upload);
        inventoryResponse.instance.becomeUseless(upload);
    }
    public void finishDialog()
    {
        if(isTalk && !tradeFinish)
        {
            //GameManager.instance.TradeItem(upload, download);
            GameManager.instance.AddItem(download);
            isTalk = false;
            Time.timeScale = 1.0f;
            dialogBox.gameObject.SetActive(false);
            buttonLocation.gameObject.SetActive(false);
            inventoryResponse.instance.finishDialog();
            //inventoryMenu.gameObject.SetActive(false);
            Debug.Log("You have got a flint");
            tradeFinish = true;
            GameManager.instance.player.GetComponent<FinalMovement>().continueMoving();
            //inventoryResponse.instance.becomeUseless(upload);
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
        startButton.gameObject.SetActive(true);
        inventoryResponse.instance.finishDialog();
        //inventoryMenu.gameObject.SetActive(false);
        isTalk = false;
        GameManager.instance.player.GetComponent<FinalMovement>().continueMoving();
        Time.timeScale = 1.0f;
    }
}

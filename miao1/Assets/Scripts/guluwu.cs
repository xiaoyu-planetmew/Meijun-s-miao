using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class guluwu : MonoBehaviour
{
    public float burnAniTime;
    public GameObject teleport;
    public GameObject thorn;
    public Item _item;
    public string wrongTipJ;
    public string wrongTipE;
    public string emptyTipJ;
    public string emptyTipE;
    private GameObject burn;
    //public GameObject box;
    private bool burnt;
    public GameObject wall;
    // Start is called before the first frame update
    void Start()
    {
        teleport = this.transform.GetChild(1).transform.GetChild(0).gameObject;
        burn = this.transform.GetChild(1).transform.GetChild(1).gameObject;
        thorn = this.transform.GetChild(2).gameObject;
        burnt = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameManager.instance.events[26])
        {
            burn.GetComponent<Button>().enabled = true;
        }
        if(GameManager.instance.events[6])
        {
            wall.SetActive(false);
        }
        if(GameManager.instance.events[26])
        {
            burnt = true;
            teleport.SetActive(true);
            burn.SetActive(false);
            thorn.SetActive(false);
            this.gameObject.GetComponent<teleportButtonActive>().enabled = true;
        }
    }
    public void dialog()
    {
        if(GameManager.instance.items.Count == 0)
        {
            if(GameManager.instance.languageNum == 0)
            {
                inventoryResponse.instance.emptyItems(emptyTipJ);
            }
            if(GameManager.instance.languageNum == 1)
            {
                inventoryResponse.instance.emptyItems(emptyTipE);
            }
        }else{
            if(GameManager.instance.languageNum == 0)
            {
                inventoryResponse.instance.becomeUseful(_item, this.gameObject, wrongTipJ);
            }
            if(GameManager.instance.languageNum == 1)
            {
                inventoryResponse.instance.becomeUseful(_item, this.gameObject, wrongTipE);
            }
            inventoryResponse.instance.activeInventoryTip();
        }
    }
    public void getMessage()
    {
        thornBurn();
        burn.SetActive(false);
        
        GameManager.instance.RemoveItem(_item);
        inventoryResponse.instance.becomeUseless(_item);
    }
    public void thornBurn()
    {
        StartCoroutine(burnAni());
        thorn.GetComponent<Animator>().SetTrigger("burn");
    }
    IEnumerator burnAni()
    {
        yield return new WaitForSeconds(burnAniTime);
        GameManager.instance.events[4] = true;
        teleport.SetActive(true);
        thorn.SetActive(false);
        this.gameObject.GetComponent<teleportButtonActive>().enabled = true;
        GameManager.instance.events[26] = true;
        burnt = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class room2Box : MonoBehaviour
{
    //public GameObject dialogBox;
    public string holdFakeKeysStr;
    public string notHoldStr;
    public Item _item;
    public List<Item> fakeKeys = new List<Item>();
    public List<GameObject> on = new List<GameObject>();
    bool holdKeys;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach(var i in fakeKeys)
        {
            if(GameManager.instance.items.Contains(i))
            {
                holdKeys = true;
            }else{
                if(!holdKeys)
                {
                    holdKeys = false;
                }
            }
        }
    }
    public void dialog()
    {
        if(!(GameManager.instance.items.Contains(_item)) && holdKeys)
        {
            GameManager.instance.player.transform.GetChild(5).GetChild(0).GetChild(0).GetComponent<Text>().text = holdFakeKeysStr;
            GameManager.instance.player.transform.GetChild(5).GetChild(0).gameObject.SetActive(true);
            StartCoroutine(close());
        }
        if(!(GameManager.instance.items.Contains(_item)) && !holdKeys)
        {
            GameManager.instance.player.transform.GetChild(5).GetChild(0).GetChild(0).GetComponent<Text>().text = notHoldStr;
            GameManager.instance.player.transform.GetChild(5).GetChild(0).gameObject.SetActive(true);
            StartCoroutine(close());
        }
        if(GameManager.instance.items.Contains(_item))
        {
            inventoryResponse.instance.becomeUseful(_item, this.gameObject);
            inventoryResponse.instance.inventoryTip.SetActive(true);
        }
    }
    public void getMessage()
    {
        GameManager.instance.RemoveItem(_item);
        foreach(var obj in on)
        {
            obj.SetActive(true);
        }
        this.gameObject.SetActive(false);
    }
    IEnumerator close()
    {
        yield return new WaitForSeconds(2f);
        if((GameManager.instance.player.transform.GetChild(5).GetChild(0).gameObject.activeInHierarchy)
         && ((GameManager.instance.player.transform.GetChild(5).GetChild(0).GetChild(0).GetComponent<Text>().text == holdFakeKeysStr) || 
         (GameManager.instance.player.transform.GetChild(5).GetChild(0).GetChild(0).GetComponent<Text>().text == notHoldStr)))
        {
            GameManager.instance.player.transform.GetChild(5).GetChild(0).gameObject.SetActive(false);
        }
    }
}

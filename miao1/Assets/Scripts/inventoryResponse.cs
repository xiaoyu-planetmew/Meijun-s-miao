using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventoryResponse : MonoBehaviour
{
    public static inventoryResponse instance;
    public Text itemName;
    public List<Item> usefulItem = new List<Item>();
    public List<GameObject> itemSource = new List<GameObject>();
    public GameObject tipUI;
    public GameObject usefulItemUI;
    public GameObject slots;
    public GameObject inventoryTip;
    Item thisItem;
    GameObject thisObj;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void importMessage(Item _item)
    {
        if(!usefulItem.Contains(_item))
        {
            tipUI.transform.GetChild(0).GetComponent<Text>().text = "I Can`t use " + _item.name; 
            tipUI.SetActive(true);
        }
        for(int i = 0;i < usefulItem.Count; i++)
        {
            if(_item == usefulItem[i])
            {
                //tipUI.transform.GetChild(0).GetComponent<Text>().text = "Do I need to use " + _item.itemName;
                //tipUI.SetActive(true);
                //usefulItemUI.SetActive(true);
                thisItem = usefulItem[i];
                thisObj = itemSource[i];
                exportMessage();
                //finishDialog();
            }
        }
    }
    public void becomeUseful(Item _item, GameObject obj)
    {
        if(!usefulItem.Contains(_item))
        {
            usefulItem.Add(_item);
            itemSource.Add(obj);
        }
    }
    public void becomeUseless(Item _item)
    {
        for(int i = 0; i < usefulItem.Count; i++)
        {
            if(_item == usefulItem[i])
            {
                usefulItem.RemoveAt(i);
                itemSource.RemoveAt(i);
            }
        }
    }
    
    public void exportMessage()
    {
        thisObj.SendMessage("getMessage", thisObj, SendMessageOptions.RequireReceiver);
        thisItem = null;
        thisObj = null;
        inventoryTip.SetActive(false);
    }
    public void finishDialog()
    {
        slots.GetComponent<slotsState>().turnOnInventory();
        inventoryTip.SetActive(false);
        tipUI.SetActive(false);
        usefulItemUI.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager: MonoBehaviour
{
    public static GameManager instance;//MARKER SINGLETON PATTERN
    public bool isPaused;

    public List<Item> items = new List<Item>();//WHAT KIND OF ITEMS WE HAVE 
    public List<int> itemNumbers = new List<int>();//HOW MANY ITEMS WE HAVE
    public List<Item> CharCollections = new List<Item>();
    public GameObject[] slots;


    public ItemButton thisButton;//Keep Track of which Item Button We are mouse Hovering
    public ItemButton[] itemButtons;//ALL of ITEM BUTTONS in this game [Used for reset]


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            if(instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        DisplayItems();
    }

    private void DisplayItems()
    {
        //We IGNORE the fact
        for(int i = 0; i < slots.Length; i++)
        {
            if(i < items.Count)
            {
                //UPDATE slots Item Image
                slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = items[i].itemSprite;

                //UPDATE slots Count Text
                slots[i].transform.GetChild(1).GetComponent<Text>().color = new Color(0, 0, 0, 1);
                slots[i].transform.GetChild(1).GetComponent<Text>().text = itemNumbers[i].ToString();

                //UPDATE CLOSE/THROW button
                slots[i].transform.GetChild(2).gameObject.SetActive(true);
            }
            else//Some Remove Items
            {
                //UPDATE slots Item Image
                slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 0);
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = null;

                //UPDATE slots Count Text
                slots[i].transform.GetChild(1).GetComponent<Text>().color = new Color(1, 1, 1, 0);
                slots[i].transform.GetChild(1).GetComponent<Text>().text = null;

                //UPDATE CLOSE/THROW button
                slots[i].transform.GetChild(2).gameObject.SetActive(false);
            }
        }
    }

    public void AddItem(Item _item)
    {
        //MARKER IF There is one existing item in our bags(List)
        if(!items.Contains(_item))
        {
            items.Add(_item);
            itemNumbers.Add(1);//ADD ONE 
        }
        else//IF There is a new _item in our bag
        {
            Debug.Log("You have already have this One!");
            for(int i = 0; i < items.Count; i++)
            {
                if(_item == items[i])
                {
                    itemNumbers[i]++;
                }
            }
        }

        DisplayItems();
    }

    public void RemoveItem(Item _item)
    {
        if(items.Contains(_item))//IF There is one existing item in our bags(List)
        {
            for(int i = 0; i < items.Count; i++)
            {
                if(_item == items[i])
                {
                    itemNumbers[i]--;
                    if(itemNumbers[i] == 0)
                    {
                        //WE HAVE TO REMOVE THIS ITEM
                        items.Remove(_item);
                        itemNumbers.Remove(itemNumbers[i]);
                    }
                }
            }
        }
        else
        {
            Debug.Log("THERE IS NO " + _item + " in my Bags");
        }
        //IF There is no ITEM inside Inventory 

        //ResetButtonItems();
        DisplayItems();
    }
    
    public void TradeItem(Item upload, Item download)
    {
        RemoveItem(upload);
        AddItem(download);
    }

    public void ResetButtonItems()
    {
        for(int i = 0; i < itemButtons.Length; i++)//FOR LOOP ALL OF BUTTONS. Total Number in this game is 21 slots
        {
            if(i < items.Count)
            {
                itemButtons[i].thisItem = items[i];//Once This button contains the Item, Assign the ITEM to "thisItem";
            }
            else
            {
                itemButtons[i].thisItem = null;//Otherwise, Set the "thisItem" to NULL!
            }
        }
    } 

    public void CollectionsPickup(Item _item)
    {
        CharCollections.Add(_item);
    }
}

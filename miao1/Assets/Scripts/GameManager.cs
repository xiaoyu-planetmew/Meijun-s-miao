using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager: MonoBehaviour
{
    public int languageNum = 0;
    public int targetFrameRate;
    public static GameManager instance;//MARKER SINGLETON PATTERN
    public bool isPaused;
    public Texture2D cursorNormal;

    public List<Item> items = new List<Item>();//WHAT KIND OF ITEMS WE HAVE 
    public List<int> itemNumbers = new List<int>();//HOW MANY ITEMS WE HAVE
    public List<Item> CharCollections = new List<Item>();
    public GameObject slotList;
    public List<GameObject> slots;
    //public GameObject[] slots;
    public GameObject player;
    public List<bool> events = new List<bool>();
    [SerializeField]private List<string> eventName = new List<string>();
    public List<float> chapterRecord = new List<float>();

    public ItemButton thisButton;//Keep Track of which Item Button We are mouse Hovering
    public ItemButton[] itemButtons;//ALL of ITEM BUTTONS in this game [Used for reset]
    public string mail;
    public List<float> songRecord = new List<float>();


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
        Application.targetFrameRate = targetFrameRate;
    }

    private void Start()
    {
        if(GameObject.Find("language"))
        {
            languageNum = GameObject.Find("language").GetComponent<startMenuStartButton>().languageNum;
        }
        
        slots = new List<GameObject>();
        foreach(Transform child in slotList.transform)
        {
            slots.Add(child.gameObject);
        }
        DisplayItems();
        //Cursor.visible = false;
        //Cursor.SetCursor(cursorNormal, new Vector2(40, 13), CursorMode.Auto);
    }
    void Update()
    {
        
        if(SceneManager.GetActiveScene().name == "SampleScene")
        {
            itemCheck();
            DisplayItems();
            
        }
        
    }

    private void DisplayItems()
    {
        //We IGNORE the fact
        for(int i = 0; i < slots.Count; i++)
        {
            if(i < items.Count)
            {
                //UPDATE slots Item Image
                slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = items[i].itemSprite;

                //UPDATE slots Count Text
                slots[i].transform.GetChild(1).GetComponent<Text>().color = new Color32(241, 236, 226, 255);
                if(languageNum == 0)
                {
                    slots[i].transform.GetChild(1).GetComponent<Text>().text = items[i].itemDesJ;
                }
                if(languageNum == 1)
                {
                    slots[i].transform.GetChild(1).GetComponent<Text>().text = items[i].itemDesE;
                }
                if(languageNum == 2)
                {
                    slots[i].transform.GetChild(1).GetComponent<Text>().text = items[i].itemDesCN;
                }

                //UPDATE CLOSE/THROW button
                //slots[i].transform.GetChild(2).gameObject.SetActive(true);
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
                //slots[i].transform.GetChild(2).gameObject.SetActive(false);
            }
        }
    }

    public void AddItem(Item _item)
    {
        //MARKER IF There is one existing item in our bags(List)
        if(!items.Contains(_item))
        {
            items.Insert(0, _item);
            //items.Add(_item);
            itemNumbers.Insert(0, 1);
            //itemNumbers.Add(1);//ADD ONE 
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
        GameObject.Find("Scroll View").GetComponent<inventoryScroll>().resetBar();
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
    void itemCheck()
    {
        foreach(Item i in items)
        {
            if(i.itemName == "Moment1")
            {
                events[0] = true;
            }
            if(i.itemName == "spider")
            {
                events[2] = true;
            }
            if(i.itemName == "flintstone")
            {
                events[3] = true;
            }
            if(i.itemName == "Moment2")
            {
                events[5] = true;
            }
            if(i.itemName == "Moment3")
            {
                events[12] = true;
            }
            if(i.itemName == "Moment4")
            {
                events[16] = true;
            }
            if(i.itemName == "Moment5")
            {
                events[20] = true;
            }
        }
    }
    public void NextSceneMail(string s)
    {
        mail = s;
    }
    public void openDoor(Item _item)
    {
        if(items.Contains(_item))
        {
            RemoveItem(_item);
        }
    }
    public void destroyGameManager()
    {
        SceneManager.LoadScene("startMenu");
        Destroy(GameObject.Find("GameManager"));
        Destroy(GameObject.Find("language"));
        Time.timeScale = 1;
    }
    public void languageChange(int i)
    {
        languageNum = i;
    }
}

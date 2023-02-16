using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventoryResponse : MonoBehaviour
{
    public static inventoryResponse instance;
    public Text itemName;
    public List<Item> usefulItem = new List<Item>();
    public List<Item> wrongItem = new List<Item>();
    public string wrongTip;
    //public string nullTip;
    public List<GameObject> itemSource = new List<GameObject>();
    public GameObject tipUI;
    public GameObject usefulItemUI;
    public GameObject slots;
    public GameObject inventoryTip;
    Item thisItem;
    [SerializeField] GameObject thisObj;
    // Start is called before the first frame update
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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(inventoryTip.activeInHierarchy)
        {
            GameManager.instance.player.GetComponent<FinalMovement>().stopMoving();
        }else{
            GameManager.instance.player.GetComponent<FinalMovement>().continueMoving();
        }
        */
    }
    public void importMessage(Item _item)
    {
        if(itemSource.Contains(GameObject.Find("darkMask")))
        {
            GameObject.Find("darkMask").GetComponent<darkMask>().get = _item;
            GameObject.Find("darkMask").SendMessage("getMessage", GameObject.Find("darkMask"), SendMessageOptions.RequireReceiver);
        }else
        {
        if((!usefulItem.Contains(_item)) && (wrongItem.Count == 0))
        {
                if (GameObject.Find("GameManager"))
                {
                    if (GameManager.instance.languageNum == 0)
                    {
                        tipUI.transform.GetChild(0).GetComponent<Text>().text = "これは" + _item.itemDesJ + "です。";
                        GameObject obj = Instantiate(Resources.Load<GameObject>("Fonts/UDDigiKyokashoN-B"));
                        tipUI.transform.GetChild(0).GetComponent<Text>().font = obj.GetComponent<Text>().font;
                        DestroyImmediate(obj);
                        tipUI.SetActive(true);
                        StopAllCoroutines();
                        StartCoroutine(stopTip("これは" + _item.itemDesJ + "です。", 4f));
                    }
                    if (GameManager.instance.languageNum == 1)
                    {
                        tipUI.transform.GetChild(0).GetComponent<Text>().text = "I can't use this item";
                        GameObject obj = Instantiate(Resources.Load<GameObject>("Fonts/UDDigiKyokashoN-B"));
                        tipUI.transform.GetChild(0).GetComponent<Text>().font = obj.GetComponent<Text>().font;
                        DestroyImmediate(obj);
                        tipUI.SetActive(true);
                        StopAllCoroutines();
                        StartCoroutine(stopTip("I can't use this item", 4f));
                    }
                    if (GameManager.instance.languageNum == 2)
                    {
                        tipUI.transform.GetChild(0).GetComponent<Text>().text = "我不能用这个";
                        GameObject obj = Instantiate(Resources.Load<GameObject>("Fonts/简剪纸"));
                        tipUI.transform.GetChild(0).GetComponent<Text>().font = obj.GetComponent<Text>().font;
                        DestroyImmediate(obj);
                        tipUI.SetActive(true);
                        StopAllCoroutines();
                        StartCoroutine(stopTip("我不能用这个", 4f));
                    }
                }
                if (GameObject.Find("GameManager2") && _item.itemName != "painting")
                {
                    if (GameManager2.instance.languageNum == 0)
                    {
                        tipUI.transform.GetChild(0).GetComponent<Text>().text = "これは" + _item.itemDesJ + "です。";
                        GameObject obj = Instantiate(Resources.Load<GameObject>("Fonts/UDDigiKyokashoN-B"));
                        tipUI.transform.GetChild(0).GetComponent<Text>().font = obj.GetComponent<Text>().font;
                        DestroyImmediate(obj);
                        tipUI.SetActive(true);
                        StopAllCoroutines();
                        StartCoroutine(stopTip("これは" + _item.itemDesJ + "です。", 4f));
                    }
                    if (GameManager2.instance.languageNum == 1)
                    {
                        tipUI.transform.GetChild(0).GetComponent<Text>().text = "I can't use this item";
                        GameObject obj = Instantiate(Resources.Load<GameObject>("Fonts/UDDigiKyokashoN-B"));
                        tipUI.transform.GetChild(0).GetComponent<Text>().font = obj.GetComponent<Text>().font;
                        DestroyImmediate(obj);
                        tipUI.SetActive(true);
                        StopAllCoroutines();
                        StartCoroutine(stopTip("I can't use this item", 4f));
                    }
                    if (GameManager2.instance.languageNum == 2)
                    {
                        tipUI.transform.GetChild(0).GetComponent<Text>().text = "我不能用这个";
                        GameObject obj = Instantiate(Resources.Load<GameObject>("Fonts/简剪纸"));
                        tipUI.transform.GetChild(0).GetComponent<Text>().font = obj.GetComponent<Text>().font;
                        DestroyImmediate(obj);
                        tipUI.SetActive(true);
                        StopAllCoroutines();
                        StartCoroutine(stopTip("我不能用这个", 4f));
                    }
                }
            }
        if(wrongItem.Contains(_item))
        {
            if(itemSource.Contains(GameObject.Find("darkMask")))
            {
                GameObject.Find("darkMask").GetComponent<darkMask>().wrong();
            }else
            if(itemSource.Contains(GameObject.Find("birdDialogBox")))
            {
                GameObject.Find("birdDialogBox").transform.GetChild(0).GetChild(4).gameObject.SetActive(true);
                slots.GetComponent<slotsState>().turnOffInventory();
            }else{
                tipUI.transform.GetChild(0).GetComponent<Text>().text = wrongTip; 
                tipUI.SetActive(true);
                StopAllCoroutines();
                StartCoroutine(stopTip(wrongTip, 2f));
                slots.GetComponent<slotsState>().turnOnInventory();
                inventoryTip.SetActive(false);
                if (GameObject.Find("GameManager"))
                {
                   GameManager.instance.player.GetComponent<FinalMovement>().continueMoving();
                }
                if (GameObject.Find("GameManager2"))
                {
                    GameManager2.instance.player.GetComponent<FinalMovement>().continueMoving();
                }
                usefulItemUI.SetActive(false);
                //finishDialog();
            }
            for(int i = 0; i < usefulItem.Count; i++)
            {
                becomeUseless(usefulItem[0]);
            }       
            
            
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
        if(_item.itemName == "painting")
        {
            this.transform.parent.transform.Find("painting").gameObject.SetActive(true);
            GameManager2.instance.player.GetComponent<FinalMovement>().changeCanMove(false);
        }
    }
    public void emptyItems(string str)
    {
        tipUI.transform.GetChild(0).GetComponent<Text>().text = str;
        if (GameObject.Find("GameManager"))
        {
            if (GameManager.instance.languageNum == 0)
            {
                GameObject obj = Instantiate(Resources.Load<GameObject>("Fonts/UDDigiKyokashoN-B"));
                tipUI.transform.GetChild(0).GetComponent<Text>().font = obj.GetComponent<Text>().font;
                DestroyImmediate(obj);
            }
            if (GameManager.instance.languageNum == 1)
            {
                GameObject obj = Instantiate(Resources.Load<GameObject>("Fonts/UDDigiKyokashoN-B"));
                tipUI.transform.GetChild(0).GetComponent<Text>().font = obj.GetComponent<Text>().font;
                DestroyImmediate(obj);
            }
            if (GameManager.instance.languageNum == 2)
            {
                GameObject obj = Instantiate(Resources.Load<GameObject>("Fonts/简剪纸"));
                tipUI.transform.GetChild(0).GetComponent<Text>().font = obj.GetComponent<Text>().font;
                DestroyImmediate(obj);
            }
        }
        if (GameObject.Find("GameManager2"))
        {
            if (GameManager2.instance.languageNum == 0)
            {
                GameObject obj = Instantiate(Resources.Load<GameObject>("Fonts/UDDigiKyokashoN-B"));
                tipUI.transform.GetChild(0).GetComponent<Text>().font = obj.GetComponent<Text>().font;
                DestroyImmediate(obj);
            }
            if (GameManager2.instance.languageNum == 1)
            {
                GameObject obj = Instantiate(Resources.Load<GameObject>("Fonts/UDDigiKyokashoN-B"));
                tipUI.transform.GetChild(0).GetComponent<Text>().font = obj.GetComponent<Text>().font;
                DestroyImmediate(obj);
            }
            if (GameManager2.instance.languageNum == 2)
            {
                GameObject obj = Instantiate(Resources.Load<GameObject>("Fonts/简剪纸"));
                tipUI.transform.GetChild(0).GetComponent<Text>().font = obj.GetComponent<Text>().font;
                DestroyImmediate(obj);
            }
        }
        tipUI.SetActive(true);
        StopAllCoroutines();
        StartCoroutine(stopTip(str, 2f));
    }
    public void becomeUseful(Item _item, GameObject obj, string str)
    {
        if(!usefulItem.Contains(_item))
        {
            usefulItem.Add(_item);
            itemSource.Add(obj);
        }
        
        foreach(var i in GameManager.instance.items)
        {
            if(!usefulItem.Contains(i))
            {
                wrongItem.Add(i);
            }
        }
        wrongTip = str;
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
        wrongItem.Clear();
        wrongTip = "";
    }
    
    public void exportMessage()
    {
        
        GameManager.instance.player.GetComponent<FinalMovement>().continueMoving();
        if(thisObj == GameObject.Find("darkMask"))
        {
            GameObject.Find("darkMask").gameObject.GetComponent<darkMask>().thisSeed = thisItem;
        }
        thisObj.SendMessage("getMessage", thisObj, SendMessageOptions.RequireReceiver);
        
        thisItem = null;
        thisObj = null;
        inventoryTip.SetActive(false);
    }
    public void finishDialog()
    {
        slots.GetComponent<slotsState>().turnOnInventory();
        inventoryTip.SetActive(false);
        GameManager.instance.player.GetComponent<FinalMovement>().continueMoving();
        tipUI.SetActive(false);
        usefulItemUI.SetActive(false);
    }
    public void resetTip()
    {
        StopAllCoroutines();
    }
    IEnumerator stopTip(string _str, float t)
    {
        yield return new WaitForSeconds(t);
        if((tipUI.transform.GetChild(0).GetComponent<Text>().text == _str) && tipUI.gameObject.activeInHierarchy)
        {
            tipUI.SetActive(false);
            StopAllCoroutines();
        }
    }
    public void girlTip(string str, float t)
    {
        tipUI.SetActive(true);
        tipUI.transform.GetChild(0).GetComponent<Text>().text = str;
        StopAllCoroutines();
        StartCoroutine(stopTip(str, t));
    }
    public void activeInventoryTip()
    {
        inventoryTip.SetActive(true);
        GameManager.instance.player.GetComponent<FinalMovement>().stopMoving();
    }
}

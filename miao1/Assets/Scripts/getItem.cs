using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class getItem : MonoBehaviour
{
    public GameObject getItemTip;
    //public Item obj;
    //public string strJ;
    //public string strE;
    //bool finish = false;
    public List<Item> _items = new List<Item>();
    public TextAsset textFile;
    public List<TextAsset> textFilesJ = new List<TextAsset>();
    public List<TextAsset> textFilesE = new List<TextAsset>();
    
    public List<bool> finish = new List<bool>();
    [SerializeField]List<string> textList = new List<string>();
    [SerializeField]int index;
    Item nowItem;
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<_items.Count;i++)
        {
            finish.Add(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(GameManager.instance.items.Contains(obj) && !finish)
        {
            if(GameManager.instance.languageNum == 0)
            {
                inventoryResponse.instance.girlTip(strJ, 2f);
            }
            if(GameManager.instance.languageNum == 1)
            {
                inventoryResponse.instance.girlTip(strE, 2f);
            }
            finish = true;
            this.GetComponent<getItem>().enabled = false;
        }
        */
        if(GameManager.instance.items.Contains(_items[3]))
        {
            finish[0] = true;
        }
        for(int i=0; i<_items.Count; i++)
        {
            if(GameManager.instance.items.Contains(_items[i]) && !finish[i])
            {
                showTip(i);
            }
        }
    }
    void showTip(int _item)
    {
        nowItem = _items[_item];
        getItemTip.SetActive(true);
        if(GameManager.instance.languageNum == 0)
        {
            GetTextFromFile(textFilesJ[_item]);
        }
        if(GameManager.instance.languageNum == 1)
        {
            GetTextFromFile(textFilesE[_item]);
        }
        index = 0;
        StopAllCoroutines();
        nextTip();
        finish[_item] = true;
        //getItemTip.transform.GetChild(0).GetComponent<t
    }
    public void nextTip()
    {
        StopAllCoroutines();
        if(index == textList.Count)
        {
            getItemTip.SetActive(false);
        }else if(index == textList.Count - 1)
        {
            StartCoroutine(closeTip());
        }
        if(index < textList.Count)
        {
            getItemTip.transform.GetChild(0).GetComponent<Text>().text = "";
            getItemTip.transform.GetChild(0).GetComponent<Text>().DOText(textList[index], textList[index].Length * 0.05f);
            
            StartCoroutine(nextButton(textList[index].Length * 0.05f));
            index++;
        }
    }   
    void GetTextFromFile(TextAsset file)
    {
        textList.Clear();
        var lineData = file.text.Split('#'); 
        foreach(var line in lineData)
        {
            //Debug.Log(line);
            textList.Add(line);
        }
        textList.RemoveAt(textList.Count - 1);
    }
    IEnumerator nextButton(float i)
    {
        getItemTip.transform.GetChild(1).gameObject.SetActive(false);
        yield return new WaitForSeconds(i);
        getItemTip.transform.GetChild(1).gameObject.SetActive(true);
    }
    IEnumerator closeTip()
    {
        yield return new WaitForSeconds(6f);
        if(getItemTip.activeInHierarchy)
        {
            getItemTip.SetActive(false);
        }
    }
}

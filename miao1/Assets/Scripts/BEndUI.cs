using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BEndUI : MonoBehaviour
{
    public GameObject title;
    public GameObject fullCombo;
    public GameObject newBest;
    public GameObject rank1;
    public GameObject rank2;
    public GameObject rank3;
    public GameObject num1;
    public GameObject num2;
    public GameObject num3;
    public GameObject num4;
    public GameObject dot;
    public GameObject percent;
    public GameObject maxCombo;
    public GameObject perfect;
    public GameObject good;
    public GameObject miss;
    public int titleNum;
    public int combo;
    public int perfectNum;
    public int goodNum;
    public int missNum;
    public float accurary;
    public bool newBestBool;
    public bool fullComboBool;
    public List<Sprite> titleList = new List<Sprite>();
    public List<Sprite> rankList = new List<Sprite>();
    public List<Sprite> numberList = new List<Sprite>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BEnd()
    {
        title.GetComponent<Image>().sprite = titleList[titleNum];
        if(newBestBool)
        {
            newBest.SetActive(true);
        }else{
            newBest.SetActive(false);
        }
        if(fullComboBool)
        {
            fullCombo.SetActive(true);
        }else{
            fullCombo.SetActive(false);
        }
        maxCombo.GetComponent<Text>().text = combo.ToString();
        perfect.GetComponent<Text>().text = perfectNum.ToString();
        good.GetComponent<Text>().text = goodNum.ToString();
        miss.GetComponent<Text>().text = missNum.ToString();
    
        if(accurary < 0.5f)
        {
            rank1.GetComponent<Image>().sprite = rankList[1];
            rank2.GetComponent<Image>().sprite = rankList[1];
            rank3.GetComponent<Image>().sprite = rankList[1];
        }
        if(accurary >= 0.5f && accurary < 0.7f)
        {
            rank1.GetComponent<Image>().sprite = rankList[0];
            rank2.GetComponent<Image>().sprite = rankList[1];
            rank3.GetComponent<Image>().sprite = rankList[1];
        }
        if(accurary >= 0.7f && accurary < 0.9f)
        {
            rank1.GetComponent<Image>().sprite = rankList[0];
            rank2.GetComponent<Image>().sprite = rankList[0];
            rank3.GetComponent<Image>().sprite = rankList[1];
        }
        if(accurary >= 0.9f)
        {
            rank1.GetComponent<Image>().sprite = rankList[0];
            rank2.GetComponent<Image>().sprite = rankList[0];
            rank3.GetComponent<Image>().sprite = rankList[0];
        }
    }
}

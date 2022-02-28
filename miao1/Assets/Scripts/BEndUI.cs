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
    public GameObject fullPercent;
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
        showLetter();
    }
    public void showLetter()
    {
        if(accurary == 1)
        {
            fullPercent.SetActive(true);
            num1.SetActive(false);
            num2.SetActive(false);
            num3.SetActive(false);
            num4.SetActive(false);
        }else{
            letters(accurary);
        }
    }
    //IEnumerator randomLetter()
    //{
    //    for(int i = 0; i < )
    //}
    public void letters(float a)
    {
        fullPercent.SetActive(false);
        num1.SetActive(true);
        num2.SetActive(true);
        num3.SetActive(true);
        num4.SetActive(true);
        num1.GetComponent<Image>().sprite = numberList[Mathf.FloorToInt(((a * 10000) / Mathf.Pow(10, 3))) % 10];
        
        if(Mathf.FloorToInt(((a * 10000) / Mathf.Pow(10, 3))) % 10 == 1)
        {
            num1.GetComponent<RectTransform>().sizeDelta = new Vector2(66, 147);
        }else
        if(Mathf.FloorToInt(((a * 10000) / Mathf.Pow(10, 3))) % 10 == 2)
        {
            num1.GetComponent<RectTransform>().sizeDelta = new Vector2(101, 150);
        }else
        {
            num1.GetComponent<RectTransform>().sizeDelta = new Vector2(110, 148);
        }
        num2.GetComponent<Image>().sprite = numberList[Mathf.FloorToInt(((a * 10000) / Mathf.Pow(10, 2))) % 10];
        if(Mathf.FloorToInt(((a * 10000) / Mathf.Pow(10, 2))) % 10 == 1)
        {
            num2.GetComponent<RectTransform>().sizeDelta = new Vector2(66, 147);
        }else
        if(Mathf.FloorToInt(((a * 10000) / Mathf.Pow(10, 2))) % 10 == 2)
        {
            num2.GetComponent<RectTransform>().sizeDelta = new Vector2(101, 150);
        }else
        {
            num2.GetComponent<RectTransform>().sizeDelta = new Vector2(110, 148);
        }
        num3.GetComponent<Image>().sprite = numberList[Mathf.FloorToInt(((a * 10000) / Mathf.Pow(10, 1))) % 10];
        if(Mathf.FloorToInt(((a * 10000) / Mathf.Pow(10, 1))) % 10 == 1)
        {
            num3.GetComponent<RectTransform>().sizeDelta = new Vector2(66, 147);
        }else
        if(Mathf.FloorToInt(((a * 10000) / Mathf.Pow(10, 1))) % 10 == 2)
        {
            num3.GetComponent<RectTransform>().sizeDelta = new Vector2(101, 150);
        }else
        {
            num3.GetComponent<RectTransform>().sizeDelta = new Vector2(110, 148);
        }
        num4.GetComponent<Image>().sprite = numberList[Mathf.FloorToInt(((a * 10000) / Mathf.Pow(10, 0))) % 10];
        if(Mathf.FloorToInt(((a * 10000) / Mathf.Pow(10, 0))) % 10 == 1)
        {
            num4.GetComponent<RectTransform>().sizeDelta = new Vector2(66, 147);
        }else
        if(Mathf.FloorToInt(((a * 10000) / Mathf.Pow(10, 0))) % 10 == 2)
        {
            num4.GetComponent<RectTransform>().sizeDelta = new Vector2(101, 150);
        }else
        {
            num4.GetComponent<RectTransform>().sizeDelta = new Vector2(110, 148);
        }
        num2.GetComponent<RectTransform>().localPosition = new Vector3(num1.GetComponent<RectTransform>().localPosition.x + num1.GetComponent<RectTransform>().sizeDelta.x - 10, num1.GetComponent<RectTransform>().localPosition.y, 0);
        dot.GetComponent<RectTransform>().localPosition = new Vector3(num2.GetComponent<RectTransform>().localPosition.x + num2.GetComponent<RectTransform>().sizeDelta.x - 10,  num1.GetComponent<RectTransform>().localPosition.y, 0);
        num3.GetComponent<RectTransform>().localPosition = new Vector3(dot.GetComponent<RectTransform>().localPosition.x + dot.GetComponent<RectTransform>().sizeDelta.x - 10, num1.GetComponent<RectTransform>().localPosition.y, 0);
        num4.GetComponent<RectTransform>().localPosition = new Vector3(num3.GetComponent<RectTransform>().localPosition.x + num3.GetComponent<RectTransform>().sizeDelta.x - 10, num1.GetComponent<RectTransform>().localPosition.y, 0);
        percent.GetComponent<RectTransform>().localPosition = new Vector3(num4.GetComponent<RectTransform>().localPosition.x + num4.GetComponent<RectTransform>().sizeDelta.x - 10, num4.GetComponent<RectTransform>().localPosition.y, 0);
    }
}

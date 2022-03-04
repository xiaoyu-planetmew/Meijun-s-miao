using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class BEndUI : MonoBehaviour
{
    public GameObject bg;
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
    public GameObject maxComboText;
    public GameObject perfectText;
    public GameObject goodText;
    public GameObject missText;
    public int titleNum;
    public int combo;
    public int perfectNum;
    public int goodNum;
    public int missNum;
    public float accurary;
    public bool newBestBool;
    public bool fullComboBool;
    public List<Sprite> bgList = new List<Sprite>();
    public List<Sprite> titleList = new List<Sprite>();
    public List<Sprite> rankList = new List<Sprite>();
    public List<Sprite> numberList = new List<Sprite>();
    public GameObject endButton;
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
        endButton.SetActive(false);
        title.GetComponent<Image>().sprite = titleList[titleNum];
        bg.GetComponent<Image>().sprite = bgList[titleNum];
        if(newBestBool)
        {
            newBest.SetActive(true);
            newBest.GetComponent<Image>().color = new Vector4(1, 1, 1, 0);
        }else{
            newBest.SetActive(false);
        }
        if(fullComboBool)
        {
            fullCombo.SetActive(true);
            fullCombo.GetComponent<Image>().color = new Vector4(1, 1, 1, 0);
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
        title.GetComponent<Image>().color = new Vector4(1, 1, 1, 0);
        rank1.GetComponent<Image>().color = new Vector4(1, 1, 1, 0);
        rank2.GetComponent<Image>().color = new Vector4(1, 1, 1, 0);
        rank3.GetComponent<Image>().color = new Vector4(1, 1, 1, 0);
        num1.GetComponent<Image>().color = new Vector4(1, 1, 1, 0);
        num2.GetComponent<Image>().color = new Vector4(1, 1, 1, 0);
        num3.GetComponent<Image>().color = new Vector4(1, 1, 1, 0);
        num4.GetComponent<Image>().color = new Vector4(1, 1, 1, 0);
        dot.GetComponent<Image>().color = new Vector4(1, 1, 1, 0);
        percent.GetComponent<Image>().color = new Vector4(1, 1, 1, 0);
        maxCombo.GetComponent<Text>().color = new Vector4(1, 1, 1, 0);
        maxComboText.GetComponent<Text>().color = new Vector4(1, 1, 1, 0);
        perfect.GetComponent<Text>().color = new Vector4(1, 1, 1, 0);
        perfectText.GetComponent<Text>().color = new Vector4(1, 1, 1, 0);
        good.GetComponent<Text>().color = new Vector4(1, 1, 1, 0);
        goodText.GetComponent<Text>().color = new Vector4(1, 1, 1, 0);
        miss.GetComponent<Text>().color = new Vector4(1, 1, 1, 0);
        missText.GetComponent<Text>().color = new Vector4(1, 1, 1, 0);
        ani();
        
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
    public void ani()
    {
        Sequence quence = DOTween.Sequence();
        StartCoroutine(endGameButton(quence));
        quence.Append(title.GetComponent<Image>().DOFade(1, 0.5f));
        if(fullComboBool)
        {
            quence.Join(fullCombo.GetComponent<Image>().DOFade(1, 0.5f));
        }
        if(newBestBool)
        {
            quence.Join(newBest.GetComponent<Image>().DOFade(1, 0.5f));
        }
        
        quence.Append(rank1.GetComponent<Image>().DOFade(1, 0.5f));
        quence.Append(rank2.GetComponent<Image>().DOFade(1, 0.5f));
        quence.Append(rank3.GetComponent<Image>().DOFade(1, 0.5f));
        if(accurary == 1)
        {
            quence.Append(fullPercent.GetComponent<Image>().DOFade(1, 0.5f));
        }else{
            quence.Append(num1.GetComponent<Image>().DOFade(1, 0.5f));
            quence.Join(num2.GetComponent<Image>().DOFade(1, 0.5f));
            quence.Join(num3.GetComponent<Image>().DOFade(1, 0.5f));
            quence.Join(num4.GetComponent<Image>().DOFade(1, 0.5f));
            quence.Join(dot.GetComponent<Image>().DOFade(1, 0.5f));
            quence.Join(percent.GetComponent<Image>().DOFade(1, 0.5f));
        }
        quence.Append(maxCombo.GetComponent<Text>().DOFade(1, 0.5f));
        quence.Join(maxComboText.GetComponent<Text>().DOFade(1, 0.5f));
        quence.Append(perfect.GetComponent<Text>().DOFade(1, 0.5f));
        quence.Join(perfectText.GetComponent<Text>().DOFade(1, 0.5f));
        quence.Append(good.GetComponent<Text>().DOFade(1, 0.5f));
        quence.Join(goodText.GetComponent<Text>().DOFade(1, 0.5f));
        quence.Append(miss.GetComponent<Text>().DOFade(1, 0.5f));
        quence.Join(missText.GetComponent<Text>().DOFade(1, 0.5f));
    }
    IEnumerator endGameButton(Sequence quence)
    {
        yield return quence.WaitForCompletion();
        endButton.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BChapterChoose : MonoBehaviour
{
    public int chapterQuantity;
    public int pprevious;
    public int previous;
    
    public int chapter = 0;
    public int next;
    public int nnext;
    
    public int chapterDiffculty = 0;
    public float changeAniTime;
    public List<Sprite> chapterFigure;
    public List<Sprite> chapterTitle;
    public List<Sprite> chapterName;
    public List<float> chapterRecord;
    public GameObject ppreviousChapter;
    public GameObject previousChapter;
    public GameObject nowChapter;
    public GameObject nextChapter;
    public GameObject nnextChapter;
    public List<GameObject> buttons = new List<GameObject>();
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        chapterQuantity = chapterFigure.Count;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void chapterChange(int direction)
    {
        chapter += direction;
        if(chapter < 0)
        {
            chapter = chapterQuantity - 1;
        }
        if(chapter >= chapterQuantity)
        {
            chapter = 0;
        }
        previous = chapter - 1;
        if(previous < 0)
        {
            previous = chapterQuantity - 1;
        }
        pprevious = previous -1;
        if(previous == 0)
        {
            pprevious = chapterQuantity - 1;
        }
        next = chapter + 1;
        if(next > chapterQuantity - 1)
        {
            next = 0;
        }
        nnext = next + 1;
        if(next == chapterQuantity - 1)
        {
            nnext = 0;
        }
        foreach(GameObject child in buttons)
        {
            
            child.GetComponent<Button>().enabled = false;
            
        }
        ppreviousChapter.transform.GetChild(0).GetComponent<Image>().sprite = chapterFigure[pprevious];
        ppreviousChapter.transform.GetChild(0).GetComponent<Image>().color = new Color32(255, 255, 255, 125);
        ppreviousChapter.transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite = chapterTitle[pprevious];
        ppreviousChapter.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = new Color32(255, 255, 255, 125);
        ppreviousChapter.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = chapterName[pprevious];
        ppreviousChapter.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = new Color32(255, 255, 255, 125);
        ppreviousChapter.transform.localPosition = new Vector3(-1880,0,0);
        nnextChapter.transform.GetChild(0).GetComponent<Image>().sprite = chapterFigure[nnext];
        nnextChapter.transform.GetChild(0).GetComponent<Image>().color = new Color32(255, 255, 255, 125);
        nnextChapter.transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite = chapterTitle[nnext];
        nnextChapter.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = new Color32(255, 255, 255, 125);
        nnextChapter.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = chapterName[nnext];
        nnextChapter.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = new Color32(255, 255, 255, 125);
        this.GetComponent<BChapterChangeAni>().aniTime = changeAniTime;
        this.GetComponent<BChapterChangeAni>().changeDirection = direction;
        this.GetComponent<BChapterChangeAni>().enabled = true;
        this.GetComponent<BChapterChangeAni>().previousChapter = previousChapter;
        this.GetComponent<BChapterChangeAni>().ppreviousChapter = ppreviousChapter;
        this.GetComponent<BChapterChangeAni>().nowChapter = nowChapter;
        this.GetComponent<BChapterChangeAni>().nextChapter = nextChapter;
        this.GetComponent<BChapterChangeAni>().nnextChapter = nnextChapter;
        this.GetComponent<BChapterChangeAni>().enabled = true;
        this.GetComponent<BChapterChangeAni>().speed = ((nowChapter.transform.localPosition.x - ppreviousChapter.transform.localPosition.x)/ changeAniTime) / 2;
        this.GetComponent<BChapterChangeAni>().colorSpeed = 0.5f / changeAniTime;
        this.GetComponent<BChapterChangeAni>().scaleSpeed = 0.5f / changeAniTime;
        StartCoroutine(finishAni());
    }
    public void diffcultChange(int diffculty)
    {
        chapterDiffculty = diffculty;
    }
    void changeAniLeft(int direction)
    {

    }
    IEnumerator finishAni()
    {
        yield return new WaitForSeconds(changeAniTime);
        ppreviousChapter.transform.GetChild(0).GetComponent<Image>().sprite = chapterFigure[pprevious];
        ppreviousChapter.transform.GetChild(0).GetComponent<Image>().color = new Color32(255, 255, 255, 125);
        ppreviousChapter.transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite = chapterTitle[pprevious];
        ppreviousChapter.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = new Color32(255, 255, 255, 125);
        ppreviousChapter.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = chapterName[pprevious];
        ppreviousChapter.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = new Color32(255, 255, 255, 125);
        ppreviousChapter.transform.localPosition = new Vector3(-1880,0,0);
        ppreviousChapter.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        previousChapter.transform.GetChild(0).GetComponent<Image>().sprite = chapterFigure[previous];
        previousChapter.transform.GetChild(0).GetComponent<Image>().color = new Color32(255, 255, 255, 125);
        previousChapter.transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite = chapterTitle[previous];
        previousChapter.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = new Color32(255, 255, 255, 125);
        previousChapter.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = chapterName[previous];
        previousChapter.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = new Color32(255, 255, 255, 125);
        previousChapter.transform.localPosition = new Vector3(-940,0,0);
        previousChapter.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        nowChapter.transform.GetChild(0).GetComponent<Image>().sprite = chapterFigure[chapter];
        nowChapter.transform.GetChild(0).GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        nowChapter.transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite = chapterTitle[chapter];
        nowChapter.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        nowChapter.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = chapterName[chapter];
        nowChapter.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        nowChapter.transform.GetChild(0).GetChild(2).gameObject.SetActive(true);
        nowChapter.transform.GetChild(0).GetChild(2).GetComponent<Text>().text = ((float)chapterRecord[chapter]).ToString("0.00%");
        nowChapter.transform.localPosition = new Vector3(0,0,0);
        nowChapter.transform.localScale = new Vector3(1f, 1f, 1f);
        nextChapter.transform.GetChild(0).GetComponent<Image>().sprite = chapterFigure[next];
        nextChapter.transform.GetChild(0).GetComponent<Image>().color = new Color32(255, 255, 255, 125);
        nextChapter.transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite = chapterTitle[next];
        nextChapter.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = new Color32(255, 255, 255, 125);
        nextChapter.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = chapterName[next];
        nextChapter.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = new Color32(255, 255, 255, 125);
        nnextChapter.transform.GetChild(0).GetComponent<Image>().sprite = chapterFigure[nnext];
        nextChapter.transform.localPosition = new Vector3(940,0,0);
        nextChapter.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        nnextChapter.transform.GetChild(0).GetComponent<Image>().color = new Color32(255, 255, 255, 125);
        nnextChapter.transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite = chapterTitle[nnext];
        nnextChapter.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = new Color32(255, 255, 255, 125);
        nnextChapter.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = chapterName[nnext];
        nnextChapter.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = new Color32(255, 255, 255, 125);
        nnextChapter.transform.localPosition = new Vector3(1880,0,0);
        nnextChapter.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        foreach(GameObject child in buttons)
        {
            
            child.GetComponent<Button>().enabled = true;
            
        }
        this.GetComponent<BChapterChangeAni>().enabled = false;
    }
}

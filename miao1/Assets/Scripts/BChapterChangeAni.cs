using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BChapterChangeAni : MonoBehaviour
{
    public int changeDirection;
    float startTime;
    public float aniTime;
    public GameObject ppreviousChapter;
    public GameObject previousChapter;
    public GameObject nowChapter;
    public GameObject nextChapter;
    public GameObject nnextChapter;
    
    public float speed;
    public float colorSpeed;
    public float scaleSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnEnable()
    {
        
        //startTime = Time.time;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(changeDirection == -1)
        {
            toLeft();
        }
        if(changeDirection == 1)
        {
            toRight();
        }
    }
    public void toLeft()
    {
        //Debug.Log("-1");
        previousChapter.transform.localPosition = Vector3.MoveTowards(previousChapter.transform.localPosition, new Vector3(-1880, 0, 0), Time.deltaTime * speed);
        nowChapter.transform.localPosition = Vector3.MoveTowards(nowChapter.transform.localPosition, new Vector3(-940, 0, 0), Time.deltaTime * speed);
        nowChapter.transform.localScale = new Vector3(nowChapter.transform.localScale.x - Time.deltaTime * scaleSpeed, nowChapter.transform.localScale.y - Time.deltaTime * scaleSpeed, nowChapter.transform.localScale.z - Time.deltaTime * scaleSpeed);
        nowChapter.transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, (nowChapter.transform.GetChild(0).GetComponent<Image>().color.a - Time.deltaTime * colorSpeed));
        nowChapter.transform.GetChild(0).GetChild(2).gameObject.SetActive(false);
        nowChapter.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, (nowChapter.transform.GetChild(0).GetComponent<Image>().color.a - Time.deltaTime * colorSpeed));
        nowChapter.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = new Color(1, 1, 1, (nowChapter.transform.GetChild(0).GetComponent<Image>().color.a - Time.deltaTime * colorSpeed));
        nextChapter.transform.localPosition = Vector3.MoveTowards(nextChapter.transform.localPosition, new Vector3(0, 0, 0), Time.deltaTime * speed);
        nextChapter.transform.localScale = new Vector3(nextChapter.transform.localScale.x + Time.deltaTime * scaleSpeed, nextChapter.transform.localScale.y + Time.deltaTime * scaleSpeed, nextChapter.transform.localScale.z + Time.deltaTime * scaleSpeed);
        nextChapter.transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, (nextChapter.transform.GetChild(0).GetComponent<Image>().color.a + Time.deltaTime * colorSpeed));
        nextChapter.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, (nextChapter.transform.GetChild(0).GetComponent<Image>().color.a + Time.deltaTime * colorSpeed));
        nextChapter.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = new Color(1, 1, 1, (nextChapter.transform.GetChild(0).GetComponent<Image>().color.a + Time.deltaTime * colorSpeed));
        nnextChapter.transform.localPosition = Vector3.MoveTowards(nnextChapter.transform.localPosition, new Vector3(940, 0, 0), Time.deltaTime * speed);
    }
    public void toRight()
    {
        //Debug.Log("1");
        previousChapter.transform.localPosition = Vector3.MoveTowards(previousChapter.transform.localPosition, new Vector3(0, 0, 0), Time.deltaTime * speed);
        previousChapter.transform.localScale = new Vector3(previousChapter.transform.localScale.x + Time.deltaTime * scaleSpeed, previousChapter.transform.localScale.y + Time.deltaTime * scaleSpeed, previousChapter.transform.localScale.z + Time.deltaTime * scaleSpeed);
        previousChapter.transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, (previousChapter.transform.GetChild(0).GetComponent<Image>().color.a + Time.deltaTime * colorSpeed));
        previousChapter.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, (previousChapter.transform.GetChild(0).GetComponent<Image>().color.a + Time.deltaTime * colorSpeed));
        previousChapter.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = new Color(1, 1, 1, (previousChapter.transform.GetChild(0).GetComponent<Image>().color.a + Time.deltaTime * colorSpeed));
        
        nowChapter.transform.localPosition = Vector3.MoveTowards(nowChapter.transform.localPosition, new Vector3(940, 0, 0), Time.deltaTime * speed);
        nowChapter.transform.localScale = new Vector3(nowChapter.transform.localScale.x - Time.deltaTime * scaleSpeed, nowChapter.transform.localScale.y - Time.deltaTime * scaleSpeed, nowChapter.transform.localScale.z - Time.deltaTime * scaleSpeed);
        nowChapter.transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, (nowChapter.transform.GetChild(0).GetComponent<Image>().color.a - Time.deltaTime * colorSpeed));
        nowChapter.transform.GetChild(0).GetChild(2).gameObject.SetActive(false);
        nowChapter.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, (nowChapter.transform.GetChild(0).GetComponent<Image>().color.a - Time.deltaTime * colorSpeed));
        nowChapter.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = new Color(1, 1, 1, (nowChapter.transform.GetChild(0).GetComponent<Image>().color.a - Time.deltaTime * colorSpeed));
        
        nextChapter.transform.localPosition = Vector3.MoveTowards(nextChapter.transform.localPosition, new Vector3(1880, 0, 0), Time.deltaTime * speed);     
        ppreviousChapter.transform.localPosition = Vector3.MoveTowards(ppreviousChapter.transform.localPosition, new Vector3(-940, 0, 0), Time.deltaTime * speed);
    }
}

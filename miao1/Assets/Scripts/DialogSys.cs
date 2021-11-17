using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogSys : MonoBehaviour
{
    [Header("targetItem")]
    public Item target;
    [Header("eventNum")]
    public int eventNum;
    public GameObject player;
    public GameObject npc;
    public GameObject textLabelcn;
    public GameObject textLabelen;
    public GameObject textBackgroundLeft;
    public GameObject textBackgroundRight;
    public GameObject startButton;
    public GameObject nextPageButton;
    public GameObject sceneTransButton;
    public List<TextAsset> textfiles = new List<TextAsset>();
    public bool firstMeet;
    public bool isTalking;
    private bool holdTarget;
    public int index;
    public List<string> textList = new List<string>();
    public List<string> textTalker = new List<string>(); 
    // Start is called before the first frame update
    void Start()
    {
        firstMeet = true;        
    }
    private void OnEnable()
    {        
    }
    // Update is called once per frame
    void Update()
    {
        if((Mathf.Abs(npc.transform.position.x - player.transform.position.x) < 2) && !isTalking)
        {
            startButton.SetActive(true);
        }
        if((Mathf.Abs(npc.transform.position.x - player.transform.position.x) > 2))
        {
            startButton.SetActive(false);
        }
        
    }
    void GetTextFromFile(TextAsset file)
    {
        textList.Clear();
        textTalker.Clear();
        var lineData = file.text.Split('\n');        
        foreach(var line in lineData)
        {
            Debug.Log(line);
            textList.Add(line);
        }
        Debug.Log(textList.Count);
        textList.RemoveAt(textList.Count - 1);
        //textList.RemoveAt(textList.Count);
        for(int j = 0; j < textList.Count; j++)
        {
            if(textList[j][0] == 'A')
            {
                textList[j] = textList[j].Substring(1);
                textTalker.Add("left");
            }
            if(textList[j][0] == 'B')
            {
                textList[j] = textList[j].Substring(1);
                textTalker.Add("right");
            }
        }
    }
    public void fileChoose()
    {
        startButton.SetActive(false);
        if(firstMeet && !GameManager.instance.events[8])
        {
            GetTextFromFile(textfiles[0]);
            firstMeet = false;
            GameManager.instance.events[8] = true;
        }else
        {
            if(!GameManager.instance.events[0] && !GameManager.instance.events[5])
            {
                GetTextFromFile(textfiles[2]);
                holdTarget = false;
            }
            if(GameManager.instance.events[0] && !GameManager.instance.events[6])
            {
                GetTextFromFile(textfiles[1]);
                holdTarget = true;
            }
            if(GameManager.instance.events[5] && !GameManager.instance.events[7])
            {
                GetTextFromFile(textfiles[1]);
                holdTarget = true;
            }
            /*
            for (int i = 0; i < GameManager.instance.items.Count; i++)
            {
                if(GameManager.instance.items[i] == target)
                {
                    GetTextFromFile(textfiles[1]);
                    holdTarget = true;
                }
                else
                {
                    GetTextFromFile(textfiles[2]);
                    holdTarget = false;
                }
            }
            */
        }
        startButton.gameObject.SetActive(false);
        nextPageButton.gameObject.SetActive(true);
        textLabelcn.gameObject.SetActive(true);
        textLabelen.gameObject.SetActive(true);
        if(textTalker[0] == "left")
        {
            textBackgroundLeft.gameObject.SetActive(true);
        }
        if(textTalker[0] == "right")
        {
            textBackgroundRight.gameObject.SetActive(true);
        }
        isTalking = true;
        Time.timeScale = 0.0f;
        GameManager.instance.isPaused = true;
        index = 0;
        textLabelcn.GetComponent<TMP_Text>().text = textList[index];
        textLabelen.GetComponent<TMP_Text>().text = textList[index + 1];
        index = index + 2;
    }
    public void dialogBox()
    {
        if(!holdTarget)
        {
            if(index + 1 <= textList.Count)
            {
                if(textTalker[index] == "left")
                {
                    textBackgroundLeft.gameObject.SetActive(true);
                    textBackgroundRight.gameObject.SetActive(false);
                }
                if(textTalker[index] == "right")
                {
                    textBackgroundLeft.gameObject.SetActive(false);
                    textBackgroundRight.gameObject.SetActive(true);
                }
                textLabelcn.GetComponent<TMP_Text>().text = textList[index];
                textLabelen.GetComponent<TMP_Text>().text = textList[index + 1];
                index = index + 2;
            }
            else
            {
                index = 0;
                textBackgroundLeft.gameObject.SetActive(false);
                textBackgroundRight.gameObject.SetActive(false);
                nextPageButton.gameObject.SetActive(false);
            
                textLabelcn.gameObject.SetActive(false);
                textLabelen.gameObject.SetActive(false);
                isTalking = false;
                Time.timeScale = 1.0f;
                GameManager.instance.isPaused = false;
            }
        }
        if(holdTarget)
        {
            if(index == textList.Count || index == textList.Count + 1)
            {
                sceneTransButton.SetActive(true);
                GameManager.instance.events[eventNum] = true;
                index++;
            }
            if(index + 1 <= textList.Count)
            {
                if(textTalker[index] == "left")
                {
                    textBackgroundLeft.gameObject.SetActive(true);
                    textBackgroundRight.gameObject.SetActive(false);
                }
                if(textTalker[index] == "right")
                {
                    textBackgroundLeft.gameObject.SetActive(false);
                    textBackgroundRight.gameObject.SetActive(true);
                }
                textLabelcn.GetComponent<TMP_Text>().text = textList[index];
                textLabelen.GetComponent<TMP_Text>().text = textList[index + 1];
                index = index + 2;
            }            
            if(index == textList.Count + 2)
            {
                index = 0;
                textBackgroundLeft.gameObject.SetActive(false);
                textBackgroundRight.gameObject.SetActive(false);
                nextPageButton.gameObject.SetActive(false);
                textLabelcn.gameObject.SetActive(false);
                textLabelen.gameObject.SetActive(false);
                isTalking = false;
                Time.timeScale = 1.0f;
                GameManager.instance.isPaused = false;
                sceneTransButton.SetActive(false);
            }
        }
    }
}

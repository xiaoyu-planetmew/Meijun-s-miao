using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Spine.Unity;

public class DialogSys : MonoBehaviour
{
    [Header("targetItem")]
    public Item target;
    [Header("eventNum")]
    public int eventNum;
    public GameObject player;
    public GameObject npc;
    public GameObject cam;
    public GameObject textLabelleft;
    public GameObject textLabelright;
    public GameObject textBackgroundLeft;
    public GameObject textBackgroundRight;
    public GameObject startButton;
    public GameObject nextPageButton;
    public GameObject sceneTransButton;
    public List<TextAsset> textfiles = new List<TextAsset>();
    public bool firstMeet;
    public bool isTalking;
    //private bool holdTarget;
    public int index;
    public List<string> textList = new List<string>();
    public List<string> textTalker = new List<string>(); 
    public float textSpeed;
    public List<AudioClip> leftAudio = new List<AudioClip>();
    public List<AudioClip> rightAudio = new List<AudioClip>();
    bool textFinished;
    public string output;
    public Item bamao;
    public Item dongcao;
    int textNum;
    // Start is called before the first frame update
    void Start()
    {
        firstMeet = true;        
    }
    // Update is called once per frame
    void Update()
    {
        player = GameManager.instance.player;
        if((Mathf.Abs(npc.transform.position.x - player.transform.position.x) <= 5) && !isTalking)
        {
            startButton.SetActive(true);
        }
        if((Mathf.Abs(npc.transform.position.x - player.transform.position.x) > 5))
        {
            startButton.SetActive(false);
        }
        
    }
    void GetTextFromFile(TextAsset file)
    {
        textList.Clear();
        textTalker.Clear();
        var lineData = file.text.Split('#');        
        foreach(var line in lineData)
        {
            //Debug.Log(line);
            textList.Add(line);
        }
        //Debug.Log(textList.Count);
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
        //startButton.GetComponent<Image>().enabled = false;
        if(!GameManager.instance.events[8])
        {
            GetTextFromFile(textfiles[0]);
            textNum = 0;
            //firstMeet = false;
            //GameManager.instance.events[8] = true;
        }else
        {
            if(!(GameManager.instance.events[0] || GameManager.instance.events[9]) 
            && !(GameManager.instance.events[5] || GameManager.instance.events[11]) 
            && !(GameManager.instance.events[12] || GameManager.instance.events[15])
            && !(GameManager.instance.events[16] || GameManager.instance.events[19])
            && !(GameManager.instance.events[20] || GameManager.instance.events[23]))
            {
                GetTextFromFile(textfiles[2]);
                textNum = 2;
                //holdTarget = false;
            }
            else
            if(GameManager.instance.events[0] && GameManager.instance.events[1] && GameManager.instance.events[6] && !GameManager.instance.events[9])
            {
                GetTextFromFile(textfiles[3]);
                textNum = 3;
                //GameManager.instance.events[9] = true;
            }else
            if(GameManager.instance.events[5] && GameManager.instance.events[10] && GameManager.instance.events[7] && !GameManager.instance.events[11])
            {
                GetTextFromFile(textfiles[5]);
                textNum = 5;
                //GameManager.instance.events[11] = true;
            }else
            if(GameManager.instance.events[12] && GameManager.instance.events[14] && GameManager.instance.events[13] && !GameManager.instance.events[15])
            {
                GetTextFromFile(textfiles[6]);
                textNum = 6;
               //GameManager.instance.events[15] = true;
            }else
            if(GameManager.instance.events[16] && GameManager.instance.events[18] && GameManager.instance.events[17] && !GameManager.instance.events[19])
            {
                GetTextFromFile(textfiles[7]);
                textNum = 7;
                //GameManager.instance.events[19] = true;
            }else
            if(GameManager.instance.events[20] && GameManager.instance.events[22] && GameManager.instance.events[21] && !GameManager.instance.events[23])
            {
                GetTextFromFile(textfiles[8]);
                textNum = 8;
                //GameManager.instance.events[23] = true;
            }else
            if((GameManager.instance.events[0] && !GameManager.instance.events[1] && GameManager.instance.events[6])
            || (GameManager.instance.events[5] && !GameManager.instance.events[10] && GameManager.instance.events[7])
            || (GameManager.instance.events[12] && !GameManager.instance.events[14] && GameManager.instance.events[13])
            || (GameManager.instance.events[16] && !GameManager.instance.events[18] && GameManager.instance.events[17])
            || (GameManager.instance.events[20] && !GameManager.instance.events[22] && GameManager.instance.events[21]))
            {
                GetTextFromFile(textfiles[4]);
                textNum = 4;
            }
            else
            if((GameManager.instance.events[0] && !GameManager.instance.events[6])
            || (GameManager.instance.events[5] && !GameManager.instance.events[7])
            || (GameManager.instance.events[12] && !GameManager.instance.events[13])
            || (GameManager.instance.events[16] && !GameManager.instance.events[17])
            || (GameManager.instance.events[20] && !GameManager.instance.events[21])
            )
            {
                GetTextFromFile(textfiles[1]);
                textNum = 1;
                //holdTarget = true;
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
        //startButton.gameObject.SetActive(false);
        //nextPageButton.gameObject.SetActive(true);
        //textLabelcn.gameObject.SetActive(true);
        //textLabelen.gameObject.SetActive(true);
        index = 0;
        if(textTalker[0] == "left")
        {
            textBackgroundLeft.gameObject.SetActive(true);
            //textLabelleft.GetComponent<Text>().text = textList[index];
            StartCoroutine(SetTextLeft());
            leftAudioRandom();
        }
        if(textTalker[0] == "right")
        {
            textBackgroundRight.gameObject.SetActive(true);
            //textLabelright.GetComponent<Text>().text = textList[index];
            
            StartCoroutine(SetTextRight());
            rightAudioRandom();
        }
        isTalking = true;
        //Time.timeScale = 0.0f;
        //GameManager.instance.isPaused = true;
        
        //textLabelcn.GetComponent<TMP_Text>().text = textList[index];
        //textLabelen.GetComponent<TMP_Text>().text = textList[index + 1];
        
        startButton.SetActive(false);
    }
    void dialogWithoutTrans()
    {
        Debug.Log("dialogWithoutTrans"); 
        if(index == textList.Count)
            {
                index = 0;
                textBackgroundLeft.gameObject.SetActive(false);
                textBackgroundRight.gameObject.SetActive(false);
                //nextPageButton.gameObject.SetActive(false);
            
                //textLabelcn.gameObject.SetActive(false);
                //textLabelen.gameObject.SetActive(false);
                isTalking = false;
                Time.timeScale = 1.0f;
                GameManager.instance.isPaused = false;
            }
        if(index < textList.Count && isTalking)
            {
                if(textTalker[index] == "left")
                {
                    if(textList[index][0] == 'E')
                    {
                        textList[index] = textList[index].Substring(1);
                        this.GetComponent<dialogAfterShake>().shake();
                    }
                    if(textList[index][0] == 'F')
                    {
                        textList[index] = textList[index].Substring(1);
                        GameManager.instance.AddItem(bamao);
                        GameManager.instance.AddItem(dongcao);
                    }
                    StartCoroutine(SetTextLeft());
                    textBackgroundLeft.gameObject.SetActive(true);
                    textBackgroundRight.gameObject.SetActive(false);
                    leftAudioRandom();
                    
                    
                    //textLabelleft.GetComponent<Text>().text = textList[index];
                }
                if(textTalker[index] == "right")
                {
                    if(textList[index][0] == 'C')
                    {
                        //npc.transform.GetChild(1).GetComponent<AudioSource>().Play();
                        textList[index] = textList[index].Substring(1);
                        output = textList[index];
                        //npc.transform.GetChild(0).GetComponent<SkeletonAnimation>().state.SetAnimation(0, "wdance", true);
                        if(cam.activeInHierarchy)
                        {
                            cam.GetComponent<cameraFocus>().focus();
                            Debug.Log("focus");
                        }
                    }
                    if(textList[index][0] == 'D')
                    {
                        //npc.transform.GetChild(1).GetComponent<AudioSource>().Stop();
                        textList[index] = textList[index].Substring(1);
                        output = textList[index];
                        //npc.transform.GetChild(0).GetComponent<SkeletonAnimation>().state.SetAnimation(0, "widle", true);
                        if(cam.activeInHierarchy)
                        {
                            cam.GetComponent<cameraFocus>().cancelFocus();
                        }
                    }
                    output = textList[index];
                    StartCoroutine(SetTextRight());
                    textBackgroundLeft.gameObject.SetActive(false);
                    textBackgroundRight.gameObject.SetActive(true);
                    if(textList[index][0] != 'D' && textList[index][0] != 'C')
                    {
                        rightAudioRandom();
                    }
                    
                    
                    
                    //textLabelright.GetComponent<Text>().text = textList[index];
                }
                //textLabelcn.GetComponent<TMP_Text>().text = textList[index];
                //textLabelen.GetComponent<TMP_Text>().text = textList[index + 1];
                //index = index + 1;
            }
            
    }
    void dialogWithTrans()
    {
        Debug.Log("dialogWithTrans");            
        if(index == textList.Count + 1)
        {
            index = 0;
            textBackgroundLeft.gameObject.SetActive(false);
            textBackgroundRight.gameObject.SetActive(false);
            //nextPageButton.gameObject.SetActive(false);
            //textLabelcn.gameObject.SetActive(false);
            //textLabelen.gameObject.SetActive(false);
            isTalking = false;
            Time.timeScale = 1.0f;
            GameManager.instance.isPaused = false;
            //sceneTransButton.SetActive(false);
            sceneTransButton.GetComponent<NPCSceneTrans>().turnOff();
        }
        if(index == textList.Count && isTalking)
        {
            //sceneTransButton.SetActive(true);
            sceneTransButton.GetComponent<NPCSceneTrans>().turnOn();
            index++;
        }
        if(index < textList.Count && isTalking)
        {
            if(textTalker[index] == "left")
            {
                StartCoroutine(SetTextLeft());
                textBackgroundLeft.gameObject.SetActive(true);
                textBackgroundRight.gameObject.SetActive(false);
                
                //textLabelleft.GetComponent<Text>().text = textList[index];
                leftAudioRandom();
            }
            if(textTalker[index] == "right")
            {
                StartCoroutine(SetTextRight());
                textBackgroundLeft.gameObject.SetActive(false);
                textBackgroundRight.gameObject.SetActive(true);
                
                //textLabelright.GetComponent<Text>().text = textList[index];
                rightAudioRandom();
            }
                //textLabelcn.GetComponent<TMP_Text>().text = textList[index];
                //textLabelen.GetComponent<TMP_Text>().text = textList[index + 1];
                //index = index + 1;
        }
    }
    
    public void dialogBox()
    {
        if(!GameManager.instance.events[8] && textFinished)
        {
            if(index == textList.Count)
            {
                index = 0;
                textBackgroundLeft.gameObject.SetActive(false);
                textBackgroundRight.gameObject.SetActive(false);
                //nextPageButton.gameObject.SetActive(false);
            
                //textLabelcn.gameObject.SetActive(false);
                //textLabelen.gameObject.SetActive(false);
                isTalking = false;
                Time.timeScale = 1.0f;
                GameManager.instance.isPaused = false;
                GameManager.instance.events[8] = true;
            }
            if(index < textList.Count && isTalking)
            {
                if(textTalker[index] == "left")
                {
                    StartCoroutine(SetTextLeft());
                    textBackgroundLeft.gameObject.SetActive(true);
                    textBackgroundRight.gameObject.SetActive(false);
                    
                    //textLabelleft.GetComponent<Text>().text = textList[index];
                    
                    leftAudioRandom();
                }
                if(textTalker[index] == "right")
                {
                    StartCoroutine(SetTextRight());
                    textBackgroundLeft.gameObject.SetActive(false);
                    textBackgroundRight.gameObject.SetActive(true);
                    
                    //textLabelright.GetComponent<Text>().text = textList[index];
                    rightAudioRandom();
                }
                //textLabelcn.GetComponent<TMP_Text>().text = textList[index];
                //textLabelen.GetComponent<TMP_Text>().text = textList[index + 1];
                //index = index + 1;
            }
            
        }
        if(GameManager.instance.events[8] && textFinished)
        {
            if(textNum == 1)
            {
                dialogWithTrans();
            }else{
                dialogWithoutTrans();
            }
            /*
            if((!GameManager.instance.events[0] && !GameManager.instance.events[5] && !GameManager.instance.events[12] && !GameManager.instance.events[16] && !GameManager.instance.events[20]) 
            || (GameManager.instance.events[0] && GameManager.instance.events[1] && GameManager.instance.events[6]) 
            || (GameManager.instance.events[5] && GameManager.instance.events[7] && GameManager.instance.events[10])
            || (GameManager.instance.events[12] && GameManager.instance.events[14] && GameManager.instance.events[13])
            || (GameManager.instance.events[16] && GameManager.instance.events[18] && GameManager.instance.events[17])
            || (GameManager.instance.events[20] && GameManager.instance.events[22] && GameManager.instance.events[21]))
            if(textNum == 0 || textNum == )
            {
                dialogWithoutTrans();
            }else
            if((GameManager.instance.events[0] && !GameManager.instance.events[1])
            || (GameManager.instance.events[5] && !GameManager.instance.events[10])
            || (GameManager.instance.events[12] && !GameManager.instance.events[14])
            || (GameManager.instance.events[16] && !GameManager.instance.events[18])
            || (GameManager.instance.events[20] && !GameManager.instance.events[22]))
            
            {
                dialogWithTrans();
            }
            */
            /*
            if(!GameManager.instance.events[0] && !GameManager.instance.events[5])
            {
                dialogWithTrans();
            }
            */
        }
    }
    
    void leftAudioRandom()
    {
        this.GetComponent<AudioSource>().enabled = false;
        this.GetComponent<AudioSource>().enabled = true;
        
        StopCoroutine("audioChangeLeft");
        StopCoroutine("audioChangeRight");
        StartCoroutine(audioStop());
        
        //Debug.Log(i);
        if(!this.GetComponent<AudioSource>().isPlaying && this.GetComponent<AudioSource>().enabled == true)
        {
            StartCoroutine(audioChangeLeft());
        }
        
    }
    void rightAudioRandom()
    {
        
        this.GetComponent<AudioSource>().enabled = false;
        this.GetComponent<AudioSource>().enabled = true;
        
        StopCoroutine("audioChangeLeft");
        StopCoroutine("audioChangeRight");
        StartCoroutine(audioStop());
        
        //Debug.Log(i);
        if(!this.GetComponent<AudioSource>().isPlaying && this.GetComponent<AudioSource>().enabled == true)
        {
            StartCoroutine(audioChangeRight());
        }
    }
    
    IEnumerator SetTextLeft()
    {
        //Debug.Log(textList[index].Length);
        textFinished = false;
        textLabelleft.GetComponent<Text>().text = "";
        for(int i = 0; i < textList[index].Length; i++)
        {
            //Debug.Log(i);
            textLabelleft.GetComponent<Text>().text += textList[index][i];
            yield return new WaitForSeconds(textSpeed);
        }
        index = index + 1;
        textFinished = true;
    }
    IEnumerator SetTextRight()
    {
        textFinished = false;
        textLabelright.GetComponent<Text>().text = "";
        //Debug.Log(textList[index].Length);
        for(int i = 0; i < textList[index].Length; i++)
        {
            //Debug.Log(i);
            textLabelright.GetComponent<Text>().text += textList[index][i];
            yield return new WaitForSeconds(textSpeed);
        }
        index = index + 1;
        textFinished = true;
    }
    IEnumerator audioStop()
    {
        yield return new WaitForSeconds(((textList[index].Length) * textSpeed));
        this.GetComponent<AudioSource>().Stop();
        this.GetComponent<AudioSource>().enabled = false;
        StopCoroutine("audioChangeLeft");
        StopCoroutine("audioChangeRight");
    }
    IEnumerator audioChangeLeft()
    {
        int i = Random.Range(0, leftAudio.Count);
        while(this.GetComponent<AudioSource>().enabled == true && textTalker[index] == "left")
        {        
            i = Random.Range(0, leftAudio.Count);
            this.GetComponent<AudioSource>().clip = leftAudio[i];
            this.GetComponent<AudioSource>().Play();
            //Debug.Log("left");
            yield return new WaitForSeconds(leftAudio[i].length);
        }
        
        //StartCoroutine(audioChangeLeft());
    }
    IEnumerator audioChangeRight()
    {
        int i = Random.Range(0, rightAudio.Count);
        while(this.GetComponent<AudioSource>().enabled == true && textTalker[index] == "right")
        {        
            i = Random.Range(0, rightAudio.Count);
            this.GetComponent<AudioSource>().clip = rightAudio[i];
            this.GetComponent<AudioSource>().Play();
            //Debug.Log("right");
            yield return new WaitForSeconds(rightAudio[i].length);
        }
        
        //StartCoroutine(audioChangeRight());
    }
}

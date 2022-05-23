using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using Spine.Unity;

public class cameraFocus : MonoBehaviour
{
    public Transform focusLocation;
    public GameObject focusCanvas;
    public GameObject npc;
    public GameObject NPCDialogBox;
    float NPCDialogBoxScale;
    public float speed;
    public GameObject panel;
    public GameObject text1;
    public GameObject text2;
    public List<TextAsset> textfiles = new List<TextAsset>();
    public List<string> textList = new List<string>();
    public List<Sprite> BGList = new List<Sprite>();
    public List<Sprite> titleList = new List<Sprite>();
    public List<string> nameListJ = new List<string>();
    public List<string> nameListE = new List<string>();
    public List<string> nameListCN = new List<string>();
    int index;
    float loX;
    float loY;
    float loZ;
    int nowPlaying;
    //public Transform homeLocation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text2.GetComponent<Text>().text = GameObject.Find("NPCDialogBox").gameObject.GetComponent<DialogSys>().output;
    }
    void GetTextFromFile(TextAsset file)
    {
        textList.Clear();
        var lineData = file.text.Split('\n');        
        foreach(var line in lineData)
        {
            //Debug.Log(line);
            textList.Add(line);
        }
        //Debug.Log(textList.Count);
        textList.RemoveAt(textList.Count - 1);
        //textList.RemoveAt(textList.Count);
    }
    void fileChoose()
    {
        if((GameManager.instance.events[0] && GameManager.instance.events[1] && GameManager.instance.events[6] && GameManager.instance.events[8]) 
        && !(GameManager.instance.events[9]))
        {
            GetTextFromFile(textfiles[0]);
            nowPlaying = 1;
            focusCanvas.transform.GetChild(0).GetComponent<Image>().sprite = BGList[0];
            focusCanvas.transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = titleList[0];
            if(GameManager.instance.languageNum == 0)
            {
                focusCanvas.transform.GetChild(1).GetChild(1).GetComponent<Text>().text = nameListJ[0];
            }
            if(GameManager.instance.languageNum == 1)
            {
                focusCanvas.transform.GetChild(1).GetChild(1).GetComponent<Text>().text = nameListE[0];
            }
            if(GameManager.instance.languageNum == 2)
            {
                focusCanvas.transform.GetChild(1).GetChild(1).GetComponent<Text>().text = nameListCN[0];
            }
        }else
        if((GameManager.instance.events[5] && GameManager.instance.events[10] && GameManager.instance.events[7] && GameManager.instance.events[8]) 
        && !(GameManager.instance.events[11]))
        {
            GetTextFromFile(textfiles[1]);
            nowPlaying = 2;
            focusCanvas.transform.GetChild(0).GetComponent<Image>().sprite = BGList[1];
            focusCanvas.transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = titleList[1];
            if(GameManager.instance.languageNum == 0)
            {
                focusCanvas.transform.GetChild(1).GetChild(1).GetComponent<Text>().text = nameListJ[1];
            }
            if(GameManager.instance.languageNum == 1)
            {
                focusCanvas.transform.GetChild(1).GetChild(1).GetComponent<Text>().text = nameListE[1];
            }
            if(GameManager.instance.languageNum == 2)
            {
                focusCanvas.transform.GetChild(1).GetChild(1).GetComponent<Text>().text = nameListCN[1];
            }
        }else
        if((GameManager.instance.events[12] && GameManager.instance.events[13] && GameManager.instance.events[14] && GameManager.instance.events[8]) 
        && !(GameManager.instance.events[15]))
        {
            GetTextFromFile(textfiles[2]);
            nowPlaying = 3;
            focusCanvas.transform.GetChild(0).GetComponent<Image>().sprite = BGList[2];
            focusCanvas.transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = titleList[2];
            if(GameManager.instance.languageNum == 0)
            {
                focusCanvas.transform.GetChild(1).GetChild(1).GetComponent<Text>().text = nameListJ[2];
            }
            if(GameManager.instance.languageNum == 1)
            {
                focusCanvas.transform.GetChild(1).GetChild(1).GetComponent<Text>().text = nameListE[2];
            }
            if(GameManager.instance.languageNum == 2)
            {
                focusCanvas.transform.GetChild(1).GetChild(1).GetComponent<Text>().text = nameListCN[2];
            }
        }else
        if((GameManager.instance.events[16] && GameManager.instance.events[17] && GameManager.instance.events[18] && GameManager.instance.events[8]) 
        && !(GameManager.instance.events[19]))
        {
            GetTextFromFile(textfiles[3]);
            nowPlaying = 4;
            focusCanvas.transform.GetChild(0).GetComponent<Image>().sprite = BGList[3];
            focusCanvas.transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = titleList[3];
            if(GameManager.instance.languageNum == 0)
            {
                focusCanvas.transform.GetChild(1).GetChild(1).GetComponent<Text>().text = nameListJ[3];
            }
            if(GameManager.instance.languageNum == 1)
            {
                focusCanvas.transform.GetChild(1).GetChild(1).GetComponent<Text>().text = nameListE[3];
            }
            if(GameManager.instance.languageNum == 2)
            {
                focusCanvas.transform.GetChild(1).GetChild(1).GetComponent<Text>().text = nameListCN[3];
            }
        }
        if((GameManager.instance.events[20] && GameManager.instance.events[21] && GameManager.instance.events[22] && GameManager.instance.events[8]) 
        && !(GameManager.instance.events[23]))
        {
            GetTextFromFile(textfiles[4]);
            nowPlaying = 5;
            focusCanvas.transform.GetChild(0).GetComponent<Image>().sprite = BGList[4];
            focusCanvas.transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = titleList[4];
            if(GameManager.instance.languageNum == 0)
            {
                focusCanvas.transform.GetChild(1).GetChild(1).GetComponent<Text>().text = nameListJ[4];
            }
            if(GameManager.instance.languageNum == 1)
            {
                focusCanvas.transform.GetChild(1).GetChild(1).GetComponent<Text>().text = nameListE[4];
            }
            if(GameManager.instance.languageNum == 2)
            {
                focusCanvas.transform.GetChild(1).GetChild(1).GetComponent<Text>().text = nameListCN[4];
            }
        }
        index = 0;
        text1.GetComponent<Text>().text = textList[index];
    }
    public void focus()
    {
        loX = this.transform.position.x;
        loY = this.transform.position.y;
        loZ = this.transform.position.z;
        //homeLocation.transform.position = new Vector3(loX, loY, loZ);
        this.GetComponent<CinemachineBrain>().enabled = false;
        focusCanvas.transform.GetChild(0).gameObject.SetActive(true);
        GameManager.instance.player.transform.GetChild(0).GetComponent<Animator>().SetTrigger("disappear");
        GameObject.Find("InventoryCanvas").gameObject.GetComponent<Canvas>().enabled = false;
        fileChoose();
        NPCDialogBoxScale = NPCDialogBox.transform.localScale.x;
        NPCDialogBox.transform.localScale = new Vector3(0, 0, 0);
        StartCoroutine(ani());
        StartCoroutine(MoveToPosition());
        NPCDialogBox.transform.GetChild(2).gameObject.GetComponent<Image>().enabled = false;
        NPCDialogBox.transform.GetChild(2).gameObject.SetActive(false);
    }
    public void cancelFocus()
    {

        panel.transform.GetChild(3).gameObject.GetComponent<buttonMinor>().enabled = false;
        panel.SetActive(false);
        npc.transform.GetChild(1).GetComponent<AudioSource>().Stop();
        npc.transform.GetChild(0).GetComponent<SkeletonAnimation>().state.SetAnimation(0, "widle", true);
        StartCoroutine(stopBack());
        StartCoroutine(colorChangeBack());
        /*
       this.GetComponent<CinemachineBrain>().enabled = true;
       focusCanvas.transform.GetChild(0).GetComponent<Image>().color = new Color(focusCanvas.transform.GetChild(0).GetComponent<Image>().color.r, focusCanvas.transform.GetChild(0).GetComponent<Image>().color.g, focusCanvas.transform.GetChild(0).GetComponent<Image>().color.b, 0);
       focusCanvas.transform.GetChild(1).GetComponent<Image>().color = new Color(focusCanvas.transform.GetChild(1).GetComponent<Image>().color.r, focusCanvas.transform.GetChild(0).GetComponent<Image>().color.g, focusCanvas.transform.GetChild(1).GetComponent<Image>().color.b, 0);
       focusCanvas.transform.GetChild(1).GetChild(0).GetComponent<Image>().color = new Color(focusCanvas.transform.GetChild(1).GetChild(0).GetComponent<Image>().color.r, focusCanvas.transform.GetChild(1).GetChild(0).GetComponent<Image>().color.g, focusCanvas.transform.GetChild(1).GetChild(0).GetComponent<Image>().color.b, 0);
       focusCanvas.transform.GetChild(1).GetChild(1).GetComponent<Text>().color = new Color(focusCanvas.transform.GetChild(1).GetChild(1).GetComponent<Text>().color.r, focusCanvas.transform.GetChild(1).GetChild(1).GetComponent<Text>().color.g, focusCanvas.transform.GetChild(1).GetChild(1).GetComponent<Text>().color.b, 0);     
       focusCanvas.transform.GetChild(0).gameObject.SetActive(false);
       GameManager.instance.player.transform.GetChild(0).GetComponent<Animator>().SetTrigger("appear");
       GameObject.Find("InventoryCanvas").gameObject.GetComponent<Canvas>().enabled = true;
       npc.transform.GetChild(1).GetComponent<AudioSource>().Stop();
       npc.transform.GetChild(0).GetComponent<SkeletonAnimation>().state.SetAnimation(0, "widle", true);
       panel.SetActive(false);
       NPCDialogBox.transform.localScale = new Vector3(NPCDialogBoxScale, NPCDialogBoxScale, NPCDialogBoxScale);
       index = 0;
       NPCDialogBox.transform.GetChild(2).gameObject.SetActive(true);
       */
    }
    public void next()
    {
        //Debug.Log("1");
        NPCDialogBox.transform.GetChild(2).gameObject.GetComponent<Button>().onClick.Invoke();
        index++;
        if(index <= textList.Count - 1)
        {
        text1.GetComponent<Text>().text = textList[index];
        }
        StartCoroutine(nextHide());
    }
    IEnumerator MoveToPosition()
    {     
        while (gameObject.transform.position != focusLocation.position)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, focusLocation.position, speed * Time.deltaTime);
            yield return 0;
        }
        StartCoroutine(colorChange());
    }
    IEnumerator MoveBackToPosition()
    {     
        while (gameObject.transform.position != new Vector3(loX, loY, loZ))
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3(loX, loY, loZ), speed * Time.deltaTime);
            yield return 0;
        }
        //StartCoroutine(colorChangeBack());
    }
    IEnumerator colorChange()
    {
        while(focusCanvas.transform.GetChild(0).GetComponent<Image>().color.a < 1)
        {
            focusCanvas.transform.GetChild(0).GetComponent<Image>().color = new Color(focusCanvas.transform.GetChild(0).GetComponent<Image>().color.r, focusCanvas.transform.GetChild(0).GetComponent<Image>().color.g, focusCanvas.transform.GetChild(0).GetComponent<Image>().color.b, focusCanvas.transform.GetChild(0).GetComponent<Image>().color.a+0.01f);
            focusCanvas.transform.GetChild(1).GetComponent<Image>().color = new Color(focusCanvas.transform.GetChild(1).GetComponent<Image>().color.r, focusCanvas.transform.GetChild(0).GetComponent<Image>().color.g, focusCanvas.transform.GetChild(1).GetComponent<Image>().color.b, focusCanvas.transform.GetChild(1).GetComponent<Image>().color.a+0.01f);
            focusCanvas.transform.GetChild(1).GetChild(0).GetComponent<Image>().color = new Color(focusCanvas.transform.GetChild(1).GetChild(0).GetComponent<Image>().color.r, focusCanvas.transform.GetChild(1).GetChild(0).GetComponent<Image>().color.g, focusCanvas.transform.GetChild(1).GetChild(0).GetComponent<Image>().color.b, focusCanvas.transform.GetChild(1).GetChild(0).GetComponent<Image>().color.a+0.01f);
            focusCanvas.transform.GetChild(1).GetChild(1).GetComponent<Text>().color = new Color(focusCanvas.transform.GetChild(1).GetChild(1).GetComponent<Text>().color.r, focusCanvas.transform.GetChild(1).GetChild(1).GetComponent<Text>().color.g, focusCanvas.transform.GetChild(1).GetChild(1).GetComponent<Text>().color.b, focusCanvas.transform.GetChild(1).GetChild(1).GetComponent<Text>().color.a+0.01f);
            //Debug.Log(focusCanvas.transform.GetChild(0).GetComponent<Image>().color.a);
            //GameObject.Find("")
            yield return 0;
        }
    }
    IEnumerator colorChangeBack()
    {
        while(focusCanvas.transform.GetChild(0).GetComponent<Image>().color.a > 0)
        {
            focusCanvas.transform.GetChild(0).GetComponent<Image>().color = new Color(focusCanvas.transform.GetChild(0).GetComponent<Image>().color.r, focusCanvas.transform.GetChild(0).GetComponent<Image>().color.g, focusCanvas.transform.GetChild(0).GetComponent<Image>().color.b, focusCanvas.transform.GetChild(0).GetComponent<Image>().color.a-0.01f);
            focusCanvas.transform.GetChild(1).GetComponent<Image>().color = new Color(focusCanvas.transform.GetChild(1).GetComponent<Image>().color.r, focusCanvas.transform.GetChild(0).GetComponent<Image>().color.g, focusCanvas.transform.GetChild(1).GetComponent<Image>().color.b, focusCanvas.transform.GetChild(1).GetComponent<Image>().color.a-0.01f);
            focusCanvas.transform.GetChild(1).GetChild(0).GetComponent<Image>().color = new Color(focusCanvas.transform.GetChild(1).GetChild(0).GetComponent<Image>().color.r, focusCanvas.transform.GetChild(1).GetChild(0).GetComponent<Image>().color.g, focusCanvas.transform.GetChild(1).GetChild(0).GetComponent<Image>().color.b, focusCanvas.transform.GetChild(1).GetChild(0).GetComponent<Image>().color.a-0.01f);
            focusCanvas.transform.GetChild(1).GetChild(1).GetComponent<Text>().color = new Color(focusCanvas.transform.GetChild(1).GetChild(1).GetComponent<Text>().color.r, focusCanvas.transform.GetChild(1).GetChild(1).GetComponent<Text>().color.g, focusCanvas.transform.GetChild(1).GetChild(1).GetComponent<Text>().color.b, focusCanvas.transform.GetChild(1).GetChild(1).GetComponent<Text>().color.a-0.01f);
            //Debug.Log(focusCanvas.transform.GetChild(0).GetComponent<Image>().color.a);
            //GameObject.Find("")
            yield return 0;
        }
        StartCoroutine(MoveBackToPosition());
    }
    IEnumerator stopBack()
    {
        yield return new WaitUntil(() => gameObject.transform.position == new Vector3(loX, loY, loZ));
        this.GetComponent<CinemachineBrain>().enabled = true;
        focusCanvas.transform.GetChild(0).GetComponent<Image>().color = new Color(focusCanvas.transform.GetChild(0).GetComponent<Image>().color.r, focusCanvas.transform.GetChild(0).GetComponent<Image>().color.g, focusCanvas.transform.GetChild(0).GetComponent<Image>().color.b, 0);
        focusCanvas.transform.GetChild(1).GetComponent<Image>().color = new Color(focusCanvas.transform.GetChild(1).GetComponent<Image>().color.r, focusCanvas.transform.GetChild(0).GetComponent<Image>().color.g, focusCanvas.transform.GetChild(1).GetComponent<Image>().color.b, 0);
        focusCanvas.transform.GetChild(1).GetChild(0).GetComponent<Image>().color = new Color(focusCanvas.transform.GetChild(1).GetChild(0).GetComponent<Image>().color.r, focusCanvas.transform.GetChild(1).GetChild(0).GetComponent<Image>().color.g, focusCanvas.transform.GetChild(1).GetChild(0).GetComponent<Image>().color.b, 0);
        focusCanvas.transform.GetChild(1).GetChild(1).GetComponent<Text>().color = new Color(focusCanvas.transform.GetChild(1).GetChild(1).GetComponent<Text>().color.r, focusCanvas.transform.GetChild(1).GetChild(1).GetComponent<Text>().color.g, focusCanvas.transform.GetChild(1).GetChild(1).GetComponent<Text>().color.b, 0);     
        focusCanvas.transform.GetChild(0).gameObject.SetActive(false);
        GameManager.instance.player.transform.GetChild(0).GetComponent<Animator>().SetTrigger("appear");
        GameObject.Find("InventoryCanvas").gameObject.GetComponent<Canvas>().enabled = true;
        
        panel.SetActive(false);
        NPCDialogBox.transform.localScale = new Vector3(NPCDialogBoxScale, NPCDialogBoxScale, NPCDialogBoxScale);
        index = 0;
        NPCDialogBox.transform.GetChild(2).gameObject.SetActive(true);
        if(nowPlaying == 1)
        {
            GameManager.instance.events[9] = true;
        }
        if(nowPlaying == 2)
        {
            GameManager.instance.events[11] = true;
        }
        if(nowPlaying == 3)
        {
            GameManager.instance.events[15] = true;
        }
        if(nowPlaying == 4)
        {
            GameManager.instance.events[19] = true;
        }
        if(nowPlaying == 5)
        {
            GameManager.instance.events[23] = true;
        }
        
    }
    IEnumerator ani()
    {
        yield return new WaitUntil(() => focusCanvas.transform.GetChild(0).GetComponent<Image>().color.a >= 1);  
        //Debug.Log("1");
        panel.SetActive(true);
        npc.transform.GetChild(1).GetComponent<AudioSource>().Play();
        npc.transform.GetChild(0).GetComponent<SkeletonAnimation>().state.SetAnimation(0, "wdance", true);
        NPCDialogBox.transform.GetChild(2).gameObject.GetComponent<Button>().onClick.Invoke();
        NPCDialogBox.transform.GetChild(2).gameObject.GetComponent<Image>().enabled = true;
        StartCoroutine(nextHide());
    }
    IEnumerator nextHide()
    {
        panel.transform.GetChild(2).gameObject.SetActive(false);
        panel.transform.GetChild(3).gameObject.SetActive(false);
        panel.transform.GetChild(3).gameObject.GetComponent<buttonMinor>().enabled = false;
        //NPCDialogBox.transform.GetChild(2).gameObject.SetActive(false);
        yield return new WaitForSeconds(2.5f);
        panel.transform.GetChild(2).gameObject.SetActive(true);
        panel.transform.GetChild(3).gameObject.SetActive(true);
        panel.transform.GetChild(3).gameObject.GetComponent<buttonMinor>().enabled = true;
        //NPCDialogBox.transform.GetChild(2).gameObject.SetActive(true);
    }
}

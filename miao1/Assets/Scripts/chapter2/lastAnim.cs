using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Cinemachine;
using Spine;
using Spine.Unity;
using static Spine.AnimationState;

public class lastAnim : MonoBehaviour
{
    public List<GameObject> anims = new List<GameObject>();
    public GameObject mask;
    public Transform focusLocation;
    public GameObject focusCanvas;
    public GameObject npc;
    //public GameObject NPCDialogBox;
    public GameObject cam;
    //float NPCDialogBoxScale;
    public float speed;
    public GameObject panel;
    public GameObject text1;
    public GameObject text2;
    public List<string> textList = new List<string>();
    public List<string> textListHmong = new List<string>();
    public TextAsset hmong;
    public TextAsset jp;
    public TextAsset en;
    public TextAsset ch;
    public TextAsset textFile;
    //public List<Sprite> BGList = new List<Sprite>();
    //public List<Sprite> titleList = new List<Sprite>();
    //public List<string> nameListJ = new List<string>();
    //public List<string> nameListE = new List<string>();
    //public List<string> nameListCN = new List<string>();
    public Font fontJE;
    public Font fontCN;
    int index;
    //[SerializeField] int nowPlaying;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void finalStart()
    {
        mask.gameObject.SetActive(true);
        DG.Tweening.Sequence quence = DOTween.Sequence();
        
        quence.Append(mask.GetComponent<SpriteRenderer>().DOFade(0.99f, 2)).OnComplete(() =>
        {
            cam.transform.localPosition = focusLocation.transform.localPosition;
            cam.GetComponent<Camera>().fieldOfView = 100;
            GameManager2.instance.player.transform.localPosition= new Vector3(-46.53f, 0.26f, 0f);
            GameManager2.instance.player.transform.Find("ChracterNew").localScale = new Vector3(1, 1, 1);
            //Debug.Log("2");
            //girlAnim.SetActive(true);
            mask.SetActive(false);
            focusCanvas.SetActive(true);
            languageChange();
            fileChoose();
            GameManager2.instance.player.transform.Find("ChracterNew").GetComponent<SkeletonAnimation>().state.SetAnimation(0, "summon", true);
            npc.transform.Find("Spine GameObject (wushi)").GetComponent<SkeletonAnimation>().state.SetAnimation(0, "wdance", true);
            //girlAnim.SetActive(true);
        });
        GameObject.Find("InventoryCanvas").gameObject.GetComponent<Canvas>().enabled = false;
        GameObject.Find("Main Camera").gameObject.GetComponent<CinemachineBrain>().enabled = false;
        GameManager2.instance.player.GetComponent<FinalMovement>().changeCanMove(false);
    }
    public void languageChange()
    {
        //textfiles.Clear();
        if (GameManager2.instance.languageNum == 0)
        {
            textFile = jp;
        }
        if (GameManager2.instance.languageNum == 1)
        {
            textFile = en;
        }
        if (GameManager2.instance.languageNum == 2)
        {
            textFile = ch;
        }
    }
    void GetTextFromFile()
    {
        textList.Clear();
        var lineData = textFile.text.Split('\n');
        foreach (var line in lineData)
        {
            //Debug.Log(line);
            textList.Add(line);
        }
        //Debug.Log(textList.Count);
        textList.RemoveAt(textList.Count - 1);
        //textList.RemoveAt(textList.Count);
    }
    void GetTextFromFileHmong()
    {
        textListHmong.Clear();
        var lineData = hmong.text.Split('\n');
        foreach (var line in lineData)
        {
            //Debug.Log(line);
            textListHmong.Add(line);
        }
        //Debug.Log(textList.Count);
        textListHmong.RemoveAt(textListHmong.Count - 1);
        //textList.RemoveAt(textList.Count);
    }
    void fileChoose()
    {
        GetTextFromFile();
        GetTextFromFileHmong();
        //nowPlaying = i + 1;
        //focusCanvas.transform.GetChild(0).GetComponent<Image>().sprite = BGList[i];
        //focusCanvas.transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = titleList[i];
        if (GameManager2.instance.languageNum == 0)
        {
            //focusCanvas.transform.GetChild(1).GetChild(1).GetComponent<Text>().text = nameListJ[i];
            focusCanvas.transform.GetChild(1).GetChild(1).GetComponent<Text>().font = fontJE;
        }
        if (GameManager2.instance.languageNum == 1)
        {
            //focusCanvas.transform.GetChild(1).GetChild(1).GetComponent<Text>().text = nameListE[i];
            focusCanvas.transform.GetChild(1).GetChild(1).GetComponent<Text>().font = fontJE;
        }
        if (GameManager2.instance.languageNum == 2)
        {
            //focusCanvas.transform.GetChild(1).GetChild(1).GetComponent<Text>().text = nameListCN[i];
            focusCanvas.transform.GetChild(1).GetChild(1).GetComponent<Text>().font = fontCN;
        }
        index = 0;
        text1.GetComponent<Text>().text = textListHmong[index];
        text2.GetComponent<Text>().text = textList[index];
    }
    public void next()
    {
        //Debug.Log("1");
        //NPCDialogBox.transform.GetChild(1).gameObject.GetComponent<Button>().onClick.Invoke();
        //index++;
        index++;
        Debug.Log(index);
        if (index <= textList.Count - 1)
        {
            text1.GetComponent<Text>().text = textListHmong[index];
            text2.GetComponent<Text>().text = textList[index];
        }
        StartCoroutine(nextHide());
    }
    IEnumerator nextHide()
    {
        //panel.transform.GetChild(2).gameObject.SetActive(false);
        panel.transform.GetChild(3).gameObject.SetActive(false);
        panel.transform.GetChild(3).gameObject.GetComponent<buttonMinor>().enabled = false;
        //NPCDialogBox.transform.GetChild(1).gameObject.SetActive(false);
        yield return new WaitForSeconds(2.5f);
        //panel.transform.GetChild(2).gameObject.SetActive(true);
        panel.transform.GetChild(3).gameObject.SetActive(true);
        panel.transform.GetChild(3).gameObject.GetComponent<buttonMinor>().enabled = true;
        panel.transform.GetChild(3).gameObject.GetComponent<Button>().enabled = true;
        //NPCDialogBox.transform.GetChild(1).gameObject.SetActive(true);
    }
}

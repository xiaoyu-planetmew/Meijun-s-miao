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
    private List<System.Action> mUnRegisterEventActions = new List<System.Action>();
    public List<GameObject> anims = new List<GameObject>();
    public GameObject mask;
    public GameObject camFocus;
    public Transform focusLocation;
    public GameObject focusCanvas;
    public GameObject canvas1;
    public GameObject npc;
    public GameObject jiangYang;
    public GameObject shenniao;
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
    public GameObject credit;
    int index;
    //[SerializeField] int nowPlaying;
    // Start is called before the first frame update
    void Start()
    {
        //lu();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlaySpineAddEvent(SkeletonAnimation anim, string name, bool isLoop = false, System.Action action = null)
    {
        anim.AnimationState.SetAnimation(0, name, isLoop);
        TrackEntryDelegate ac = delegate
        {
            action();
        };
        anim.AnimationState.Complete += ac;
 
        mUnRegisterEventActions.Add(() =>
        {
            anim.AnimationState.Complete -= ac;
        });
    }
    public void UnRegisterAll()
    {
        mUnRegisterEventActions.ForEach(action => action());
        mUnRegisterEventActions.Clear();
    }
    public void finalStart()
    {
        camFocus.GetComponent<CamaraFocusFollow>().exitBridge();
        camFocus.GetComponent<CamaraFocusFollow>().enabled = false;
        mask.gameObject.SetActive(true);
        mask.GetComponent<SpriteRenderer>().enabled = true;
        mask.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        mask.GetComponent<SpriteRenderer>().DOFade(0.99f, 2).OnComplete(() =>
        {
            cam.transform.localPosition = focusLocation.transform.localPosition;
            
            GameManager2.instance.player.transform.localPosition= new Vector3(-47.53f, -0.24f, 0f);
            GameManager2.instance.player.transform.Find("ChracterNew").localScale = new Vector3(1, 1, 1);
            npc.transform.position = new Vector3(-40.64f, -0.9f, 0);
            jiangYang.gameObject.SetActive(true);
            jiangYang.transform.localPosition = new Vector3(-39.31f, -0.67f, 0);
            jiangYang.transform.Find("New SkeletonAnimation").transform.localScale = new Vector3(-1, 1, 1);
            jiangYang.transform.Find("JiangYangCanvas").Find("startButton").gameObject.SetActive(false);
            shenniao.transform.localPosition = new Vector3(-6.4f, -2.1f, 0);
            shenniao.SetActive(true);
            shenniao.GetComponent<SkeletonAnimation>().state.SetAnimation(0, "idle", true);
            //Debug.Log("2");
            //girlAnim.SetActive(true);
            mask.SetActive(false);
            DialogSys2.Instance.dialogStart(45);
            //fileChoose();
            cam.GetComponent<Camera>().fieldOfView = 90f;
            
            //girlAnim.SetActive(true);
        });
        /*DG.Tweening.Sequence quence = DOTween.Sequence();
        quence.Append(mask.GetComponent<SpriteRenderer>().DOFade(0.99f, 2).OnComplete(() =>
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
        }));*/
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
    public void fileChoose()
    {
        focusCanvas.SetActive(true);
        canvas1.SetActive(true);
        languageChange();
        GetTextFromFile();
        GetTextFromFileHmong();
        jiangYang.transform.Find("New SkeletonAnimation").GetComponent<SkeletonAnimation>().state.SetAnimation(0, "laugh_loop", true);
        npc.transform.Find("Spine GameObject (wushi)").GetComponent<SkeletonAnimation>().state.SetAnimation(0, "wdance", true);
        //GameManager2.instance.player.transform.Find("ChracterNew").GetComponent<SkeletonAnimation>().state.SetAnimation(0, "summon", true);
        GameManager2.instance.player.GetComponent<chracterAnimEvents>().playLoopAnim(5);
        //nowPlaying = i + 1;
        //focusCanvas.transform.GetChild(0).GetComponent<Image>().sprite = BGList[i];
        //focusCanvas.transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = titleList[i];
        if (GameManager2.instance.languageNum == 0)
        {
            //focusCanvas.transform.GetChild(1).GetChild(1).GetComponent<Text>().text = nameListJ[i];
            panel.transform.GetChild(1).GetComponent<Text>().font = fontJE;
        }
        if (GameManager2.instance.languageNum == 1)
        {
            //focusCanvas.transform.GetChild(1).GetChild(1).GetComponent<Text>().text = nameListE[i];
            panel.transform.GetChild(1).GetComponent<Text>().font = fontJE;
        }
        if (GameManager2.instance.languageNum == 2)
        {
            //focusCanvas.transform.GetChild(1).GetChild(1).GetComponent<Text>().text = nameListCN[i];
            panel.transform.GetChild(1).GetComponent<Text>().font = fontCN;
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
        if(index == 2)
        {
            anims[0].SetActive(true);
        }
        if(index == 3)
        {
            anims[1].SetActive(true);
        }
        if(index == 4)
        {
            anims[2].SetActive(true);
        }
        if(index == 5)
        {
            anims[3].SetActive(true);
            leigong();
        }
        if(index == 6)
        {
            anims[4].SetActive(true);
            longwang();
        }
        if (index > textList.Count - 1)
        {
            final();
        }
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
    void leigong()
    {
        //anims[3].GetComponent<SkeletonAnimation>().
        PlaySpineAddEvent(anims[3].GetComponent<SkeletonAnimation>(), "appear", false, (() => {
            anims[3].GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "happy", true);
            //jiangYang.transform.Find("JiangYangCanvas").GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 12.6f);
            UnRegisterAll();
        }));
    }
    void longwang()
    {
        //anims[3].GetComponent<SkeletonAnimation>().
        PlaySpineAddEvent(anims[4].GetComponent<SkeletonAnimation>(), "appear", false, (() => {
            anims[4].GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "speak_loop", true);
            //jiangYang.transform.Find("JiangYangCanvas").GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 12.6f);
            UnRegisterAll();
        }));
    }
    public void lu1()
    {
        //anims[0].gameObject.GetComponent<SkeletonAnimation>().AnimationState.GetCurrent(0).AnimationStart = anims[0].gameObject.GetComponent<SkeletonAnimation>().AnimationState.GetCurrent(0).AnimationEnd;
        //anims[0].gameObject.GetComponent<SkeletonAnimation>().timeScale = -1;
        //Timer.call()
        anims[0].transform.position = new Vector3(-33.68f, -0.65f, 0);
    }
    public void lu2()
    {
        //anims[0].gameObject.GetComponent<SkeletonAnimation>().AnimationState.GetCurrent(0).AnimationStart = anims[0].gameObject.GetComponent<SkeletonAnimation>().AnimationState.GetCurrent(0).AnimationEnd;
        //anims[0].gameObject.GetComponent<SkeletonAnimation>().timeScale = -1;
        //Timer.call()
        anims[1].transform.position = new Vector3(-33.68f, -0.65f, 0);
    }
    public void final()
    {
        credit.SetActive(true);
        mask.gameObject.SetActive(true);
        mask.GetComponent<SpriteRenderer>().enabled = true;
        mask.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        mask.GetComponent<SpriteRenderer>().DOFade(0.99f, 2);
        credit.transform.GetChild(0).gameObject.GetComponent<Image>().DOFade(1, 2).OnComplete(() => {
            StartCoroutine(finalDelay());
        });

    }
    IEnumerator finalDelay()
    {
        yield return new WaitForSeconds(5f);
        GameManager2.instance.destroyGameManager();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using Spine.Unity;
using DG.Tweening;

public class NpcMusicFocus : MonoBehaviour
{
    public Transform focusLocation;
    public GameObject focusCanvas;
    public GameObject npc;
    public GameObject NPCDialogBox;
    public GameObject cam;
    float NPCDialogBoxScale;
    public float speed;
    public GameObject panel;
    public GameObject text1;
    public GameObject text2;
    public List<TextAsset> textfilesJ = new List<TextAsset>();
    public List<TextAsset> textfilesE = new List<TextAsset>();
    public List<TextAsset> textfilesCN = new List<TextAsset>();
    public List<TextAsset> textfiles = new List<TextAsset>();
    public List<string> textList = new List<string>();
    public List<Sprite> BGList = new List<Sprite>();
    public List<Sprite> titleList = new List<Sprite>();
    public List<string> nameListJ = new List<string>();
    public List<string> nameListE = new List<string>();
    public List<string> nameListCN = new List<string>();
    public Font fontJE;
    public Font fontCN;
    int index;
    float loX;
    float loY;
    float loZ;
    [SerializeField] int nowPlaying;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        text2.GetComponent<Text>().text = GameObject.Find("Dialog").gameObject.GetComponent<DialogSys2>().output;
    }
    public void languageChange()
    {
        textfiles.Clear();
        if (GameManager2.instance.languageNum == 0)
        {
            for (int i = 0; i < textfilesJ.Count; i++)
            {
                textfiles.Add(textfilesJ[i]);
            }
        }
        if (GameManager2.instance.languageNum == 1)
        {
            for (int i = 0; i < textfilesE.Count; i++)
            {
                textfiles.Add(textfilesE[i]);
            }
        }
        if (GameManager2.instance.languageNum == 2)
        {
            for (int i = 0; i < textfilesE.Count; i++)
            {
                textfiles.Add(textfilesCN[i]);
            }
        }
    }
    void GetTextFromFile(TextAsset file)
    {
        textList.Clear();
        var lineData = file.text.Split('\n');
        foreach (var line in lineData)
        {
            //Debug.Log(line);
            textList.Add(line);
        }
        //Debug.Log(textList.Count);
        textList.RemoveAt(textList.Count - 1);
        //textList.RemoveAt(textList.Count);
    }
    void fileChoose(int i)
    {
        GetTextFromFile(textfiles[i]);
        nowPlaying = i + 1;
        focusCanvas.transform.GetChild(0).GetComponent<Image>().sprite = BGList[i];
        focusCanvas.transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = titleList[i];
        if (GameManager2.instance.languageNum == 0)
        {
            focusCanvas.transform.GetChild(1).GetChild(1).GetComponent<Text>().text = nameListJ[i];
            focusCanvas.transform.GetChild(1).GetChild(1).GetComponent<Text>().font = fontJE;
        }
        if (GameManager2.instance.languageNum == 1)
        {
            focusCanvas.transform.GetChild(1).GetChild(1).GetComponent<Text>().text = nameListE[i];
            focusCanvas.transform.GetChild(1).GetChild(1).GetComponent<Text>().font = fontJE;
        }
        if (GameManager2.instance.languageNum == 2)
        {
            focusCanvas.transform.GetChild(1).GetChild(1).GetComponent<Text>().text = nameListCN[i];
            focusCanvas.transform.GetChild(1).GetChild(1).GetComponent<Text>().font = fontCN;
        }
        index = 0;
        text1.GetComponent<Text>().text = textList[index];
    }
    public void focus(int i)
    {
        loX = cam.transform.position.x;
        loY = cam.transform.position.y;
        loZ = cam.transform.position.z;
        //homeLocation.transform.position = new Vector3(loX, loY, loZ);
        cam.GetComponent<CinemachineBrain>().enabled = false;

        focusCanvas.gameObject.SetActive(true);
        focusCanvas.transform.GetChild(0).gameObject.SetActive(true);
        GameManager2.instance.player.transform.Find("ChracterNew").GetComponent<Animator>().SetFloat("speedCtrl", 1);
        GameManager2.instance.player.transform.Find("ChracterNew").GetComponent<Animator>().SetTrigger("ani");
        GameObject.Find("InventoryCanvas").gameObject.GetComponent<Canvas>().enabled = false;
        fileChoose(i);
        NPCDialogBoxScale = NPCDialogBox.transform.localScale.x;
        NPCDialogBox.transform.localScale = new Vector3(0, 0, 0);
        NPCDialogBox.transform.GetChild(1).gameObject.GetComponent<Image>().enabled = false;
        NPCDialogBox.transform.GetChild(1).gameObject.SetActive(false);
        StartCoroutine(ani());
        StartCoroutine(MoveToPosition());
    }
    public void cancelFocus()
    {

        panel.transform.GetChild(3).gameObject.GetComponent<buttonMinor>().enabled = false;
        panel.SetActive(false);
        npc.transform.GetChild(1).GetComponent<AudioSource>().Stop();
        npc.transform.GetChild(0).GetComponent<SkeletonAnimation>().state.SetAnimation(0, "widle", true);
        GameManager2.instance.player.transform.Find("ChracterNew").GetComponent<Animator>().SetFloat("speedCtrl", -1);
        GameManager2.instance.player.transform.Find("ChracterNew").GetComponent<Animator>().SetTrigger("ani");
        StartCoroutine(stopBack());
        StartCoroutine(colorChangeBack());
    }
    public void next()
    {
        //Debug.Log("1");
        NPCDialogBox.transform.GetChild(1).gameObject.GetComponent<Button>().onClick.Invoke();
        //index++;
        index = DialogSys2.Instance.index - 2;
        Debug.Log(index);
        if (index <= textList.Count - 1)
        {
            text1.GetComponent<Text>().text = textList[index];
        }
        StartCoroutine(nextHide());
    }
    IEnumerator MoveToPosition()
    {
        while (cam.gameObject.transform.position != focusLocation.position)
        {
            cam.gameObject.transform.position = Vector3.MoveTowards(cam.gameObject.transform.position, focusLocation.position, speed * Time.deltaTime);
            yield return 0;
        }
        StartCoroutine(colorChange());
    }
    IEnumerator MoveBackToPosition()
    {
        while (cam.gameObject.transform.position != new Vector3(loX, loY, loZ))
        {
            cam.gameObject.transform.position = Vector3.MoveTowards(cam.gameObject.transform.position, new Vector3(loX, loY, loZ), speed * Time.deltaTime);
            yield return 0;
        }
        //StartCoroutine(colorChangeBack());
    }
    IEnumerator colorChange()
    {
        while (focusCanvas.transform.GetChild(0).GetComponent<Image>().color.a < 1)
        {
            focusCanvas.transform.GetChild(0).GetComponent<Image>().color = new Color(focusCanvas.transform.GetChild(0).GetComponent<Image>().color.r, focusCanvas.transform.GetChild(0).GetComponent<Image>().color.g, focusCanvas.transform.GetChild(0).GetComponent<Image>().color.b, focusCanvas.transform.GetChild(0).GetComponent<Image>().color.a + 0.01f);
            focusCanvas.transform.GetChild(1).GetComponent<Image>().color = new Color(focusCanvas.transform.GetChild(1).GetComponent<Image>().color.r, focusCanvas.transform.GetChild(0).GetComponent<Image>().color.g, focusCanvas.transform.GetChild(1).GetComponent<Image>().color.b, focusCanvas.transform.GetChild(1).GetComponent<Image>().color.a + 0.01f);
            focusCanvas.transform.GetChild(1).GetChild(0).GetComponent<Image>().color = new Color(focusCanvas.transform.GetChild(1).GetChild(0).GetComponent<Image>().color.r, focusCanvas.transform.GetChild(1).GetChild(0).GetComponent<Image>().color.g, focusCanvas.transform.GetChild(1).GetChild(0).GetComponent<Image>().color.b, focusCanvas.transform.GetChild(1).GetChild(0).GetComponent<Image>().color.a + 0.01f);
            focusCanvas.transform.GetChild(1).GetChild(1).GetComponent<Text>().color = new Color(focusCanvas.transform.GetChild(1).GetChild(1).GetComponent<Text>().color.r, focusCanvas.transform.GetChild(1).GetChild(1).GetComponent<Text>().color.g, focusCanvas.transform.GetChild(1).GetChild(1).GetComponent<Text>().color.b, focusCanvas.transform.GetChild(1).GetChild(1).GetComponent<Text>().color.a + 0.01f);
            focusCanvas.transform.GetChild(1).GetChild(2).GetComponent<Image>().color = new Color(focusCanvas.transform.GetChild(1).GetChild(2).GetComponent<Image>().color.r, focusCanvas.transform.GetChild(1).GetChild(2).GetComponent<Image>().color.g, focusCanvas.transform.GetChild(1).GetChild(2).GetComponent<Image>().color.b, focusCanvas.transform.GetChild(1).GetChild(2).GetComponent<Image>().color.a + 0.005f);
            //Debug.Log(focusCanvas.transform.GetChild(0).GetComponent<Image>().color.a);
            //GameObject.Find("")
            yield return 0;
        }
    }
    IEnumerator colorChangeBack()
    {
        while (focusCanvas.transform.GetChild(0).GetComponent<Image>().color.a > 0)
        {
            focusCanvas.transform.GetChild(0).GetComponent<Image>().color = new Color(focusCanvas.transform.GetChild(0).GetComponent<Image>().color.r, focusCanvas.transform.GetChild(0).GetComponent<Image>().color.g, focusCanvas.transform.GetChild(0).GetComponent<Image>().color.b, focusCanvas.transform.GetChild(0).GetComponent<Image>().color.a - 0.01f);
            focusCanvas.transform.GetChild(1).GetComponent<Image>().color = new Color(focusCanvas.transform.GetChild(1).GetComponent<Image>().color.r, focusCanvas.transform.GetChild(0).GetComponent<Image>().color.g, focusCanvas.transform.GetChild(1).GetComponent<Image>().color.b, focusCanvas.transform.GetChild(1).GetComponent<Image>().color.a - 0.01f);
            focusCanvas.transform.GetChild(1).GetChild(0).GetComponent<Image>().color = new Color(focusCanvas.transform.GetChild(1).GetChild(0).GetComponent<Image>().color.r, focusCanvas.transform.GetChild(1).GetChild(0).GetComponent<Image>().color.g, focusCanvas.transform.GetChild(1).GetChild(0).GetComponent<Image>().color.b, focusCanvas.transform.GetChild(1).GetChild(0).GetComponent<Image>().color.a - 0.01f);
            focusCanvas.transform.GetChild(1).GetChild(1).GetComponent<Text>().color = new Color(focusCanvas.transform.GetChild(1).GetChild(1).GetComponent<Text>().color.r, focusCanvas.transform.GetChild(1).GetChild(1).GetComponent<Text>().color.g, focusCanvas.transform.GetChild(1).GetChild(1).GetComponent<Text>().color.b, focusCanvas.transform.GetChild(1).GetChild(1).GetComponent<Text>().color.a - 0.01f);
            focusCanvas.transform.GetChild(1).GetChild(2).GetComponent<Image>().color = new Color(focusCanvas.transform.GetChild(1).GetChild(2).GetComponent<Image>().color.r, focusCanvas.transform.GetChild(1).GetChild(2).GetComponent<Image>().color.g, focusCanvas.transform.GetChild(1).GetChild(2).GetComponent<Image>().color.b, focusCanvas.transform.GetChild(1).GetChild(2).GetComponent<Image>().color.a - 0.005f);
            //Debug.Log(focusCanvas.transform.GetChild(0).GetComponent<Image>().color.a);
            //GameObject.Find("")
            yield return 0;
        }
        StartCoroutine(MoveBackToPosition());
    }
    IEnumerator stopBack()
    {
        yield return new WaitUntil(() => cam.gameObject.transform.position == new Vector3(loX, loY, loZ));
        cam.GetComponent<CinemachineBrain>().enabled = true;
        focusCanvas.transform.GetChild(0).GetComponent<Image>().color = new Color(focusCanvas.transform.GetChild(0).GetComponent<Image>().color.r, focusCanvas.transform.GetChild(0).GetComponent<Image>().color.g, focusCanvas.transform.GetChild(0).GetComponent<Image>().color.b, 0);
        focusCanvas.transform.GetChild(1).GetComponent<Image>().color = new Color(focusCanvas.transform.GetChild(1).GetComponent<Image>().color.r, focusCanvas.transform.GetChild(0).GetComponent<Image>().color.g, focusCanvas.transform.GetChild(1).GetComponent<Image>().color.b, 0);
        focusCanvas.transform.GetChild(1).GetChild(0).GetComponent<Image>().color = new Color(focusCanvas.transform.GetChild(1).GetChild(0).GetComponent<Image>().color.r, focusCanvas.transform.GetChild(1).GetChild(0).GetComponent<Image>().color.g, focusCanvas.transform.GetChild(1).GetChild(0).GetComponent<Image>().color.b, 0);
        focusCanvas.transform.GetChild(1).GetChild(1).GetComponent<Text>().color = new Color(focusCanvas.transform.GetChild(1).GetChild(1).GetComponent<Text>().color.r, focusCanvas.transform.GetChild(1).GetChild(1).GetComponent<Text>().color.g, focusCanvas.transform.GetChild(1).GetChild(1).GetComponent<Text>().color.b, 0);
        focusCanvas.transform.GetChild(0).gameObject.SetActive(false);
        
        GameObject.Find("InventoryCanvas").gameObject.GetComponent<Canvas>().enabled = true;

        panel.SetActive(false);
        NPCDialogBox.transform.localScale = new Vector3(NPCDialogBoxScale, NPCDialogBoxScale, NPCDialogBoxScale);
        index = 0;
        NPCDialogBox.transform.GetChild(1).gameObject.SetActive(true);
        DialogSys2.Instance.dialogNext();
        /*
        if (nowPlaying == 1)
        {
            GameManager.instance.events[9] = true;
        }
        if (nowPlaying == 2)
        {
            GameManager.instance.events[11] = true;
        }
        if (nowPlaying == 3)
        {
            GameManager.instance.events[15] = true;
        }
        if (nowPlaying == 4)
        {
            GameManager.instance.events[19] = true;
        }
        if (nowPlaying == 5)
        {
            GameManager.instance.events[23] = true;
        }
        */
    }
    IEnumerator ani()
    {
        yield return new WaitUntil(() => focusCanvas.transform.GetChild(0).GetComponent<Image>().color.a >= 1);
        //Debug.Log("1");
        panel.SetActive(true);
        npc.transform.GetChild(1).GetComponent<AudioSource>().Play();
        npc.transform.GetChild(0).GetComponent<SkeletonAnimation>().state.SetAnimation(0, "wdance", true);
        NPCDialogBox.transform.GetChild(1).gameObject.GetComponent<Button>().onClick.Invoke();
        NPCDialogBox.transform.GetChild(1).gameObject.GetComponent<Image>().enabled = true;
        StartCoroutine(nextHide());
    }
    IEnumerator nextHide()
    {
        panel.transform.GetChild(2).gameObject.SetActive(false);
        panel.transform.GetChild(3).gameObject.SetActive(false);
        panel.transform.GetChild(3).gameObject.GetComponent<buttonMinor>().enabled = false;
        NPCDialogBox.transform.GetChild(1).gameObject.SetActive(false);
        yield return new WaitForSeconds(2.5f);
        panel.transform.GetChild(2).gameObject.SetActive(true);
        panel.transform.GetChild(3).gameObject.SetActive(true);
        panel.transform.GetChild(3).gameObject.GetComponent<buttonMinor>().enabled = true;
        panel.transform.GetChild(3).gameObject.GetComponent<Button>().enabled = true;
        NPCDialogBox.transform.GetChild(1).gameObject.SetActive(true);
    }
}

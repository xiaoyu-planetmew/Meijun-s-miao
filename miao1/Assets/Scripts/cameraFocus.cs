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
    int index;
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
        if(GameManager.instance.events[0] && GameManager.instance.events[1] && GameManager.instance.events[6] && GameManager.instance.events[8])
        {
            GetTextFromFile(textfiles[0]);
        }
        index = 0;
        text1.GetComponent<Text>().text = textList[index];
    }
    public void focus()
    {
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
        
    }
    public void cancelFocus()
    {
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
    }
    public void next()
    {
        //Debug.Log("1");
        NPCDialogBox.transform.GetChild(2).gameObject.GetComponent<Button>().onClick.Invoke();
        index++;
        text1.GetComponent<Text>().text = textList[index];
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
    IEnumerator ani()
    {
        yield return new WaitUntil(() => focusCanvas.transform.GetChild(0).GetComponent<Image>().color.a >= 1);  
        //Debug.Log("1");
        panel.SetActive(true);
        npc.transform.GetChild(1).GetComponent<AudioSource>().Play();
        npc.transform.GetChild(0).GetComponent<SkeletonAnimation>().state.SetAnimation(0, "wdance", true);
        NPCDialogBox.transform.GetChild(2).gameObject.GetComponent<Button>().onClick.Invoke();
        NPCDialogBox.transform.GetChild(2).gameObject.GetComponent<Image>().enabled = true;
    }
    IEnumerator nextHide()
    {
        panel.transform.GetChild(2).gameObject.SetActive(false);
        panel.transform.GetChild(3).gameObject.SetActive(false);
        yield return new WaitForSeconds(2f);
        panel.transform.GetChild(2).gameObject.SetActive(true);
        panel.transform.GetChild(3).gameObject.SetActive(true);
    }
}
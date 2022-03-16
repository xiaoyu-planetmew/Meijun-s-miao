using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using Spine.Unity;
public class darkMask : MonoBehaviour
{
    Camera cam;
    GameObject _image;
    public GameObject girl;
    public GameObject npc;
    public GameObject dialogBox1;
    public Item s1;
    public Item s2;
    public Item s3;
    public bool b1 = false;
    public bool b2 = false;
    public bool b3 = false;

    public GameObject seed1;
    public GameObject seed2;
    public GameObject seed3;
    public string wrongTipJ;
    public string wrongTipE;
    public Item thisSeed;
    public Item get;
    public GameObject thisobj;
    public GameObject wrongTipBox;
    public GameObject camPosition;
    public TextAsset textFile;
    public TextAsset textFile1;
    public TextAsset textFile1E;
    public List<string> textList = new List<string>();
    public List<string> textList1 = new List<string>();
    public GameObject panel;
    bool c = false;
    [SerializeField] int index = 0;
    public GameObject dialog2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(b1&&b2&&b3&&!c)
        {
            c = true;
            StopAllCoroutines();
            StartCoroutine(seedDisappear());
            //if(GameObject.Find("InventoryCanvas").activeInHierarchy)
            //{
            //    GameObject.Find("GameManager").GetComponent<sceneCheck>().enabled = false;
            //    GameObject.Find("InventoryCanvas").SetActive(false);
            //}
        }
    }
    public void darkStart()
    {
        _image = this.transform.GetChild(0).gameObject;
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        this.transform.GetChild(0).gameObject.SetActive(true);
        cam.gameObject.GetComponent<CinemachineBrain>().enabled = false;
        GameManager.instance.player.GetComponent<AudioListener>().enabled = false;
        GameManager.instance.player.SetActive(false);
        GameObject.Find("water2").GetComponent<AudioListener>().enabled = true;
        girl.SetActive(true);
        npc.SetActive(true);
        StartCoroutine(dark1());
    }
    IEnumerator dark1()
    {
        while(_image.GetComponent<Image>().color.a < 1)
        {
            _image.GetComponent<Image>().color = new Color(_image.GetComponent<Image>().color.r, _image.GetComponent<Image>().color.g, _image.GetComponent<Image>().color.b, _image.GetComponent<Image>().color.a+0.01f);
            yield return 0;
        }
        StartCoroutine(dark2());
    }
    IEnumerator dark2()
    {
        cam.transform.position = new Vector3(-26.4f, -0.3f, -8.14f);
        yield return new WaitForSeconds(1f);
        StartCoroutine(dark3());
    }
    IEnumerator dark3()
    {
        while(_image.GetComponent<Image>().color.a > 0)
        {
            _image.GetComponent<Image>().color = new Color(_image.GetComponent<Image>().color.r, _image.GetComponent<Image>().color.g, _image.GetComponent<Image>().color.b, _image.GetComponent<Image>().color.a-0.01f);
            yield return 0;
        }
        _image.SetActive(false);
        nextAct();
    }
    void nextAct()
    {
        dialogBox1.SetActive(true);
    }
    public void seed(GameObject obj)
    {
        thisobj = obj;
        
        if(obj == seed1 || obj == seed2)
        {
            seed1.GetComponent<Button>().enabled = false;
            seed2.GetComponent<Button>().enabled = false;
            seed3.GetComponent<Button>().enabled = false;
            if(GameManager.instance.languageNum == 0)
            {
                inventoryResponse.instance.becomeUseful(s1, this.gameObject, wrongTipJ);
                inventoryResponse.instance.becomeUseful(s2, this.gameObject, wrongTipJ);
            }
            if(GameManager.instance.languageNum == 1)
            {
                inventoryResponse.instance.becomeUseful(s1, this.gameObject, wrongTipE);
                inventoryResponse.instance.becomeUseful(s2, this.gameObject, wrongTipE);
            }
            inventoryResponse.instance.activeInventoryTip();
            inventoryResponse.instance.slots.GetComponent<slotsState>().turnOnInventory();
        }
        if(obj == seed3)
        {
            seed1.GetComponent<Button>().enabled = false;
            seed2.GetComponent<Button>().enabled = false;
            seed3.GetComponent<Button>().enabled = false;
            if(GameManager.instance.languageNum == 0)
            {
                inventoryResponse.instance.becomeUseful(s3, this.gameObject, wrongTipJ);
            }
            if(GameManager.instance.languageNum == 1)
            {
                inventoryResponse.instance.becomeUseful(s3, this.gameObject, wrongTipE);
            }
            inventoryResponse.instance.activeInventoryTip();
            inventoryResponse.instance.slots.GetComponent<slotsState>().turnOnInventory();
        }
    }
    public void wrong()
    {
        wrongTipBox.SetActive(true);
        StopAllCoroutines();
        StartCoroutine(closeTip());
        if(thisobj == seed1 || thisobj == seed2)
        {
            seed3.GetComponent<Button>().enabled = true;
            seed2.GetComponent<Button>().enabled = true;
            seed1.GetComponent<Button>().enabled = true;
        }
        if(thisobj == seed3)
        {
            seed3.GetComponent<Button>().enabled = true;
            seed2.GetComponent<Button>().enabled = true;
            seed1.GetComponent<Button>().enabled = true;
        }
    }
    public void getMessage()
    {
        if(get != s1 && get != s2 && get != s3)
        {
            wrong();
        }else
        {

        
        if(thisobj == seed1)
        {
            b1 = true;
            seed1.GetComponent<Button>().enabled = false;
            seed1.GetComponent<Image>().enabled = false;
            seed1.GetComponent<Animator>().enabled = false;
            
        }
        if(thisobj == seed2)
        {
            b2 = true;
            seed2.GetComponent<Button>().enabled = false;
        seed2.GetComponent<Image>().enabled = false;
        seed2.GetComponent<Animator>().enabled = false;
        }
        if(thisobj == seed3)
        {
            b3 = true;
            seed3.GetComponent<Button>().enabled = false;
        seed3.GetComponent<Image>().enabled = false;
        seed3.GetComponent<Animator>().enabled = false;
        }
        inventoryResponse.instance.becomeUseless(s1);
        inventoryResponse.instance.becomeUseless(s2);
        inventoryResponse.instance.becomeUseless(s3);
        thisobj.transform.GetChild(0).GetComponent<Image>().sprite = get.itemSprite;
        GameManager.instance.RemoveItem(get);
        thisobj.transform.GetChild(0).gameObject.SetActive(true);
        thisobj.GetComponent<Button>().enabled = false;
        thisobj.GetComponent<Image>().enabled = false;
        thisobj.GetComponent<Animator>().enabled = false;
        if(!seed1.transform.GetChild(0).gameObject.activeInHierarchy)
        {
            seed1.GetComponent<Button>().enabled = true;
        }
        if(!seed2.transform.GetChild(0).gameObject.activeInHierarchy)
        {
            seed2.GetComponent<Button>().enabled = true;
        }
        if(!seed3.transform.GetChild(0).gameObject.activeInHierarchy)
        {
            seed3.GetComponent<Button>().enabled = true;
        }
        }
    }
    IEnumerator closeTip()
    {
        yield return new WaitForSeconds(2f);
        wrongTipBox.SetActive(false);
    }
    
    IEnumerator seedDisappear()
    {
        wrongTipBox.SetActive(false);
        while(seed1.transform.GetChild(0).transform.localScale.x > 0)
        {
            seed1.transform.GetChild(0).transform.localScale = new Vector3(seed1.transform.GetChild(0).transform.localScale.x-0.01f, seed1.transform.GetChild(0).transform.localScale.y-0.01f, seed1.transform.GetChild(0).transform.localScale.z-0.01f);
            seed2.transform.GetChild(0).transform.localScale = new Vector3(seed2.transform.GetChild(0).transform.localScale.x-0.01f, seed2.transform.GetChild(0).transform.localScale.y-0.01f, seed2.transform.GetChild(0).transform.localScale.z-0.01f);
            seed3.transform.GetChild(0).transform.localScale = new Vector3(seed3.transform.GetChild(0).transform.localScale.x-0.01f, seed3.transform.GetChild(0).transform.localScale.y-0.01f, seed3.transform.GetChild(0).transform.localScale.z-0.01f);
            seed1.SetActive(false);
            seed2.SetActive(false);
            seed3.SetActive(false);
            yield return 0;
        }
        dialog2.SetActive(true);
        dialog2.transform.GetChild(0).gameObject.GetComponent<dialogLetters>().playStart();
        if(GameObject.Find("InventoryCanvas").activeInHierarchy)
        {
            GameObject.Find("GameManager").GetComponent<sceneCheck>().enabled = false;
            GameObject.Find("InventoryCanvas").SetActive(false);
        }
        //finish();
    }
    public void finish()
    {
        StopAllCoroutines();
        StartCoroutine(camMove());
        girl.GetComponent<SkeletonAnimation>().state.SetAnimation(0, "jump", true);
        npc.GetComponent<SkeletonAnimation>().state.SetAnimation(0, "wdance", true);
        this.transform.parent.gameObject.GetComponent<bambooAni>().getStart();
        GameObject.Find("water2").GetComponent<AudioSource>().enabled = true;
        GetTextFromFile(textFile);
        if(GameManager.instance.languageNum == 0)
        {
            GetTextFromFile1(textFile1);
        }
        if(GameManager.instance.languageNum == 1)
        {
            GetTextFromFile1(textFile1E);
        }
        panel.SetActive(true);
        
        
    }
    IEnumerator camMove()
    {
        while(cam.transform.position != camPosition.transform.position)
        {
            cam.transform.position = Vector3.MoveTowards(cam.transform.position, camPosition.transform.position, 4 * Time.deltaTime);
            yield return 0;
        }
    }
    void GetTextFromFile(TextAsset file)
    {
        textList.Clear();
        var lineData = file.text.Split('\n');        
        foreach(var line in lineData)
        {
            
            textList.Add(line);
        }
        
        textList.RemoveAt(textList.Count - 1);
        
    }
    void GetTextFromFile1(TextAsset file)
    {
        textList1.Clear();
        var lineData = file.text.Split('\n');        
        foreach(var line in lineData)
        {
            
            textList1.Add(line);
        }
        
        textList1.RemoveAt(textList.Count - 1);
        
    }
    public void next()
    {
        index++;
        if(index < textList.Count)
        {
            panel.transform.GetChild(1).GetComponent<Text>().text = textList[index];
            panel.transform.GetChild(2).GetComponent<Text>().text = textList1[index];
        }else
        if(index == textList.Count)
        {
            _image.SetActive(true);
            StartCoroutine(dark4());
        }
        

        //StartCoroutine(nextHide());
    }
    IEnumerator dark4()
    {
        panel.SetActive(false);
        while(_image.GetComponent<Image>().color.a < 1)
        {
            _image.GetComponent<Image>().color = new Color(_image.GetComponent<Image>().color.r, _image.GetComponent<Image>().color.g, _image.GetComponent<Image>().color.b, _image.GetComponent<Image>().color.a+0.01f);
            yield return 0;
        }
        StartCoroutine(endGame());
    }
    IEnumerator endGame()
    {
        yield return new WaitForSeconds(3f);
        GameManager.instance.destroyGameManager();
    }
}

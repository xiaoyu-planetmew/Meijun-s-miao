using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using DG.Tweening;
public class DialogSys2 : MonoBehaviour
{
    public static DialogSys2 Instance;
    [Header("eventNum")]
    public int eventNum;
    public GameObject player;
    public GameObject npc;
    //public GameObject cam;
    public GameObject textLabel;
    public GameObject textBackground;
    //public GameObject startButton;
    public GameObject nextPageButton;
    public GameObject transButton;
    public List<TextAsset> textfilesCN = new List<TextAsset>();
    public List<TextAsset> textfilesEN = new List<TextAsset>();
    public List<TextAsset> textfilesJP = new List<TextAsset>();
    //public GameObject sceneTransButton;
    public List<TextAsset> textfiles = new List<TextAsset>();
    public List<TextAsset> momentFind = new List<TextAsset>();
    public List<TextAsset> momentNotFind = new List<TextAsset>();
    public List<TextAsset> momentFailed = new List<TextAsset>();
    public List<UnityEvent> afterDialogEvents = new List<UnityEvent>();
    //public UnityEvent  

    //public List<TextAsset> textfilesE = new List<TextAsset>();
    //public List<TextAsset> textfilesJ = new List<TextAsset>();
    //public bool firstMeet;
    public bool isTalking = false;
    //private bool holdTarget;
    public int index;
    public List<string> textList = new List<string>();
    public List<string> textTalker = new List<string>();
    public List<string> speakers = new List<string>();
    public List<GameObject> textBackgrounds = new List<GameObject>();
    public List<GameObject> textLabels = new List<GameObject>();
    public float textSpeed;
    public List<AudioClip> leftAudio = new List<AudioClip>();
    public List<AudioClip> rightAudio = new List<AudioClip>();
    bool textFinished;
    public string output;
    public bool canContinue = true;
    int textNum;
    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            if (Instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        textfiles.Clear();
        if (GameObject.Find("GameManager")&&GameObject.Find("GameManager").GetComponent<GameManager>())
        {
            for (int i = 0; i < textfilesCN.Count; i++)
            {
                if (GameManager.instance.languageNum == 0) textfiles.Add(textfilesCN[i]);
                if (GameManager.instance.languageNum == 1) textfiles.Add(textfilesEN[i]);
                if (GameManager.instance.languageNum == 2) textfiles.Add(textfilesJP[i]);
            }
        }
        else
        {
            for (int i = 0; i < textfilesJP.Count; i++)
            {
                textfiles.Add(textfilesJP[i]);
            }
        }
        //firstMeet = true;        
    }
    // Update is called once per frame
    void Update()
    {
        if (isTalking && textFinished)
        {
            if (Input.anyKeyDown)
            {
                //DialogSys2.Instance.dialogNext();
                //SoundController.Instance.Button_Off.HandleEvent(gameObject);
            }

        }
        /*
        if((Mathf.Abs(npc.transform.position.x - player.transform.position.x) <= 5) && !isTalking)
        {
            startButton.SetActive(true);
        }
        if((Mathf.Abs(npc.transform.position.x - player.transform.position.x) > 5))
        {
            startButton.SetActive(false);
        }
        */
    }
    public void dialogStart(int Num)
    {
        if (!isTalking)
        {
            index = 0;
            GetTextFromFile(textfiles[Num]);
            eventNum = Num;
            fileChoose();
            Debug.Log("start" + Num);
        }
    }
    public void dialogStartMoment(bool moment)
    {
        if (!isTalking)
        {
            if(moment)
            {
                index = 0;
                if (GameObject.Find("GameManager") && GameObject.Find("GameManager").GetComponent<GameManager>())
                {
                    GetTextFromFile(momentFind[GameManager.instance.languageNum]);
                }
                else
                {
                    GetTextFromFile(momentFind[2]);
                }
                //GetTextFromFile(momentFind[Num]);
                eventNum = -1;
                fileChoose();
                
                
                Debug.Log("startFind");
            }
            if (!moment)
            {
                index = 0;
                if (GameObject.Find("GameManager") && GameObject.Find("GameManager").GetComponent<GameManager>())
                {
                    GetTextFromFile(momentNotFind[GameManager.instance.languageNum]);
                }
                else
                {
                    GetTextFromFile(momentNotFind[2]);
                }
                //GetTextFromFile(momentFind[Num]);
                eventNum = -2;
                fileChoose();
                Debug.Log("startNotFind");
            }
        }
    }
    public void dialogMomentFailed()
    {
        index = 0;
        if (GameObject.Find("GameManager") && GameObject.Find("GameManager").GetComponent<GameManager>())
        {
            GetTextFromFile(momentFailed[GameManager.instance.languageNum]);
        }
        else
        {
            GetTextFromFile(momentFailed[2]);
        }
                //GetTextFromFile(momentFind[Num]);
        eventNum = -1;
        fileChoose();
        Debug.Log("MomentFailed");
    }
    public void dialogNext()
    {
        if (textFinished && canContinue)
        {
            if (index >= textList.Count)
            {
                index = 0;
                //SoundController.Instance.Talk_Radio_Stop.HandleEvent(gameObject);
                textBackground.gameObject.SetActive(false);
                //nextPageButton.gameObject.SetActive(false);

                //textLabelcn.gameObject.SetActive(false);
                //textLabelen.gameObject.SetActive(false);
                isTalking = false;
                //player.GetComponent<FinalMovement>().canMove = true;
                if(eventNum >= 0)
                {
                    afterDialogEvents[eventNum].Invoke();
                    MouseSet.Instance.mouseChange("mouseTexture");
                }
                if(eventNum < 0)
                {
                    player.GetComponent<FinalMovement>().continueMoving();
                    GameObject.Find("Npc").transform.Find("JiangSongCanvas").GetComponent<NearShow>().enabled = true;
                    if(eventNum == -1)
                    {
                        transButton.SetActive(true);
                        npc.transform.Find("JiangSongCanvas").GetComponent<NearShow>().enabled = false;
                        npc.transform.Find("JiangSongCanvas").Find("startButton").gameObject.SetActive(false);
                    }
                }
                Debug.Log("dialog" + eventNum);
                return;
                //TutorialTrackController.Instance.FinishTutorial();
            }
            if (index < textList.Count && isTalking)
            {
                //SoundController.Instance.Talk_Buzz.HandleEvent(gameObject);
                //StartCoroutine(SetText());
                showText(textTalker[index]);
                //textBackground.gameObject.SetActive(true);
            }
        }
    }
    public void dialogFinish()
    {
        textList.Clear();
        textTalker.Clear();
        textFinished = true;
        isTalking = false;
        index = 0;
        //SoundController.Instance.Talk_Radio_Stop.HandleEvent(gameObject);
        textBackground.gameObject.SetActive(false);
        //nextPageButton.gameObject.SetActive(false);

        //textLabelcn.gameObject.SetActive(false);
        //textLabelen.gameObject.SetActive(false);
        isTalking = false;
        Debug.Log("finish");
        //afterDialogEvents[eventNum].Invoke();
    }
    void GetTextFromFile(TextAsset file)
    {
        textList.Clear();
        textTalker.Clear();
        var lineData = file.text.Split('#');
        foreach (var line in lineData)
        {
            //Debug.Log(line);
            textList.Add(line);
        }
        //Debug.Log(textList.Count);
        textList.RemoveAt(textList.Count - 1);
        //textList.RemoveAt(textList.Count);
        
        for(int j = 0; j < textList.Count; j++)
        {
            string s = textList[j].Substring(0, 2);
            textList[j] = textList[j].Substring(2);
            textTalker.Add(s);
            /*
            if (textList[j][0] == '1')
            {
                textList[j] = textList[j].Substring(1);
                textTalker.Add("left");
            }
            if(textList[j][0] == '2')
            {
                textList[j] = textList[j].Substring(1);
                textTalker.Add("right");
            }
            */
        }
        
    }
    /*
    public void languageChange()
    {
        textfiles.Clear();
        if(GameManager.instance.languageNum == 0)
        {
            for(int i=0; i<textfilesJ.Count; i++)
            {
                textfiles.Add(textfilesJ[i]);
            }
        }
        if(GameManager.instance.languageNum == 1)
        {
            for(int i=0; i<textfilesE.Count; i++)
            {
                textfiles.Add(textfilesE[i]);
            }
        }
    }
    */
    public void fileChoose()
    {

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

        //startButton.gameObject.SetActive(false);
        //nextPageButton.gameObject.SetActive(true);
        //textLabelcn.gameObject.SetActive(true);
        //textLabelen.gameObject.SetActive(true);
        index = 0;
        isTalking = true;
        player.GetComponent<FinalMovement>().canMove = false;
        showText(textTalker[0]);
        
        //SoundController.Instance.Talk_Radio_Play.HandleEvent(gameObject);
        //textLabelleft.GetComponent<Text>().text = textList[index];
        //nextPageButton.SetActive(false);
        //StartCoroutine(SetText());
        //leftAudioRandom();
        
        //Time.timeScale = 0.0f;
        //GameManager.instance.isPaused = true;

        //textLabelcn.GetComponent<TMP_Text>().text = textList[index];
        //textLabelen.GetComponent<TMP_Text>().text = textList[index + 1];

        //startButton.SetActive(false);
    }
    void showText(string s)
    {
        textLabel.SetActive(false);
        textBackground.gameObject.SetActive(false);
        Debug.Log(s);
        if (s == "唱跳")
        {
            if (eventNum == 12)
            {
                GameObject.Find("Npc").GetComponent<NpcMusicFocus>().focus(0);
            }
            if (eventNum == 14)
            {
                GameObject.Find("Npc").GetComponent<NpcMusicFocus>().focus(1);
            }
            if(eventNum == 24)
            {
                GameObject.Find("Npc").GetComponent<NpcMusicFocus>().focus(2);
            }
            if(eventNum == 27)
            {
                GameObject.Find("Npc").GetComponent<NpcMusicFocus>().focus(3);
            }
            if(eventNum == 31)
            {
                GameObject.Find("Npc").GetComponent<NpcMusicFocus>().focus(4);
            }
        }
        else if (s == "唱完")
        {
            GameObject.Find("Npc").GetComponent<NpcMusicFocus>().cancelFocus();
            //dialogNext();
        }
        for (int i=0;i<speakers.Count;i++)
        {
            if(s == speakers[i])
            {
                textLabel = textLabels[i];
                textBackground = textBackgrounds[i];
                Debug.Log(speakers[i]);
            }
        }
        textLabel.SetActive(true);
        textBackground.gameObject.SetActive(true);
        textFinished = false;
        textLabel.GetComponent<Text>().text = "";
        output = textList[index];
        textLabel.GetComponent<Text>().DOText(textList[index], textList[index].Length * 0.1f).SetEase(Ease.Linear).OnComplete(() => {
            index = index + 1;
            textFinished = true;
        });
    }
    void leftAudioRandom()
    {
        this.GetComponent<AudioSource>().enabled = false;
        this.GetComponent<AudioSource>().enabled = true;

        StopCoroutine("audioChangeLeft");
        StopCoroutine("audioChangeRight");
        StartCoroutine(audioStop());

        //Debug.Log(i);
        if (!this.GetComponent<AudioSource>().isPlaying && this.GetComponent<AudioSource>().enabled == true)
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
        if (!this.GetComponent<AudioSource>().isPlaying && this.GetComponent<AudioSource>().enabled == true)
        {
            StartCoroutine(audioChangeRight());
        }
    }

    IEnumerator SetText()
    {

        textFinished = false;
        textLabel.GetComponent<Text>().text = "";
        for (int i = 0; i < textList[index].Length; i++)
        {
            //Debug.Log(i);
            textLabel.GetComponent<Text>().text += textList[index][i];
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
        while (this.GetComponent<AudioSource>().enabled == true && textTalker[index] == "left")
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
        while (this.GetComponent<AudioSource>().enabled == true && textTalker[index] == "right")
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

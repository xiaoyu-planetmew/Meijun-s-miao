using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.EventSystems;
using SonicBloom.Koreo;
using SonicBloom.Koreo.Players;
using UnityEngine.SceneManagement;
public class BRhythmManager : MonoBehaviour
{
    public AudioSource theMusic;
    public float musicMuteTime;
    //public VideoPlayer vPlayer;
    public GameObject aniPlayer;
    public bool startPlaying;
    /*
    public BeatScroller theBSq;
    public BeatScroller theBSa;
    public BeatScroller theBSz;
    public BeatScroller theBSo;
    public BeatScroller theBSk;
    public BeatScroller theBSm;
    */
    public static BRhythmManager instance;
    public int combo = 0;
    public int maxCombo;
    public int perfectNum;
    public int goodNum;
    public int missNum;
    public bool fullCombo;
    public bool newBest;
    public int currentScore = 0;
    public float currentHitEffect = 0;
    public int currentNoteCount = 0;
    public float accurary;
    public int scorePerNote = 1;
    public Text comboText;
    public Text scoreText;
    public Text accuraryText;
    public Text effect;
    public GameObject hitEffect;
    public GameObject blueBorderAni;
    public GameObject artLetterAni;
    public float delayTime;
    public List<GameObject> targets = new List<GameObject>();
    //[Tooltip("����Ŀ�����ɵĹ�����¼���ӦID")]
    //[EventID]
    //public string eventID;
    //public NoteObject noteObject;
    //Koreography playingKoreo;
    //public Koreography kgy;
    //public List<BeatScroller> noteLanes = new List<BeatScroller>();
    //SimpleMusicPlayer simpleMusicPlayer;
    //public Transform simpleMusicPlayerTrans;

    //public static BNotesPool BNotesPoolInstance;      //子弹池单例
    public GameObject bulletObj;                        //子弹perfabs
    public int pooledAmount = 6;                        //子弹池初始大小
    public bool lockPoolSize = false;                   //是否锁定子弹池大小

    public List<GameObject> pooledObjects;             //子弹池链表
    public GameObject notes;
    
    public int longPooledAmount = 6;                        //子弹池初始大小
    
    public List<GameObject> longPooledObjects;             //子弹池链表
    public GameObject longNotes;
    public float lastNote;
    public List<float> trackNum = new List<float>();
    public List<bool> trackNumUsed = new List<bool>();
    public float songTime;
    private int currentIndex = 0; 
    private int longCurrentIndex = 0;
    public GameObject main;
    public GameObject trackTips;
    //public List<GameObject> targets = new List<GameObject>();
    public GameObject comboAni;
    public GameObject endUI;
    public GameObject mainChooseCanvas;
    public List<GameObject> chooseCanvas = new List<GameObject>();
    public GameObject fullComboAni;
    private bool comboReset;
        bool comboReset25;
        bool comboReset50;
        bool comboReset100;
        bool comboReset150;
        bool comboReset200;
    // Start is called before the first frame update
    private void OnEnable() 
    {
        mainStart();    
    }
    void Start()
    {
        setPool();
        
        
    }
    public void resetPool()
    {
        pooledObjects.Clear();
        longPooledObjects.Clear();
        for(int i = 0; i<notes.transform.childCount; i++)
        {
            Destroy(notes.transform.GetChild(i).gameObject);
        }
        for(int i = 0; i<longNotes.transform.childCount; i++)
        {
            Destroy(longNotes.transform.GetChild(i).gameObject);
        }
    }
    public void setPool()
    {
        resetPool();
        lastNote = -1;
        instance = this;
        comboText.text = "0";
        scoreText.text = "0";
        accuraryText.text = "0%";
        pooledObjects = new List<GameObject>();         //初始化链表
        for (int i = 0; i < pooledAmount; ++i)
        {
            GameObject obj = Instantiate(bulletObj);    //创建子弹对象
            obj.transform.parent = notes.transform;
            obj.tag = "note";
            obj.transform.GetChild(0).GetComponent<TrailRenderer>().enabled = false;
            obj.SetActive(false);                       //设置子弹无效
            pooledObjects.Add(obj);                     //把子弹添加到链表（对象池）中
        }
        for (int i = 0; i < longPooledAmount; ++i)
        {
            GameObject longobj = Instantiate(bulletObj);    //创建子弹对象
            longobj.transform.parent = longNotes.transform;
            longobj.tag = "longNote";
            longobj.transform.GetChild(0).GetComponent<TrailRenderer>().enabled = true;
            longobj.SetActive(false);                       //设置子弹无效
            longPooledObjects.Add(longobj);                     //把子弹添加到链表（对象池）中
        }
    }
    IEnumerator numImport()
    {
        yield return new WaitForSeconds(0.1f);
        foreach(var i in this.gameObject.GetComponent<BNoteGenerate>().trackNum)
        {
            trackNum.Add(i);
            trackNumUsed.Add(false);
        }
        trackNum.Add(-1);
        trackNumUsed.Add(true);
        trackNumUsed[0] = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(startPlaying)
        {
            comboAniControl();
        }
    }
    public void gameStart()
    {
        if(!startPlaying)
        {
            if(true)
            {
                main.SetActive(true);
                startPlaying = true;
                /*
                hitEffect.gameObject.GetComponent<resetSequenceAni>().resetAni();
                foreach(var i in targets)
                {
                    i.transform.GetChild(2).GetComponent<resetSequenceAni>().resetAni();
                    i.transform.GetChild(3).GetComponent<resetSequenceAni>().resetAni();
                    //Debug.Log("reset");
                }
                */
                this.GetComponent<BNoteGenerate>().enabled = true;
                this.GetComponent<BNoteGenerate>().GenerateStart();
                //vPlayer.Play();
                delayTime = this.gameObject.GetComponent<BNoteGenerate>().delayTimeList[this.gameObject.GetComponent<BChapterChoose>().chapter];
                songTime = this.gameObject.GetComponent<BNoteGenerate>().songTimeList[this.gameObject.GetComponent<BChapterChoose>().chapter];
                aniPlayer.SetActive(true);
                fullCombo = true;
                StartCoroutine(audioPlay());
                StartCoroutine(numImport());
                StartCoroutine(endScene());
                this.GetComponent<besizerPause>().showTip();
            }
        }
    }
    public void mainStart()
    {
        if(GameObject.Find("GameManager"))
        {
            mainChooseCanvas.SetActive(false);
            if(GameManager.instance.events[0] && !GameManager.instance.events[1])
            {
                this.gameObject.GetComponent<BChapterChoose>().chapter = 0;
                chooseCanvas[0].SetActive(true);
                chooseCanvas[0].transform.Find("nowChapter").GetChild(0).GetChild(2).GetComponent<Text>().text = GameManager.instance.songRecord[0].ToString("0.00%");
            }else
            if(GameManager.instance.events[5] && !GameManager.instance.events[10])
            {
                this.gameObject.GetComponent<BChapterChoose>().chapter = 1;
                chooseCanvas[1].SetActive(true);
                chooseCanvas[1].transform.Find("nowChapter").GetChild(0).GetChild(2).GetComponent<Text>().text = GameManager.instance.songRecord[1].ToString("0.00%");
            }else
            if(GameManager.instance.events[12] && !GameManager.instance.events[14])
            {
                this.gameObject.GetComponent<BChapterChoose>().chapter = 2;
                chooseCanvas[2].SetActive(true);
                chooseCanvas[2].transform.Find("nowChapter").GetChild(0).GetChild(2).GetComponent<Text>().text = GameManager.instance.songRecord[2].ToString("0.00%");
            }else
            if(GameManager.instance.events[16] && !GameManager.instance.events[18])
            {
                this.gameObject.GetComponent<BChapterChoose>().chapter = 3;
                chooseCanvas[3].SetActive(true);
                chooseCanvas[3].transform.Find("nowChapter").GetChild(0).GetChild(2).GetComponent<Text>().text = GameManager.instance.songRecord[3].ToString("0.00%");
            }else
            if(GameManager.instance.events[20] && !GameManager.instance.events[22])
            {
                this.gameObject.GetComponent<BChapterChoose>().chapter = 4;
                chooseCanvas[4].SetActive(true);
                chooseCanvas[4].transform.Find("nowChapter").GetChild(0).GetChild(2).GetComponent<Text>().text = GameManager.instance.songRecord[4].ToString("0.00%");
            }
        }else if (GameObject.Find("GameManager2"))
        {
            mainChooseCanvas.SetActive(false);
            if (GameManager2.instance.eventCtrl.GetComponent<EventControl>().events[2] && !GameManager2.instance.eventCtrl.GetComponent<EventControl>().events[4])
            {
                Debug.Log("c0");
                this.gameObject.GetComponent<BChapterChoose>().chapter = 0;
                chooseCanvas[0].SetActive(true);
                chooseCanvas[0].transform.Find("nowChapter").GetChild(0).GetChild(2).GetComponent<Text>().text = GameManager2.instance.songRecord[0].ToString("0.00%");
            }
            if (GameManager2.instance.eventCtrl.GetComponent<EventControl>().events[7] && !GameManager2.instance.eventCtrl.GetComponent<EventControl>().events[9])
            {
                Debug.Log("c1");
                this.gameObject.GetComponent<BChapterChoose>().chapter = 1;
                chooseCanvas[1].SetActive(true);
                chooseCanvas[1].transform.Find("nowChapter").GetChild(0).GetChild(2).GetComponent<Text>().text = GameManager2.instance.songRecord[1].ToString("0.00%");
            }
            if (GameManager2.instance.eventCtrl.GetComponent<EventControl>().events[13] && !GameManager2.instance.eventCtrl.GetComponent<EventControl>().events[15])
            {
                Debug.Log("c2");
                this.gameObject.GetComponent<BChapterChoose>().chapter = 2;
                chooseCanvas[2].SetActive(true);
                chooseCanvas[2].transform.Find("nowChapter").GetChild(0).GetChild(2).GetComponent<Text>().text = GameManager2.instance.songRecord[2].ToString("0.00%");
            }
            if (GameManager2.instance.eventCtrl.GetComponent<EventControl>().events[18] && !GameManager2.instance.eventCtrl.GetComponent<EventControl>().events[20])
            {
                Debug.Log("c3");
                this.gameObject.GetComponent<BChapterChoose>().chapter = 3;
                chooseCanvas[3].SetActive(true);
                chooseCanvas[3].transform.Find("nowChapter").GetChild(0).GetChild(3).GetComponent<Text>().text = GameManager2.instance.songRecord[3].ToString("0.00%");
            }
        }
        else
        {
            mainChooseCanvas.SetActive(true);
            for(int i = 0; i < chooseCanvas.Count; i++)
            {
                chooseCanvas[i].SetActive(false);
            }
        }
    }
    public void backToMenu()
    {
        StopAllCoroutines();
    }
    IEnumerator audioPlay()
    {
        trackTips.SetActive(true);
        yield return new WaitForSeconds(delayTime);
        trackTips.SetActive(false);
        this.GetComponent<BNoteGenerate>().aniList[this.gameObject.GetComponent<BChapterChoose>().chapter * 2].SetActive(true);
        this.GetComponent<BNoteGenerate>().aniList[this.gameObject.GetComponent<BChapterChoose>().chapter * 2 + 1].SetActive(true);
        theMusic.Play();
        Debug.Log("start");
    }
    public void NoteHitGood(int last)
    {
        var hitGood = "good";
        hitEffect.GetComponent<Animator>().SetTrigger(hitGood);
        //Debug.Log("On Time");
        combo += scorePerNote;
        if(combo >= maxCombo)
        {
            maxCombo = combo;
        }
        goodNum++;
        currentScore += scorePerNote;
        currentNoteCount++;
        currentHitEffect = currentHitEffect + 0.5f;
        comboText.text = combo.ToString();
        scoreText.text = currentScore.ToString();
        accurary = (float)currentHitEffect / currentNoteCount;
        //accuraryText.text = accurary.ToString() + "%";
        accuraryText.text = ((float)currentHitEffect / currentNoteCount).ToString("0.00%");
        trackNumUsed[last] = true;
        blueBorderAni.GetComponent<Animator>().SetTrigger("hit");
        artLetterAni.GetComponent<Animator>().SetTrigger("hit");
    }
    public void NoteHitExact(int last)
    {
        //Debug.Log("On Time");
        var hitExact = "exact";
        hitEffect.GetComponent<Animator>().SetTrigger(hitExact);
        combo += scorePerNote;
        if(combo >= maxCombo)
        {
            maxCombo = combo;
        }
        perfectNum++;
        currentScore += scorePerNote;
        currentNoteCount++;
        currentHitEffect = currentHitEffect + 1f;
        comboText.text = combo.ToString();
        scoreText.text = currentScore.ToString();
        accurary = (float)currentHitEffect / currentNoteCount;
        //accuraryText.text = accurary.ToString() + "%";
        accuraryText.text = ((float)currentHitEffect / currentNoteCount).ToString("0.00%");
        trackNumUsed[last] = true;
        blueBorderAni.GetComponent<Animator>().SetTrigger("hit");
        artLetterAni.GetComponent<Animator>().SetTrigger("hit");
    }
    public void NoteMissed(int last)
    {
        var hitMiss = "miss";
        hitEffect.GetComponent<Animator>().SetTrigger(hitMiss);
        //Debug.Log("Missed");
        combo = 0;
        fullCombo = false;
        missNum++;
        currentNoteCount++;
        comboText.text = combo.ToString();
        accurary = (float)currentHitEffect / currentNoteCount;
        accuraryText.text = ((float)currentHitEffect / currentNoteCount).ToString("0.00%");
        trackNumUsed[last] = true;
    }
    public GameObject GetPooledObject()                 //获取对象池中可以使用的子弹。
    {
        for (int i = 0; i < pooledObjects.Count; ++i)   //把对象池遍历一遍
        {
            //这里简单优化了一下，每一次遍历都是从上一次被使用的子弹的下一个，而不是每次遍历从0开始。
            //例如上一次获取了第4个子弹，currentIndex就为5，这里从索引5开始遍历，这是一种贪心算法。
            int temI = (currentIndex + i) % pooledObjects.Count;
            if (!pooledObjects[temI].activeInHierarchy) //判断该子弹是否在场景中激活。
            {
                currentIndex = (temI + 1) % pooledObjects.Count;
                return pooledObjects[temI];             //找到没有被激活的子弹并返回
            }
        }


        //如果遍历完一遍子弹库发现没有可以用的，执行下面
        if(!lockPoolSize)                               //如果没有锁定对象池大小，创建子弹并添加到对象池中。
        {
            GameObject obj = Instantiate(bulletObj);
            obj.transform.parent = notes.transform;
            obj.tag = "note";
            obj.transform.GetChild(0).GetComponent<TrailRenderer>().enabled = false;
            pooledObjects.Add(obj);
            return obj;
        }

        //如果遍历完没有而且锁定了对象池大小，返回空。
        return null;
    }
    public GameObject GetLongPooledObject()                 //获取对象池中可以使用的子弹。
    {
        for (int i = 0; i < longPooledObjects.Count; ++i)   //把对象池遍历一遍
        {
            //这里简单优化了一下，每一次遍历都是从上一次被使用的子弹的下一个，而不是每次遍历从0开始。
            //例如上一次获取了第4个子弹，currentIndex就为5，这里从索引5开始遍历，这是一种贪心算法。
            int temI = (longCurrentIndex + i) % longPooledObjects.Count;
            if (!longPooledObjects[temI].activeInHierarchy) //判断该子弹是否在场景中激活。
            {
                longCurrentIndex = (temI + 1) % longPooledObjects.Count;
                return longPooledObjects[temI];             //找到没有被激活的子弹并返回
            }
        }


        //如果遍历完一遍子弹库发现没有可以用的，执行下面
        if(!lockPoolSize)                               //如果没有锁定对象池大小，创建子弹并添加到对象池中。
        {
            GameObject obj = Instantiate(bulletObj);
            obj.transform.parent = longNotes.transform;
            obj.tag = "longNote";
            obj.transform.GetChild(0).GetComponent<TrailRenderer>().enabled = true;
            longPooledObjects.Add(obj);
            return obj;
        }

        //如果遍历完没有而且锁定了对象池大小，返回空。
        return null;
    }
    IEnumerator endScene()
    {
        Debug.Log(songTime+delayTime);
        yield return new WaitForSeconds(songTime + delayTime);
        if(accurary >= this.gameObject.GetComponent<BChapterChoose>().chapterRecord[this.gameObject.GetComponent<BChapterChoose>().chapter])
        {
            this.gameObject.GetComponent<BChapterChoose>().chapterRecord[this.gameObject.GetComponent<BChapterChoose>().chapter] = accurary;
            newBest = true;
        }
        StartCoroutine(endAni());
        //activeEnd();
        
    }
    public void testEndGame()
    {
        accurary = 0.6f;
        endGame();
    }
    public void endGame()
    {
        if(GameObject.Find("GameManager"))
        {
            if(this.gameObject.GetComponent<BChapterChoose>().chapter == 0)
            {
            if(accurary >= 0.5 && GameManager.instance.events[0])
            {
                GameManager.instance.events[1] = true;
                if(newBest)
                {
                    GameManager.instance.songRecord[0] = accurary;
                }
            }
            GameManager.instance.events[6] = true;
            }
            if(this.gameObject.GetComponent<BChapterChoose>().chapter == 1)
            {
            if(accurary >= 0.5 && GameManager.instance.events[5])
            {
                GameManager.instance.events[10] = true;                
                if(newBest)
                {
                    GameManager.instance.songRecord[1] = accurary;
                }
            }
            GameManager.instance.events[7] = true;
            }
            if(this.gameObject.GetComponent<BChapterChoose>().chapter == 2)
            {
            if(accurary >= 0.5 && GameManager.instance.events[12])
            {
                GameManager.instance.events[14] = true;
                if(newBest)
                {
                    GameManager.instance.songRecord[2] = accurary;
                }
            }
            GameManager.instance.events[13] = true;
            }
            if(this.gameObject.GetComponent<BChapterChoose>().chapter == 3)
            {
            if(accurary >= 0.5 && GameManager.instance.events[16])
            {
                GameManager.instance.events[18] = true;
                if(newBest)
                {
                    GameManager.instance.songRecord[3] = accurary;
                }
            }
            GameManager.instance.events[17] = true;
            }
            if(this.gameObject.GetComponent<BChapterChoose>().chapter == 4)
            {
            if(accurary >= 0.5 && GameManager.instance.events[20])
            {
                GameManager.instance.events[22] = true;
                if(newBest)
                {
                    GameManager.instance.songRecord[4] = accurary;
                }
            }
            GameManager.instance.events[21] = true;
            }
            GameObject.Find("GameManager").transform.Find("acrossScene").gameObject.SetActive(true);
            //GameManager.instance.gameObject.GetComponent<sceneCheck>().enabled = false;
            SceneManager.LoadScene("SampleScene");
            //StartCoroutine(loadDelay());
        }else if(GameObject.Find("GameManager2"))
        {
            if (this.gameObject.GetComponent<BChapterChoose>().chapter == 0)
            {
                if (accurary >= 0.5 && GameManager2.instance.eventCtrl.GetComponent<EventControl>().events[2])
                {
                    GameManager2.instance.eventCtrl.GetComponent<EventControl>().finishEvent(4);
                    if (newBest)
                    {
                        GameManager2.instance.songRecord[0] = accurary;
                    }
                }
                GameManager2.instance.eventCtrl.GetComponent<EventControl>().finishEvent(3);
            }
            if (this.gameObject.GetComponent<BChapterChoose>().chapter == 1)
            {
                if (accurary >= 0.5 && GameManager2.instance.eventCtrl.GetComponent<EventControl>().events[7])
                {
                    GameManager2.instance.eventCtrl.GetComponent<EventControl>().finishEvent(9);
                    if (newBest)
                    {
                        GameManager2.instance.songRecord[1] = accurary;
                    }
                }
                GameManager2.instance.eventCtrl.GetComponent<EventControl>().finishEvent(8);
            }
            if (this.gameObject.GetComponent<BChapterChoose>().chapter == 2)
            {
                if (accurary >= 0.5 && GameManager2.instance.eventCtrl.GetComponent<EventControl>().events[13])
                {
                    GameManager2.instance.eventCtrl.GetComponent<EventControl>().finishEvent(15);
                    if (newBest)
                    {
                        GameManager2.instance.songRecord[2] = accurary;
                    }
                }
                GameManager2.instance.eventCtrl.GetComponent<EventControl>().finishEvent(14);
            }
            if (this.gameObject.GetComponent<BChapterChoose>().chapter == 3)
            {
                if (accurary >= 0.5 && GameManager2.instance.eventCtrl.GetComponent<EventControl>().events[18])
                {
                    GameManager2.instance.eventCtrl.GetComponent<EventControl>().finishEvent(20);
                    if (newBest)
                    {
                        GameManager2.instance.songRecord[3] = accurary;
                    }
                }
                GameManager2.instance.eventCtrl.GetComponent<EventControl>().finishEvent(19);
            }
            GameObject.Find("GameManager2").transform.Find("acrossScene").gameObject.SetActive(true);
            //GameManager.instance.gameObject.GetComponent<sceneCheck>().enabled = false;
            SceneManager.LoadScene("Scene2");
            //StartCoroutine(loadDelay());
        }
        else
        {
            if(newBest)
            {
                this.GetComponent<BChapterChoose>().chapterRecord[this.GetComponent<BChapterChoose>().chapter] = accurary;
                mainChooseCanvas.transform.Find("nowChapter").GetChild(0).GetChild(2).GetComponent<Text>().text = accurary.ToString("0.00%");
            }
            this.gameObject.GetComponent<besizerSceneReset>().resetScene();
            /*
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
            */
        }
        endUI.SetActive(false);
    }
    IEnumerator loadDelay()
    {
        if (GameObject.Find("GameManager"))
        {
            GameManager.instance.gameObject.GetComponent<sceneCheck>().enabled = false;
        }
        else if (GameObject.Find("GameManager2"))
        {
            GameManager2.instance.gameObject.GetComponent<SceneCheck2>().enabled = false;
        }
        yield return new WaitForSeconds(0.1f);
        if (GameObject.Find("GameManager"))
        {
            GameManager.instance.gameObject.GetComponent<sceneCheck>().enabled = true;
        }
        else if (GameObject.Find("GameManager2"))
        {
            GameManager2.instance.gameObject.GetComponent<SceneCheck2>().enabled = true;
        }
        
    }
    public void comboAniControl()
    {
        //bool comboReset25;
        
        if(combo == 0)
        {
            comboReset = true;
            comboReset25 = true;
            comboReset50 = true;
            comboReset100 = true;
            comboReset150 = true;
            comboReset200 = true;
        }
        if(combo >= 25 && combo < 50 && comboReset25)
        {
            comboAni.GetComponent<Animator>().SetTrigger("25");
            comboReset25 = false;
        }
        if(combo >= 50 && combo < 100 && comboReset50)
        {
            comboAni.GetComponent<Animator>().SetTrigger("50");
            comboReset50 = false;
        }
        if(combo >= 100 && combo < 150 && comboReset100)
        {
            comboAni.GetComponent<Animator>().SetTrigger("100");
            comboReset100 = false;
        }
        if(combo >= 150 && combo < 200 && comboReset150)
        {
            comboAni.GetComponent<Animator>().SetTrigger("150");
            comboReset150 = false;
        }
        if(combo >= 200 && comboReset200)
        {
            comboAni.GetComponent<Animator>().SetTrigger("200");
            comboReset200 = false;
        }
    }
    public void activeEnd()
    {
        endUI.SetActive(true);
        endUI.GetComponent<BEndUI>().fullComboBool = fullCombo;
        endUI.GetComponent<BEndUI>().newBestBool = newBest;
        endUI.GetComponent<BEndUI>().accurary = accurary;
        endUI.GetComponent<BEndUI>().perfectNum = perfectNum;
        endUI.GetComponent<BEndUI>().goodNum = goodNum;
        endUI.GetComponent<BEndUI>().missNum = missNum;
        endUI.GetComponent<BEndUI>().combo = maxCombo;
        endUI.GetComponent<BEndUI>().titleNum = this.gameObject.GetComponent<BChapterChoose>().chapter;
        endUI.GetComponent<BEndUI>().BEnd();
    }
    IEnumerator endAni()
    {
        if(fullCombo)
        {
            fullComboAni.GetComponent<Animator>().SetTrigger("fullCombo");
        }
        yield return new WaitForSeconds(1.1f);
        activeEnd();
    }
}
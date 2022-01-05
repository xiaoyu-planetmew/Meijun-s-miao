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
    // Start is called before the first frame update
    void Start()
    {
        
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
        
    }
    public void gameStart()
    {
        if(!startPlaying)
        {
            if(true)
            {
                main.SetActive(true);
                startPlaying = true;
                this.GetComponent<BNoteGenerate>().enabled = true;
                //vPlayer.Play();
                delayTime = this.gameObject.GetComponent<BNoteGenerate>().delayTimeList[this.gameObject.GetComponent<BChapterChoose>().chapter];
                songTime = this.gameObject.GetComponent<BNoteGenerate>().songTimeList[this.gameObject.GetComponent<BChapterChoose>().chapter];
                aniPlayer.SetActive(true);
                StartCoroutine(audioPlay());
                StartCoroutine(numImport());
                StartCoroutine(endScene());
            }
        }
    }
    IEnumerator audioPlay()
    {
        yield return new WaitForSeconds(delayTime);
        theMusic.Play();
        Debug.Log("start");
    }
    public void NoteHitGood(int last)
    {
        var hitGood = "good";
        hitEffect.GetComponent<Animator>().SetTrigger(hitGood);
        //Debug.Log("On Time");
        combo += scorePerNote;
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
        }
        
        if(GameObject.Find("GameManager"))
        {
            if(accurary >= 0.5)
            {
                GameManager.instance.events[1] = true;
            }
            GameManager.instance.events[6] = true;
            //GameManager.instance.gameObject.GetComponent<sceneCheck>().enabled = false;
            SceneManager.LoadScene(0);
            //StartCoroutine(loadDelay());
        }else
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }
    }
    IEnumerator loadDelay()
    {
        GameManager.instance.gameObject.GetComponent<sceneCheck>().enabled = false;
        yield return new WaitForSeconds(0.1f);
        GameManager.instance.gameObject.GetComponent<sceneCheck>().enabled = true;
    }
}
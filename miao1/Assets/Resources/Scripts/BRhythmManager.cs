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
    public int currentNoteCount = 0;
    public float accurary;
    public int scorePerNote = 1;
    public Text comboText;
    public Text scoreText;
    public Text accuraryText;
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

    private int currentIndex = 0; 
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        comboText.text = "0";
        scoreText.text = "0";
        accuraryText.text = "0%";
        pooledObjects = new List<GameObject>();         //初始化链表
        for (int i = 0; i < pooledAmount; ++i)
        {
            GameObject obj = Instantiate(bulletObj);    //创建子弹对象
            obj.transform.parent = notes.transform;
            obj.SetActive(false);                       //设置子弹无效
            pooledObjects.Add(obj);                     //把子弹添加到链表（对象池）中
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!startPlaying)
        {
            if(true)
            {
                startPlaying = true;
                this.GetComponent<BNoteGenerate>().enabled = true;
                //vPlayer.Play();
                
                aniPlayer.SetActive(true);
                StartCoroutine(audioPlay());
                
            }
        }
    }
    IEnumerator audioPlay()
    {
        yield return new WaitForSeconds(delayTime);
        theMusic.Play();
        Debug.Log("start");
    }
    public void NoteHit()
    {
        //Debug.Log("On Time");
        combo += scorePerNote;
        currentScore += scorePerNote;
        currentNoteCount++;
        comboText.text = combo.ToString();
        scoreText.text = currentScore.ToString();
        accurary = (float)currentScore / currentNoteCount;
        //accuraryText.text = accurary.ToString() + "%";
        accuraryText.text = ((float)currentScore / currentNoteCount).ToString("0%");
    }
    public void NoteMissed()
    {
        //Debug.Log("Missed");
        combo = 0;
        currentNoteCount++;
        comboText.text = combo.ToString();
        accurary = (float)currentScore / currentNoteCount;
        accuraryText.text = ((float)currentScore / currentNoteCount).ToString("0%");
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
            pooledObjects.Add(obj);
            return obj;
        }

        //如果遍历完没有而且锁定了对象池大小，返回空。
        return null;
    }

}
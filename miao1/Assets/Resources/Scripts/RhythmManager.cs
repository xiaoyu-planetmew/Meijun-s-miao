using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.EventSystems;
using SonicBloom.Koreo;
using SonicBloom.Koreo.Players;
using UnityEngine.SceneManagement;
public class RhythmManager : MonoBehaviour
{
    public AudioSource theMusic;
    public VideoPlayer vPlayer;
    public bool startPlaying;
    public BeatScroller theBSq;
    public BeatScroller theBSa;
    public BeatScroller theBSz;
    public BeatScroller theBSo;
    public BeatScroller theBSk;
    public BeatScroller theBSm;
    public static RhythmManager instance;
    public int currentScore;
    public int scorePerNote = 1;
    public Text scoreText;
    [Tooltip("用于目标生成的轨道的事件对应ID")]
    [EventID]
    public string eventID;
    //public NoteObject noteObject;
    Koreography playingKoreo;
    public Koreography kgy;
    public List<BeatScroller> noteLanes = new List<BeatScroller>();
    SimpleMusicPlayer simpleMusicPlayer;
    public Transform simpleMusciPlayerTrans;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        scoreText.text = "Score: 0";
       
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!startPlaying)
        {
            if(Input.anyKeyDown)
            {
                startPlaying = true;
                theBSq.hasStarted = true;
                theBSa.hasStarted = true;
                theBSz.hasStarted = true;
                theBSo.hasStarted = true;
                theBSk.hasStarted = true;
                theBSm.hasStarted = true;
                vPlayer.Play();
                theMusic.Play();
            }
        }
    }
    public void NoteHit()
    {
        Debug.Log("On Time");
        currentScore += scorePerNote;
        scoreText.text = "Score: " + currentScore;
    }
    public void NoteMissed()
    {
        Debug.Log("Missed");
    }
}

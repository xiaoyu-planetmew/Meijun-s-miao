using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BNoteHit : MonoBehaviour
{
    public KeyCode keyToPress;
    public GameObject notes;
    public List<GameObject> notelist = new List<GameObject>();
    public List<GameObject> longNoteList = new List<GameObject>();
    public List<GameObject> shortNoteList = new List<GameObject>();
    public GameObject key;
    public GameObject clickDown;
    public GameObject num;
    public Material mat;
    private Animator ani;
    public GameObject mask;
    private float passedTime;
    private float startTime;
    public bool timerStart;
    public GameObject nowNote;
    private string animatorTriggerHit = "Hit";
    //private bool canHit;
    // Start is called before the first frame update
    void Start()
    {
        key = this.transform.GetChild(0).gameObject;
        clickDown = this.transform.GetChild(1).gameObject;
        ani = this.transform.GetChild(2).GetComponent<Animator>();
        nowNote = GameObject.Find("NullBNote");
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //shortNoteList.Clear();
        //longNoteList.Clear();
        shortNoteList = BRhythmManager.instance.pooledObjects;
        longNoteList = BRhythmManager.instance.longPooledObjects;
        notelist.Clear();
        for(int i = 0; i < shortNoteList.Count; i++)
        {
            notelist.Add(shortNoteList[i]);
        }
        for(int i = 0; i < longNoteList.Count; i++)
        {
            notelist.Add(longNoteList[i]);
        }
        
        noteOnTime();
        if(Input.GetKeyDown(keyToPress))
        {
            key.SetActive(false);
            clickDown.SetActive(true);
            ;
        }
        if (Input.GetKey(keyToPress))
        {
            key.SetActive(false);
            clickDown.SetActive(true);
            ;
        }
        if (Input.GetKeyUp(keyToPress))
        {
            key.SetActive(true);
            clickDown.SetActive(false);
            
        }
    }
    void noteOnTime()
    {
        var minDistance = ((this.transform.position - notelist[0].transform.position).magnitude);
        var minTrans = notelist[0];
        
        for (int i = 0; i < notelist.Count; i++)
        {
            if (((this.transform.position - notelist[i].transform.position).magnitude) < minDistance && notelist[i].GetComponent<BNoteCanBeCount>().canBeCount == true)
            {
                minDistance = ((this.transform.position - notelist[i].transform.position).magnitude);
                minTrans = notelist[i];
            }
        }
        /*
        if(true)
        {
            if(minDistance < 0.2f && minTrans.gameObject.GetComponent<BNoteCanBeCount>().canBeCount == true)
            {
                minTrans.gameObject.SetActive(false);
                minTrans.gameObject.GetComponent<DrawBesizerLine>().basePoint.Clear();
                minTrans.gameObject.GetComponent<DrawBesizerLine>().length = 0;
                minTrans.gameObject.GetComponent<DrawBesizerLine>().enabled = false;
                minTrans.gameObject.GetComponent<BNoteCanBeCount>().canBeCount = false;
                num.GetComponent<Text>().text = Time.time.ToString();
                Debug.Log(Time.time);
                BRhythmManager.instance.NoteHit();
            }
        }
        */
        if(Input.GetKeyDown(keyToPress) && minDistance < 2f && minTrans.gameObject.GetComponent<BNoteCanBeCount>().canBeCount == true && minTrans.tag == "longNote")
        {
            var startTime = Time.time;
            passedTime = 0f;

            
        }
        if(Input.GetKey(keyToPress))
        {
            mask.SetActive(true);
            Debug.Log(Time.time);
            if(minDistance < 2f && minTrans.gameObject.GetComponent<BNoteCanBeCount>().canBeCount == true && minTrans.tag == "note")
            {
                minTrans.gameObject.SetActive(false);
                minTrans.gameObject.GetComponent<DrawBesizerLine>().basePoint.Clear();
                minTrans.gameObject.GetComponent<DrawBesizerLine>().length = 0;
                minTrans.gameObject.GetComponent<DrawBesizerLine>().enabled = false;
                minTrans.gameObject.GetComponent<BNoteCanBeCount>().canBeCount = false;
                //minTrans.gameObject.GetComponent<TrailRenderer>().time = -1;
                num.GetComponent<Text>().text = minTrans.gameObject.GetComponent<DrawBesizerLine>().num.ToString();
                //Debug.Log(Time.time);
                if(minDistance < 1f)
                {
                    BRhythmManager.instance.NoteHitExact();
                }
                if(minDistance > 1f)
                {
                    BRhythmManager.instance.NoteHitGood();
                }
                
                ani.SetTrigger(animatorTriggerHit);
            }
            if(minDistance < 2f && minTrans.gameObject.GetComponent<BNoteCanBeCount>().canBeCount == true && minTrans.tag == "longNote")
            {
                minTrans.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = false;
                minTrans.gameObject.GetComponent<BNoteCanBeCount>().canBeCount = false;
                if(minDistance < 1f)
                {
                    BRhythmManager.instance.NoteHitExact();
                }
                if(minDistance > 1f)
                {
                    BRhythmManager.instance.NoteHitGood();
                }
                StartCoroutine(longNoteHit(minTrans, minTrans.transform.GetChild(0).GetComponent<TrailRenderer>().time));
                num.GetComponent<Text>().text = minTrans.gameObject.GetComponent<DrawBesizerLine>().num.ToString();
                //Debug.Log(Time.time);
                startTime = Time.time;
                passedTime = 0f;
                timerStart = true;
                nowNote = minTrans;
                ani.SetTrigger(animatorTriggerHit);
                var noteLength = minTrans.transform.GetChild(0).GetComponent<TrailRenderer>().time;
            }
            if(timerStart && !Input.GetKeyUp(keyToPress) && Time.time - startTime < nowNote.transform.GetChild(0).GetComponent<TrailRenderer>().time)
            {
                if(passedTime > 1f)
                {
                    BRhythmManager.instance.NoteHitExact();
                    passedTime = 0;
                }
                passedTime += Time.deltaTime;
            }
            
            
        }
        if(Input.GetKeyUp(keyToPress) && Time.time - startTime < nowNote.transform.GetChild(0).GetComponent<TrailRenderer>().time && nowNote.tag == "longNote")
        {
            BRhythmManager.instance.NoteMissed();
            
        }
        if(Input.GetKeyUp(keyToPress) || Time.time - startTime > nowNote.transform.GetChild(0).GetComponent<TrailRenderer>().time)
        {
            timerStart = false;
            nowNote.transform.GetChild(0).GetComponent<TrailRenderer>().material= mat;
            
            nowNote = GameObject.Find("NullBNote");
        }
        
        if(!Input.GetKey(keyToPress))
        {
            mask.SetActive(false);
        }
        
    }
    IEnumerator longNoteHit(GameObject obj, float noteLength)
    {
        yield return new WaitForSeconds(noteLength);
        obj.gameObject.SetActive(false);
        obj.gameObject.GetComponent<DrawBesizerLine>().basePoint.Clear();
        obj.gameObject.GetComponent<DrawBesizerLine>().length = 0;
        obj.gameObject.GetComponent<DrawBesizerLine>().enabled = false;
        //BRhythmManager.instance.NoteHit();
        obj.transform.GetChild(0).GetComponent<TrailRenderer>().time = -1;
    }
    
}
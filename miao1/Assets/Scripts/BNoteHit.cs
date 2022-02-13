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
    public int line;
    [SerializeReference] bool b1;
    [SerializeReference] bool b2;
    //private bool canHit;
    // Start is called before the first frame update
    void Start()
    {
        key = this.transform.GetChild(0).gameObject;
        clickDown = this.transform.GetChild(1).gameObject;
        ani = this.transform.GetChild(2).GetComponent<Animator>();
        nowNote = GameObject.Find("NullBNote");
        b1 = true;
        b2 = false;
    }
    // Update is called once per frame
    void Update()
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
        if((shortNoteList.Count > 0 || longNoteList.Count > 0) && BRhythmManager.instance.startPlaying)
        {
            noteOnTime();
        }
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
        var minDistance = ((this.transform.GetChild(0).position - notelist[0].transform.position).magnitude);
        var minTrans = notelist[0];
        
        for (int i = 0; i < notelist.Count; i++)
        {
            if (((this.transform.GetChild(0).position - notelist[i].transform.position).magnitude) < minDistance && notelist[i].GetComponent<BNoteCanBeCount>().canBeCount == true)
            {
                minDistance = ((this.transform.GetChild(0).position - notelist[i].transform.position).magnitude);
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
        if(Input.GetKeyDown(keyToPress) && minDistance < 2f && minTrans.gameObject.GetComponent<BNoteCanBeCount>().canBeCount == true && minTrans.tag == "longNote" && minTrans.gameObject.GetComponent<BNoteCanBeCount>().line == line)
        {
            var startTime = Time.time;
            passedTime = 0f;

            
        }
        if(Input.GetKey(keyToPress) && b1)
        {
            b2 = true;
        }else{
            b2 = false;
        }
        if(Input.GetKeyUp(keyToPress))
        {
            b1 = true;
        }
        if(b2)
        {
            mask.SetActive(true);
            Debug.Log(Time.time);
            if(minDistance < 3f && minTrans.gameObject.GetComponent<BNoteCanBeCount>().canBeCount == true && minTrans.tag == "note" && minTrans.gameObject.GetComponent<BNoteCanBeCount>().line == line && BRhythmManager.instance.trackNumUsed[minTrans.gameObject.GetComponent<DrawBesizerLine>().numInSequence - 1])
            {
                b1 = false;
                minTrans.gameObject.SetActive(false);
                minTrans.gameObject.GetComponent<DrawBesizerLine>().basePoint.Clear();
                minTrans.gameObject.GetComponent<DrawBesizerLine>().length = 0;
                minTrans.gameObject.GetComponent<DrawBesizerLine>().enabled = false;
                minTrans.gameObject.GetComponent<BNoteCanBeCount>().canBeCount = false;
                //minTrans.gameObject.GetComponent<TrailRenderer>().time = -1;
                num.GetComponent<Text>().text = minTrans.gameObject.GetComponent<DrawBesizerLine>().num.ToString();
                
                //Debug.Log(Time.time);
                if(minDistance <= 2f)
                {
                    BRhythmManager.instance.NoteHitExact(minTrans.gameObject.GetComponent<DrawBesizerLine>().numInSequence);
                }
                if(minDistance > 2f)
                {
                    BRhythmManager.instance.NoteHitGood(minTrans.gameObject.GetComponent<DrawBesizerLine>().numInSequence);
                }
                
                ani.SetTrigger(animatorTriggerHit);
            }
        }
        if(Input.GetKey(keyToPress))
        {
            if(minDistance < 3f && minTrans.gameObject.GetComponent<BNoteCanBeCount>().canBeCount == true && minTrans.tag == "longNote" && minTrans.gameObject.GetComponent<BNoteCanBeCount>().line == line)
            {
                minTrans.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = false;
                minTrans.gameObject.GetComponent<BNoteCanBeCount>().canBeCount = false;
                if(minDistance <= 2f)
                {
                    BRhythmManager.instance.NoteHitExact(minTrans.gameObject.GetComponent<DrawBesizerLine>().numInSequence);
                }
                if(minDistance > 2f)
                {
                    BRhythmManager.instance.NoteHitGood(minTrans.gameObject.GetComponent<DrawBesizerLine>().numInSequence);
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
            if(timerStart && !Input.GetKeyUp(keyToPress) 
            && Time.time - startTime < nowNote.transform.GetChild(0).GetComponent<TrailRenderer>().time)
            {
                if(passedTime > 0.25f)
                {
                    BRhythmManager.instance.NoteHitExact(minTrans.gameObject.GetComponent<DrawBesizerLine>().numInSequence);
                    ani.SetTrigger(animatorTriggerHit);
                    passedTime = 0;
                }
                passedTime += Time.deltaTime;
            }
            
            
        }
        if(Input.GetKeyUp(keyToPress) && Time.time - startTime < nowNote.transform.GetChild(0).GetComponent<TrailRenderer>().time && nowNote.tag == "longNote" && minTrans.gameObject.GetComponent<BNoteCanBeCount>().line == line)
        {
            BRhythmManager.instance.NoteMissed(minTrans.gameObject.GetComponent<DrawBesizerLine>().numInSequence);
            
        }
        if(Input.GetKeyUp(keyToPress) || Time.time - startTime > (nowNote.transform.GetChild(0).GetComponent<TrailRenderer>().time + 0.5f))
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
        yield return new WaitForSeconds(noteLength + 0.5f);
        obj.gameObject.SetActive(false);
        obj.gameObject.GetComponent<DrawBesizerLine>().basePoint.Clear();
        obj.gameObject.GetComponent<DrawBesizerLine>().length = 0;
        obj.gameObject.GetComponent<DrawBesizerLine>().enabled = false;
        //BRhythmManager.instance.NoteHit();
        obj.transform.GetChild(0).GetComponent<TrailRenderer>().time = -1;
    }
    
}
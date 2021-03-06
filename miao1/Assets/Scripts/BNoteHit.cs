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
    public GameObject hitAni;
    public GameObject mask;
    private float passedTime;
    private float startTime;
    public bool timerStart;
    public GameObject nowNote;
    private string animatorTriggerHit = "Hit";
    public int line;
    [SerializeField]bool noteFinish = true;
    [SerializeReference] bool b1;
    [SerializeReference] bool b2;
    public GameObject minTrans;
    [SerializeField]private float minDistance;
    //private bool canHit;
    // Start is called before the first frame update
    void Start()
    {
        key = this.transform.GetChild(0).gameObject;
        clickDown = this.transform.GetChild(1).gameObject;
        ani = this.transform.GetChild(2).GetComponent<Animator>();
        //hitAni = this.transform.GetChild(3).gameObject;
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
            GameObject.Find("pressSound").GetComponent<AudioSource>().Play();
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
        if(true)
        {
        minDistance = ((this.transform.GetChild(0).position - notelist[0].transform.position).magnitude);
        minTrans = notelist[0];
        
        for (int i = 0; i < notelist.Count; i++)
        {
            if (((this.transform.GetChild(0).position - notelist[i].transform.position).magnitude) < minDistance && notelist[i].GetComponent<BNoteCanBeCount>().canBeCount == true)
            {
                minDistance = ((this.transform.GetChild(0).position - notelist[i].transform.position).magnitude);
                minTrans = notelist[i];
            }
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
        if(Input.GetKeyDown(keyToPress) && minDistance < 3f && minTrans.gameObject.GetComponent<BNoteCanBeCount>().canBeCount == true && minTrans.tag == "longNote" && minTrans.gameObject.GetComponent<BNoteCanBeCount>().line == line)
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
            //Debug.Log(Time.time);
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
                var x = minTrans.transform.position.x;
                var y = minTrans.transform.position.y;
                //Debug.Log(Time.time);
                if(minDistance <= 2f)
                {
                    BRhythmManager.instance.NoteHitExact(minTrans.gameObject.GetComponent<DrawBesizerLine>().numInSequence);
                    GameObject.Find("RhythmManager").GetComponent<BBackgroundScale>().hitScale();
                }
                if(minDistance > 2f)
                {
                    BRhythmManager.instance.NoteHitGood(minTrans.gameObject.GetComponent<DrawBesizerLine>().numInSequence);
                    GameObject.Find("RhythmManager").GetComponent<BBackgroundScale>().hitScale();
                }
                
                hitAni.transform.position = new Vector3(x, y, 0);
                if(!hitAni.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("hit0"))
                {
                    hitAni.GetComponent<Animator>().Play("hit0", 0);
                }else
                if(!hitAni.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("hit1"))
                {
                    hitAni.GetComponent<Animator>().Play("hit1", 0);
                }
                ani.SetTrigger(animatorTriggerHit);
            }
        }
        if(Input.GetKey(keyToPress))
        {
            if(minDistance < 3f && minTrans.gameObject.GetComponent<BNoteCanBeCount>().canBeCount == true && minTrans.tag == "longNote" && minTrans.gameObject.GetComponent<BNoteCanBeCount>().line == line)
            {
                noteFinish = false;
                minTrans.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = false;
                minTrans.gameObject.GetComponent<BNoteCanBeCount>().canBeCount = false;
                var x = minTrans.transform.position.x;
                var y = minTrans.transform.position.y;
                var aniTrans = minTrans;
                if(minDistance <= 2f)
                {
                    BRhythmManager.instance.NoteHitExact(minTrans.gameObject.GetComponent<DrawBesizerLine>().numInSequence);
                    GameObject.Find("RhythmManager").GetComponent<BBackgroundScale>().holdScale();
                }
                if(minDistance > 2f)
                {
                    BRhythmManager.instance.NoteHitGood(minTrans.gameObject.GetComponent<DrawBesizerLine>().numInSequence);
                    GameObject.Find("RhythmManager").GetComponent<BBackgroundScale>().holdScale();
                }
                hitAni.transform.position = new Vector3(x, y, 0);
                hitAni.GetComponent<Animator>().SetBool("hold", true);
                minTrans.GetComponent<BNoteCanBeCount>().isAni = true;
                if(line == 5)
                {
                    Debug.Log(minTrans.transform.position);
                    Debug.Log(minTrans.transform.GetChild(0).GetComponent<TrailRenderer>().time);
                }
                var t = minTrans.transform.GetChild(0).GetComponent<TrailRenderer>().time;
                minTrans.GetComponent<BNoteCanBeCount>().longNoteHit();
                //hitAni.GetComponent<Animator>().Play("long", 0);
                StopAllCoroutines();
                StartCoroutine(longNoteHit(minTrans, t));
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
                    GameObject.Find("RhythmManager").GetComponent<BBackgroundScale>().holdScale();
                    ani.SetTrigger(animatorTriggerHit);
                    passedTime = 0;
                }
                passedTime += Time.deltaTime;
            }
            
        }
        if(nowNote != null)
        {
        if(Input.GetKeyUp(keyToPress) && Time.time - startTime < nowNote.transform.GetChild(0).GetComponent<TrailRenderer>().time && nowNote.tag == "longNote" && minTrans.gameObject.GetComponent<BNoteCanBeCount>().line == line)
        {
            BRhythmManager.instance.NoteMissed(minTrans.gameObject.GetComponent<DrawBesizerLine>().numInSequence);
            if(hitAni.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("long"))
            {
                minTrans.GetComponent<BNoteCanBeCount>().isAni = false;
                noteFinish = true;
                StopAllCoroutines();
            }
            
        }
        if(Input.GetKeyUp(keyToPress) || Time.time - startTime > (nowNote.transform.GetChild(0).GetComponent<TrailRenderer>().time + 0.5f))
        {
            timerStart = false;
            nowNote.transform.GetChild(0).GetComponent<TrailRenderer>().material= mat;
            nowNote = GameObject.Find("NullBNote");
        }
        }
        if(Input.GetKeyUp(keyToPress) && hitAni.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("long"))
        {
            Debug.Log("up");
            hitAni.GetComponent<Animator>().SetBool("hold", false);
                minTrans.GetComponent<BNoteCanBeCount>().isAni = false;
                noteFinish = true;
            StopAllCoroutines();
        }
        if(!Input.GetKey(keyToPress))
        {
            mask.SetActive(false);
        }
        
    }
    IEnumerator longNoteHit(GameObject minTrans, float noteLength)
    {
        yield return new WaitForSeconds(noteLength + 0.1f);
       /* if(hitAni.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("long") && minTrans.GetComponent<BNoteCanBeCount>().isAni && minTrans.activeInHierarchy && minTrans.GetComponent<BNoteCanBeCount>().line == line)
        {
            Debug.Log("time");
            hitAni.GetComponent<Animator>().SetTrigger("release");
            minTrans.GetComponent<BNoteCanBeCount>().isAni = false;
        }*/
        minTrans.gameObject.SetActive(false);
        minTrans.gameObject.GetComponent<DrawBesizerLine>().basePoint.Clear();
        minTrans.gameObject.GetComponent<DrawBesizerLine>().length = 0;
        minTrans.gameObject.GetComponent<DrawBesizerLine>().line = null;
        minTrans.gameObject.GetComponent<DrawBesizerLine>().enabled = false;
        //BRhythmManager.instance.NoteHit();
        minTrans.transform.GetChild(0).GetComponent<TrailRenderer>().time = -1;
        noteFinish = true;
    }
    public void buttonActive()
    {
        
    }
}
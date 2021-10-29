using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BNoteHit : MonoBehaviour
{
    public KeyCode keyToPress;
    public GameObject notes;
    public List<GameObject> notelist = new List<GameObject>();
    public GameObject key;
    public GameObject clickDown;
    public GameObject num;
    private Animator ani;
    public GameObject mask;
    
    private string animatorTriggerHit = "Hit";
    //private bool canHit;
    // Start is called before the first frame update
    void Start()
    {
        key = this.transform.GetChild(0).gameObject;
        clickDown = this.transform.GetChild(1).gameObject;
        ani = this.transform.GetChild(2).GetComponent<Animator>();
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        notelist = BRhythmManager.instance.pooledObjects;
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
            if (((this.transform.position - notelist[i].transform.position).magnitude) < minDistance)
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
        if(Input.GetKey(keyToPress))
        {
            mask.SetActive(true);
            if(minDistance < 2f && minTrans.gameObject.GetComponent<BNoteCanBeCount>().canBeCount == true)
            {
                minTrans.gameObject.SetActive(false);
                minTrans.gameObject.GetComponent<DrawBesizerLine>().basePoint.Clear();
                minTrans.gameObject.GetComponent<DrawBesizerLine>().length = 0;
                minTrans.gameObject.GetComponent<DrawBesizerLine>().enabled = false;
                minTrans.gameObject.GetComponent<BNoteCanBeCount>().canBeCount = false;
                minTrans.gameObject.GetComponent<TrailRenderer>().time = -1;
                num.GetComponent<Text>().text = minTrans.gameObject.GetComponent<DrawBesizerLine>().num.ToString();
                Debug.Log(Time.time);
                BRhythmManager.instance.NoteHit();
                ani.SetTrigger(animatorTriggerHit);
            }
        }
        else
        {
            mask.SetActive(false);
        }
    }
    
    /*
    void OnTriggerEnter2D(Collider2D other)
    {
        if(Input.GetKeyDown(keyToPress))
        {
            other.gameObject.SetActive(false);
            other.gameObject.GetComponent<DrawBesizerLine>().basePoint.Clear();
            other.gameObject.GetComponent<DrawBesizerLine>().length = 0;
            BRhythmManager.instance.NoteHit();
        }
    }
    */
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BNoteHit : MonoBehaviour
{
    public KeyCode keyToPress;
    public GameObject notes;
    public List<GameObject> notelist = new List<GameObject>();
    public GameObject key;
    public GameObject clickDown;
    // Start is called before the first frame update
    void Start()
    {
        key = this.transform.GetChild(0).gameObject;
        clickDown = this.transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
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
        if(Input.GetKeyDown(keyToPress))
        {
            if(minDistance < 1f && minTrans.gameObject.GetComponent<BNoteCanBeCount>().canBeCount == true)
            {
                minTrans.gameObject.SetActive(false);
                minTrans.gameObject.GetComponent<DrawBesizerLine>().basePoint.Clear();
                minTrans.gameObject.GetComponent<DrawBesizerLine>().length = 0;
                minTrans.gameObject.GetComponent<DrawBesizerLine>().enabled = false;
                minTrans.gameObject.GetComponent<BNoteCanBeCount>().canBeCount = false;
                BRhythmManager.instance.NoteHit();
            }
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

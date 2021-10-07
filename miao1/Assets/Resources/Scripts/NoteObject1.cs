using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject1 : MonoBehaviour
{
    public bool canBePressed = false;
    public KeyCode keyToPress;
    public bool isLong = false;
    private float noteLength;
    
    private float pressTime;
    private float startTime;
    private float destroyTime;
    private bool longNoteOnTime;
    public int line;

    private Transform noteHead;
    private Transform noteBody;
    private Transform noteTail;
    private Transform noteNeck;
    public float _angle;
    // Start is called before the first frame update
    void Start()
    {
        keyToPress = this.transform.parent.gameObject.GetComponent<BeatScroller>().keyToPress;
        _angle = this.transform.parent.gameObject.GetComponent<Transform>().eulerAngles.z * Mathf.Deg2Rad;
        if (isLong == true)
        {
            noteLength = this.GetComponent<longNote>().noteLong * 0.5f;
            if (line == 1)
            {

                noteHead = transform.Find("ZHold_3");
                noteBody = transform.Find("ZHold_1");
                noteTail = transform.Find("ZHold_0");
                
                noteNeck = transform.Find("ZHold_2");
            }
            else if (line == 2)
            {
                noteHead = transform.Find("XHold_0");
                noteBody = transform.Find("XHold_2");
                noteTail = transform.Find("XHold_3");
               
                noteNeck = transform.Find("XHold_1");
                
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isLong == false)
        {
            if (Input.GetKeyDown(keyToPress))
            {
                if (canBePressed)
                {
                    gameObject.SetActive(false);
                    RhythmManager.instance.NoteHit();
                }
            }
        }
        if(isLong == true)
        {
            //Debug.Log("startTime");
            //Debug.Log(startTime);
            //Debug.Log("pressTime");
            //Debug.Log(pressTime);
            //Debug.Log(longNoteOnTime );
            //Debug.Log("noteLength * 0.25f");
            //Debug.Log((noteLength * 0.25f + 0.25f - 0.43f));
            longNoteHit();
            if(canBePressed )
            {
                InvokeRepeating("longNoteDestroy", (noteLength * 0.25f + 1f), 1f);
            }

        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isLong == false)
        {
            if (other.tag == "ActivatorX" || other.tag == "ActivatorZ")
            {
                canBePressed = true;
            }
            if (other.tag == "Destroyer")
            {
                canBePressed = false;
                RhythmManager.instance.NoteMissed();
                Destroy(gameObject);
            }
        }
        if(isLong == true)
        {
            if(line == 1)
            {
                if (other.tag == "ActivatorZ")
                {
                    canBePressed = true;
                    startTime = Time.time;
                }
            }
            if(line == 2)
            {
                if (other.tag == "ActivatorX")
                {
                    canBePressed = true;
                    startTime = Time.time;
                }
            }
           
        

        }
    }
    private void onTriggerExit2D(Collider2D other)
    {
        if (isLong == false)
        {
            if (other.tag == "Activator")
            {
                canBePressed = false;
                RhythmManager.instance.NoteMissed();
                Destroy(gameObject);
            }
        }
        
    }
    private void longNoteHit()
    {
        if (Input.GetKey(keyToPress))
        {
            if (canBePressed)
            {
                
                longNoteOnTime = true;
                pressTime += Time.deltaTime;
                if (pressTime > (noteLength * 0.25f + 0.25f) && pressTime < ((noteLength * 0.25f) + 0.5f))
                {

                    gameObject.SetActive(false);
                    longNoteOnTime = true;
                    RhythmManager.instance.NoteHit();

                }
                else
                {
                    longNoteOnTime = false;
                }

            }
        }
    }
    private void longNoteDestroy()
    {
        Debug.Log("active1");
        if (longNoteOnTime == false)
        {
            canBePressed = false;
            RhythmManager.instance.NoteMissed();
            Destroy(gameObject);
            Debug.Log("active2");
        }
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class longNote : MonoBehaviour
{
    public GameObject note;
    private Transform noteHead;
    private Transform noteBody;
    private Transform noteTail;
    private Transform noteCore;
    public int noteLong;
    private float tailPosition;
    private float bodyScale;
    public int line;
    private float direction;
    public  List<GameObject> bodys;
    private int initBodysLength;
    public GameObject body;
    // Start is called before the first frame update
    void Start()
    {
        initBodysLength = noteLong - 2;
        bodys = new List<GameObject>();
        noteCore = note.GetComponent<Transform>();
        if (line == 1)
        {
            direction = -1f;
            noteHead = transform.Find("ZHold_3");
            noteBody = transform.Find("ZHold_1");
            noteTail = transform.Find("ZHold_0");
        }
        else if (line == 2)
        {
            direction = 1f;
            noteHead = transform.Find("XHold_0");
            noteBody = transform.Find("XHold_2");
            noteTail = transform.Find("XHold_3");
        }
        bodyScale = noteLong - 2f;
        

        for (int i = 1; i <= initBodysLength; i++)
        {
            if(line == 1)
            {
                GameObject newBody = Instantiate(body, transform.localPosition, Quaternion.identity);
                newBody.transform.parent = transform;
                newBody.transform.localPosition = new Vector3(((0.495f * direction) + (i - 1) * 0.25f * direction), 0, 0);
                newBody.transform.parent = transform;
                bodys.Add(newBody);
                //newBody.transform.SetParent(note, false);
            }
            if(line == 2)
            {
                GameObject newBody = Instantiate(body, transform.localPosition, Quaternion.identity);
                newBody.transform.parent = transform;
                newBody.transform.localPosition = new Vector3(((0.495f * direction) + (i - 1) * 0.25f * direction), 0, 0);
                newBody.transform.parent = transform;
                bodys.Add(newBody);
                //newBody.transform.SetParent(note, false);
            }
        }
            
            //if (line == 2)
            //{
            //    GameObject newBody = Instantiate(XHold_Body, new Vector3(((0.495f * direction) + (i - 1) * 0.25f * direction), 0, 0), Quaternion.identity);
            //    newBody.transform.SetParent(note, false); 
            // }
        
        
        //noteBody.transform.localScale = new Vector3(bodyScale, 1f, 1f);
        tailPosition = noteCore.localPosition.x + (0.495f * direction) + (bodyScale * 0.25f * direction);
        noteTail.localPosition = new Vector3(tailPosition, 0f, 0f);
        //Debug.Log(bodyScale);
        //Debug.Log(noteCore.position.x);
        Debug.Log(tailPosition);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BNoteCanBeCount : MonoBehaviour
{
    public bool canBeCount = true;
    public int line;
    public bool isAni = false;
    public bool isCoroutineRunning = false;
    public Material mat;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyUp(GameObject.Find("RhythmManager").GetComponent<BRhythmManager>().targets[line - 1].GetComponent<BNoteHit>().keyToPress) && this.gameObject.activeInHierarchy))
        {
            if (GameObject.Find("RhythmManager").GetComponent<BRhythmManager>().targets[line - 1].transform.GetChild(3).GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("long"))
            { 
            Debug.Log("up");
            GameObject.Find("RhythmManager").GetComponent<BRhythmManager>().targets[line - 1].transform.GetChild(3).GetComponent<Animator>().SetTrigger("release");
        }
            
        }
        if(this.transform.GetChild(0).GetComponent<TrailRenderer>().material.name == mat.name)
        {
            Debug.Log("miss");
            GameObject.Find("RhythmManager").GetComponent<BRhythmManager>().targets[line - 1].transform.GetChild(3).GetComponent<Animator>().SetTrigger("release");
         
        }
    }
    void OnEnable()
    {
        isCoroutineRunning = false;
    }
    void OnDisable()
    {
        if(line != 0)
        {
        Debug.Log("disable" + this.transform.position);
        GameObject.Find("RhythmManager").GetComponent<BRhythmManager>().targets[line - 1].transform.GetChild(3).GetComponent<Animator>().SetTrigger("release");
        }
    }
    public void longNoteHit()
    {
        if(!isCoroutineRunning)
        {
            isCoroutineRunning = true;
            StartCoroutine(longNoteDestroy());

        }
    }
    IEnumerator longNoteDestroy()
    {
        yield return new WaitForSeconds(this.transform.GetChild(0).GetComponent<TrailRenderer>().time);
        this.gameObject.SetActive(false);
        
        line = 0;
        this.gameObject.GetComponent<DrawBesizerLine>().basePoint.Clear();
        this.gameObject.GetComponent<DrawBesizerLine>().length = 0;
        this.gameObject.GetComponent<DrawBesizerLine>().line = null;
        this.gameObject.GetComponent<DrawBesizerLine>().enabled = false;
        //BRhythmManager.instance.NoteHit();
        this.transform.GetChild(0).GetComponent<TrailRenderer>().time = -1;
        isCoroutineRunning = false;
    }
}

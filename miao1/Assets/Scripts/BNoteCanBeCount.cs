using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BNoteCanBeCount : MonoBehaviour
{
    public bool canBeCount = true;
    public int line;
    public bool isAni = false;
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
        }
            GameObject.Find("RhythmManager").GetComponent<BRhythmManager>().targets[line - 1].transform.GetChild(3).GetComponent<Animator>().SetTrigger("release");
        }
    }
    void onDisable()
    {
        GameObject.Find("RhythmManager").GetComponent<BRhythmManager>().targets[line - 1].transform.GetChild(3).GetComponent<Animator>().SetTrigger("release");
    }
}

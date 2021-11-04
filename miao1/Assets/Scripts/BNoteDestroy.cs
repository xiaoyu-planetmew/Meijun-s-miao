using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BNoteDestroy : MonoBehaviour
{
    public Material mat1;
    public Material mat2;
    void OnTriggerEnter2D(Collider2D other)
    {
        //Destroy(other.gameObject);                //传统方法，直接删除子弹

        
        if(other.gameObject.GetComponent<BNoteCanBeCount>().canBeCount == true && other.tag == "note")
        {
            BRhythmManager.instance.NoteMissed(other.gameObject.GetComponent<DrawBesizerLine>().numInSequence);
            other.gameObject.SetActive(false);          //对象池方法，把子弹失效就好了
            other.gameObject.GetComponent<DrawBesizerLine>().basePoint.Clear();
        
            other.gameObject.GetComponent<DrawBesizerLine>().length = 0;
            other.gameObject.GetComponent<DrawBesizerLine>().enabled = false;
            other.gameObject.GetComponent<BNoteCanBeCount>().canBeCount = false;
            //other.transform.GetChild(0).GetComponent<TrailRenderer>().time = -1;
        }
        if(other.gameObject.GetComponent<BNoteCanBeCount>().canBeCount == true && other.tag == "longNote")
        {
            BRhythmManager.instance.NoteMissed(other.gameObject.GetComponent<DrawBesizerLine>().numInSequence);
            other.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = false;
                      //对象池方法，把子弹失效就好了
            
            other.gameObject.GetComponent<BNoteCanBeCount>().canBeCount = false;
            other.transform.GetChild(0).GetComponent<TrailRenderer>().material= mat2;
            StartCoroutine(longNoteMiss(other.gameObject, other.transform.GetChild(0).GetComponent<TrailRenderer>().time));
            
        }
    }
    IEnumerator longNoteMiss(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        obj.gameObject.SetActive(false);
        obj.gameObject.GetComponent<DrawBesizerLine>().basePoint.Clear();
        
        obj.gameObject.GetComponent<DrawBesizerLine>().length = 0;
        obj.gameObject.GetComponent<DrawBesizerLine>().enabled = false;
        obj.transform.GetChild(0).GetComponent<TrailRenderer>().material = mat1;
        obj.transform.GetChild(0).GetComponent<TrailRenderer>().time = -1;
    } 
}
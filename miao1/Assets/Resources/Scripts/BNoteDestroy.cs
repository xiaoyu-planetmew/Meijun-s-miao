using UnityEngine;

public class BNoteDestroy : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        //Destroy(other.gameObject);                //传统方法，直接删除子弹

        other.gameObject.SetActive(false);          //对象池方法，把子弹失效就好了
        other.gameObject.GetComponent<DrawBesizerLine>().basePoint.Clear();
        
        other.gameObject.GetComponent<DrawBesizerLine>().length = 0;
        other.gameObject.GetComponent<DrawBesizerLine>().enabled = false;
        if(other.gameObject.GetComponent<BNoteCanBeCount>().canBeCount == true)
        {
            BRhythmManager.instance.NoteMissed();
        }
        
    }
}
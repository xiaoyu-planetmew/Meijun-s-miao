using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class buttonCycle : MonoBehaviour
{
    public Animator ani;
    public float aniTime;
    public Button _button;
    public int cycleTimes;
    public int clickTime = 0;
    public GameObject item;
    
    //public Animator itemAni;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void click()
    {
        clickTime++;
        ani.SetTrigger("Hit");
        StartCoroutine(aniWait());
        
    }
    IEnumerator aniWait()
    {
        _button.enabled = false;
        yield return new WaitForSeconds(aniTime);
        _button.enabled = true;
        if(clickTime == cycleTimes)
        {
            item.SetActive(true);
            //itemAni.SetTrigger("Hit");
        }
    }
}

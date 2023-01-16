using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class girlAnim : MonoBehaviour
{
    public GameObject nextButton;
    public GameObject Button2C01;
    public List<string> triggers = new List<string>();
    public int nowCount = 1;
    public int nowCut = 1;
    public float animSpeed = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!triggers.Contains(getCurrentClipInfo()))
        {
            nextButton.SetActive(false);
        }
    }
    public string getCurrentClipInfo() // 获取当前执行的动画
    {
        AnimatorClipInfo[] m_CurrentClipInfo = gameObject.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0);
        return m_CurrentClipInfo[0].clip.name;
    }
    public void wakeupButton()
    {
        nextButton.SetActive(true);
    }
    public void wakeupButton2C01()
    {
        animSpeed = this.GetComponent<Animator>().speed;
        this.GetComponent<SpriteRenderer>().enabled = false;
        this.GetComponent<Animator>().speed = 0;
        Button2C01.SetActive(true);
    }
    public void countPlus()
    {
        nowCount++;
    }
    public void next()
    {
        this.GetComponent<SpriteRenderer>().enabled = true;
        this.GetComponent<Animator>().speed = animSpeed;
        Debug.Log(triggers[nowCount]);
        this.GetComponent<Animator>().SetTrigger(triggers[nowCount]);
        //nowCount++;
        nextButton.SetActive(false);
    }
    public void changeCut()
    {
        nowCut++;
        /*
        if(nowCount<24)
        {
            
            //this.GetComponent<SpriteRenderer>().enabled = true;
            this.GetComponent<Animator>().SetTrigger(triggers[nowCount]);
            //this.GetComponent<Animator>().speed = animSpeed;
            Debug.Log(triggers[nowCount]);
        }else{
            this.GetComponent<SpriteRenderer>().enabled = false;
        }*/
        StartCoroutine(changeCutDelay());
    }
    IEnumerator changeCutDelay()
    {
        animSpeed = this.GetComponent<Animator>().speed;
        this.GetComponent<SpriteRenderer>().enabled = false;
        this.GetComponent<Animator>().speed = 0;
        yield return new WaitForSeconds(1f);
        
        if(nowCount<24)
        {
            
            //this.GetComponent<SpriteRenderer>().enabled = true;
            this.GetComponent<Animator>().SetTrigger(triggers[nowCount]);
            this.GetComponent<Animator>().speed = animSpeed;
            Debug.Log(triggers[nowCount]);
        }else{
            this.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
    public void newCut()
    {
        this.GetComponent<SpriteRenderer>().enabled = true;
    }
}

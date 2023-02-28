using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class windChime : MonoBehaviour
{
    public GameObject cam;
    public List<GameObject> chimes = new List<GameObject>();
    public GameObject chimeCanvas;
    public GameObject processUI;
    public GameObject kada;
    public GameObject finishUI;
    public GameObject hand;
    public bool finished;
    public float targetProcess;
    float lastR = 0f;
    public float totalScore;
    public UnityEvent finishEvent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!finished)
        {
            foreach(var obj in chimes)
            {
                chimeScore(obj);
            }
            processUI.GetComponent<Image>().fillAmount = totalScore / targetProcess;
        
            if(totalScore >= targetProcess)
            {
                chimeFinish();
            }  
        } 
        if(Mathf.Abs(cam.transform.localPosition.x + 280) <= 1 && !finished)
        {
            chimeCanvas.SetActive(true);
            MouseSet.Instance.mouseChange("shubiao_shou");
            hand.SetActive(true);
        }else
        {
            chimeCanvas.SetActive(false);
            MouseSet.Instance.mouseChange("mouseTexture");
            hand.SetActive(false);
        }     
    }
    void chimeScore(GameObject obj)
    {
        float currentR = obj.transform.localRotation.z;
        float deltaR;
        if(currentR == lastR)
        {

        }else{
            deltaR = Mathf.Abs(currentR - lastR);
            totalScore += deltaR;
        }
        lastR = currentR;
    }
    public void chimeAudio(GameObject obj)
    {
        if(!finished)
        {
            StopAllCoroutines();
            StartCoroutine(stopKada());
        }
        
    }
    IEnumerator stopKada()
    {
        kada.gameObject.GetComponent<Image>().enabled = true;
        yield return new WaitForSeconds(0.2f);
        if(kada.GetComponent<Image>().enabled == true)
        {
            kada.GetComponent<Image>().enabled = false;
        }
    }
    void chimeFinish()
    {
        finished = true;
        finishUI.GetComponent<Image>().enabled = true;
        kada.GetComponent<Image>().enabled = false;
        hand.SetActive(false);
        foreach(var obj in chimes)
        {
            obj.GetComponent<BoxCollider2D>().enabled = false;
        }
        if(finishEvent != null)
        {
            finishEvent.Invoke();
        }
    }
}

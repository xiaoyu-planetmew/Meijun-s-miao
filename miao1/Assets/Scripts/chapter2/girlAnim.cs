using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AddressableAssets;

public class girlAnim : MonoBehaviour
{
    public GameObject nextButton;
    public GameObject Button2C01;
    public List<string> triggers = new List<string>();
    public int nowCount = 1;
    public int nowCut = 1;
    public float animSpeed = 1;
    public UnityEvent afterAnim;
    public GameObject cam;
    //public Animator anim;

    void Start()
    {
        //cam.GetComponent<AudioSource>().Stop();
        //Addressables.LoadAssetsAsync<RuntimeAnimatorController>(assetLabel, OnLoadDone);
        //Addressables.LoadAssetAsync<RuntimeAnimatorController>("sequenceFrame/女孩的诗/girlAnim.controllerrlAnim.controller").Completed += OnLoadDone;
    }

    /// <summary>
    /// 资源加载完成回调，此处可以加一个进度显示和交互限制，等待加载完毕之后再操作，防止异常
    /// </summary>
    /// <param name="animtorClip"></param>
    /*void OnLoadDone(RuntimeAnimatorController animtorClip)
    {
        Debug.Log(animtorClip.name);
        this.GetComponent<Animator>().runtimeAnimatorController = animtorClip;
        this.GetComponent<Animator>().enabled = true;
    }*/
   private void OnLoadDone(UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<RuntimeAnimatorController> obj)
    {
        // In a production environment, you should add exception handling to catch scenarios such as a null result.
        //anim.runtimeAnimatorController = obj.Result;
    }
    // Start is called before the first frame update

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
    public void countPlus(int now)
    {
        nowCount = now;
        //nowCount++;
    }
    public void next()
    {
        this.GetComponent<SpriteRenderer>().enabled = true;
        this.GetComponent<Animator>().speed = animSpeed;
        Debug.Log(nowCount);
        Debug.Log(triggers[nowCount]);
        this.GetComponent<Animator>().SetTrigger(triggers[nowCount]);
        //nowCount++;
        nextButton.SetActive(false);
    }
    public void changeCut(int now)
    {
        nowCut = now;
        //nowCut++;
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
    public void playFinish()
    {
        if(afterAnim != null) afterAnim.Invoke();
        cam.GetComponent<AudioSource>().Play();
    }
}

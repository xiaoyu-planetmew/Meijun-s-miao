using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Spine.Unity;
using Spine;
using static Spine.AnimationState;

public class CircleProcess : MonoBehaviour
{
    private bool IsStart = false;

    public Transform process;
    public Transform indicator;
    public UnityEngine.Animation shenniao;

    public int targetProcess = 2;
    private float currentAmout = 0;
    public UnityEvent succeedEvent;
    public bool isBird = true;
    void Start() 
    {
        if(isBird) shenniao.gameObject.SetActive(true);
    }
  
    void Update()
    {
        if (currentAmout < targetProcess)
        {
            if (IsStart)
            {
                currentAmout += Time.deltaTime;
                Process();
                if(currentAmout > 0 && currentAmout < targetProcess && GameManager2.instance.player.transform.Find("ChracterNew").gameObject.GetComponent<SkeletonAnimation>().AnimationName != "summon")
        {
            //GameManager2.instance.player.GetComponent<chracterAnimEvents>().playOtherAnim(2);
            GameManager2.instance.player.transform.Find("ChracterNew").gameObject.GetComponent<SkeletonAnimation>().state.SetAnimation(0, "summon", true);
            GameManager2.instance.player.GetComponent<FinalMovement>().otherAnim = true;
        }
            }
            else
            {
                currentAmout -= Time.deltaTime;
                GameManager2.instance.player.GetComponent<FinalMovement>().otherAnim = false;
                Process();
            }
        }
        else
        {
            //indicator.GetComponent<Text>().text = "激活成功";
            succeedEvent.Invoke();
            if(isBird) shenniao.transform.localPosition = new Vector3(-7.09f, -1.83f, shenniao.transform.localPosition.z);
            GameManager2.instance.player.GetComponent<FinalMovement>().otherAnim = false;
            //GameManager2.instance.player.GetComponent<chracterAnimEvents>().playOtherAnim(4);
        }
        if(currentAmout > 0 && currentAmout < targetProcess && shenniao.gameObject.GetComponent<SkeletonAnimation>().AnimationName != "appeared" && isBird)
        {
            if(isBird) shenniao.gameObject.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "appeared", true);
        }
        
        if(currentAmout <= 0)
        {
            GameManager2.instance.player.GetComponent<FinalMovement>().otherAnim = false;
        }
    }
    public void Process()
    {
        indicator.GetComponent<Text>().text = ((int)(currentAmout * 50)).ToString() + "%";
        process.GetComponent<Image>().fillAmount = currentAmout / targetProcess;
        if (currentAmout > targetProcess)
            currentAmout = targetProcess;
        if (currentAmout<0)
            currentAmout = 0;

        //shenniao["shenniaodengchang"].normalizedTime = currentAmout / 2;
        if(isBird) shenniao.transform.localPosition = new Vector3(shenniao.transform.localPosition.x, 17.5f-(17.5f + 4.1f) * currentAmout / targetProcess, shenniao.transform.localPosition.z);
    }

    public void Clickprocess(bool bStart)
    {
        IsStart = bStart;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Cinemachine;
using Spine;
using Spine.Unity;

public class underWater1Ctrl : MonoBehaviour
{
    public GameObject hongyu;
    public GameObject huangyu;
    public GameObject lanyu;
    public float yuScale;
    public GameObject yuCanvas;
    public Vector3 targetcamPos;
    Vector3 camPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void underWater1Start()
    {
        hongyu.SetActive(true);
        huangyu.SetActive(true);
        lanyu.SetActive(true);
        yuCanvas.SetActive(true);
    }
    public void yuDialog0()
    {
        GameManager2.instance.player.GetComponent<FinalMovement>().changeCanMove(false);
        camPos = GameObject.Find("Main Camera").transform.position;
        GameObject.Find("Main Camera").gameObject.GetComponent<CinemachineBrain>().enabled = false;
        DG.Tweening.Sequence quence = DOTween.Sequence();
        quence.Append(GameObject.Find("Main Camera").transform.DOMove(targetcamPos, 5).OnComplete(() =>
        {
            hongyu.transform.localScale = new Vector3(yuScale, yuScale, yuScale);
            huangyu.transform.localScale = new Vector3(yuScale, yuScale, yuScale);
            lanyu.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "speak", true);
            DialogSys2.Instance.dialogStart(15);
        }));
        
    }
    public void yuDialog1()
    {
        lanyu.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "speak", true);
        huangyu.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "speak", true);
        hongyu.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "speak", true);
        DialogSys2.Instance.dialogStart(17);
    }
    public void yuDialog2()
    {
        hongyu.transform.localScale = new Vector3(yuScale * -1f, yuScale, yuScale);
        huangyu.transform.localScale = new Vector3(yuScale * -1f, yuScale, yuScale);
        lanyu.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "idle", true);
        huangyu.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "idle", true);
        hongyu.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "idle", true);
        DG.Tweening.Sequence quence = DOTween.Sequence();
        quence.Append(GameObject.Find("Main Camera").transform.DOMove(camPos, 2).OnComplete(() =>
        {
            GameObject.Find("Main Camera").gameObject.GetComponent<CinemachineBrain>().enabled = true;
            GameManager2.instance.player.GetComponent<FinalMovement>().changeCanMove(true);
            
        }));
    }
}

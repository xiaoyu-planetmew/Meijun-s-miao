using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;
using Spine;
using Spine.Unity;
using static Spine.AnimationState;

public class bigBridgeControl : MonoBehaviour
{
    private List<System.Action> mUnRegisterEventActions = new List<System.Action>();
    public GameObject leiShen;
    public GameObject longWang;
    public GameObject jiangSong;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlaySpineAddEvent(SkeletonAnimation anim, string name, bool isLoop = false, System.Action action = null)
    {
        anim.AnimationState.SetAnimation(0, name, isLoop);
        TrackEntryDelegate ac = delegate
        {
            action();
        };
        anim.AnimationState.Complete += ac;
 
        mUnRegisterEventActions.Add(() =>
        {
            anim.AnimationState.Complete -= ac;
        });
    }

    public void UnRegisterAll()
    {
        mUnRegisterEventActions.ForEach(action => action());
        mUnRegisterEventActions.Clear();
    }
    public void bigBridge1()
    {
        leiShen.SetActive(true);
        //leiShen.transform.GetChild(0).GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "appear", false);
        PlaySpineAddEvent(leiShen.transform.GetChild(0).GetComponent<SkeletonAnimation>(), "appear", false, (() => {
            leiShen.transform.GetChild(0).GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "idle", true);
            leiShen.transform.GetChild(1).Find("startButton").gameObject.SetActive(true);
            UnRegisterAll();
        }));
    }
    public void bigBridge2()
    {
        leiShen.transform.GetChild(0).GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "speak", true);
    }
    public void bigBridge3()
    {
        leiShen.transform.GetChild(0).GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "idle", true);
    }
    public void bigBridge4()
    {
        longWang.SetActive(true);
        jiangSong.transform.position = new Vector3(-284.68f, -1.52f ,0);
        PlaySpineAddEvent(longWang.transform.GetChild(0).GetComponent<SkeletonAnimation>(), "appear", false, (() => {
            DialogSys2.Instance.dialogStart(29);
            PlaySpineAddEvent(longWang.transform.GetChild(0).GetComponent<SkeletonAnimation>(), "speak", false, (() => {
                longWang.transform.GetChild(0).GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "speak_loop", true);
            }));
            UnRegisterAll();
        }));
    }
    public void bigBridge5()
    {
        longWang.transform.GetChild(0).GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "idle", true);
    }
}

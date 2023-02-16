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
    public GameObject jiangYang;
    public GameObject thunder;
    public GameObject bigWave;
    public GameObject bambooTube;
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
            jiangYang.transform.Find("JiangYangCanvas").GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 12.6f);
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
        jiangSong.transform.Find("Spine GameObject (wushi)").GetComponent<SkeletonAnimation>().state.SetAnimation(0, "wwalk", true);
        jiangSong.GetComponent<Animator>().enabled = true;
        jiangSong.GetComponent<Animator>().SetTrigger("moveToBridge");
        //jiangSong.transform.position = new Vector3(-284.68f, -1.52f ,0);
        //jiangSong.transform.Find("Spine GameObject (wushi)").transform.localScale = new Vector3(-0.4f, 0.4f, 0.4f);
        PlaySpineAddEvent(longWang.transform.GetChild(0).GetComponent<SkeletonAnimation>(), "appear", false, (() => {
            DialogSys2.Instance.dialogStart(29);
            longWang.transform.GetChild(0).GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "speak_loop", true);
            //PlaySpineAddEvent(longWang.transform.GetChild(0).GetComponent<SkeletonAnimation>(), "speak", false, (() => {
             //   longWang.transform.GetChild(0).GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "speak_loop", true);
            //}));
            UnRegisterAll();
        }));
    }
    public void bigBridge5()
    {
        longWang.transform.GetChild(0).GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "idle", true);
    }
    public void bigBridge6()
    {
        longWang.SetActive(false);
        leiShen.SetActive(false);
    }
    public void bigBridge7()
    {
        //longWang.SetActive(true);
        leiShen.SetActive(true);
        PlaySpineAddEvent(leiShen.transform.GetChild(0).GetComponent<SkeletonAnimation>(), "appear", false, (() => {
            leiShen.transform.GetChild(0).GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "idle", true);
            UnRegisterAll();
            
        }));
        /*PlaySpineAddEvent(longWang.transform.GetChild(0).GetComponent<SkeletonAnimation>(), "appear", false, (() => {
            longWang.transform.GetChild(0).GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "speak_loop", true);
            //PlaySpineAddEvent(longWang.transform.GetChild(0).GetComponent<SkeletonAnimation>(), "speak", false, (() => {
             //   longWang.transform.GetChild(0).GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "speak_loop", true);
            //}));
            UnRegisterAll();
        }));*/
        jiangSong.transform.Find("Spine GameObject (wushi)").GetComponent<SkeletonAnimation>().state.SetAnimation(0, "wwalk", true);
        jiangSong.GetComponent<Animator>().enabled = true;
        jiangSong.GetComponent<Animator>().SetTrigger("moveToBridge");
        DialogSys2.Instance.dialogStart(37);
    }
    public void bigBridge71()
    {
        
        thunder.SetActive(true);
        StartCoroutine(bigBridge7Delay());
    }
    IEnumerator bigBridge7Delay()
    {
        yield return new WaitForSeconds(5f);
        DialogSys2.Instance.dialogStart(38);
        thunder.GetComponent<bigBridgeEffect>().thunderStop();
    }
    public void bigBridge72()
    {
        longWang.SetActive(true);
        /*leiShen.SetActive(true);
        PlaySpineAddEvent(leiShen.transform.GetChild(0).GetComponent<SkeletonAnimation>(), "appear", false, (() => {
            leiShen.transform.GetChild(0).GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "idle", true);
            UnRegisterAll();
            DialogSys2.Instance.dialogStart(37);
            thunder.SetActive(true);
        }));*/
        PlaySpineAddEvent(longWang.transform.GetChild(0).GetComponent<SkeletonAnimation>(), "appear", false, (() => {
            longWang.transform.GetChild(0).GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "speak_loop", true);
            //PlaySpineAddEvent(longWang.transform.GetChild(0).GetComponent<SkeletonAnimation>(), "speak", false, (() => {
             //   longWang.transform.GetChild(0).GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "speak_loop", true);
            //}));
            UnRegisterAll();
        }));
        //jiangSong.transform.Find("Spine GameObject (wushi)").GetComponent<SkeletonAnimation>().state.SetAnimation(0, "wwalk", true);
        //jiangSong.GetComponent<Animator>().enabled = true;
        //jiangSong.GetComponent<Animator>().SetTrigger("moveToBridge");
        
    }
    public void bigBridge8()
    {
        bambooTube.SetActive(true);
    }
    public void bigBridge9()
    {
        DialogSys2.Instance.dialogStart(42);
    }
    public void bigBridge10()
    {
        DialogSys2.Instance.dialogStart(43);
    }
    public void bigBridge11()
    {
        DialogSys2.Instance.dialogStart(44);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Cinemachine;
using Spine;
using Spine.Unity;
//using System;

public class underWater1Ctrl : MonoBehaviour
{
    public GameObject wall5;
    public GameObject hongyu;
    public GameObject huangyu;
    public GameObject lanyu;
    public GameObject player;
    public GameObject cam;
    public float yuScale;
    public GameObject yuCanvas;
    public Vector3 targetcamPos;
    public Transform girlTarget;
    public bool fishItem = false;
    public List<Item> fishItems = new List<Item>();
    public List<GameObject> fishItemPos = new List<GameObject>();
    public GameObject shell;
    public GameObject startButton;
    public GameObject hudie;
    public Vector3 hudiePos;
    public Vector3 hudieCam;
    public GameObject blackMask;
    public GameObject blackMask2;
    public Vector3 girlPos;
    public GameObject NPC;
    public Vector3 NPC_Pos;
    public GameObject nest;
    public GameObject moment3;
    public GameObject bubble;
    public GameObject girlAnim;
    public AudioSource village;
    public GameObject mapleParticle;
    Vector3 camPos;
    // Start is called before the first frame update
    void Start()
    {
        //player = GameManager2.instance.player;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager2.instance.items.Contains(fishItems[0]) && GameManager2.instance.items.Contains(fishItems[1]) && GameManager2.instance.items.Contains(fishItems[2]))
        {
            fishItem = true;
            EventControl.Instance.events[11] = true;
        }
        if (EventControl.Instance.events[11] && !EventControl.Instance.events[12])
        {
            startButton.SetActive(true);
        }
    }
    /*
    public static IEnumerator IEConstanSpeedMove(this Transform self, Vector3 target, float speed, Action onComplete = null, Action onUpdate = null)
    {
        while (self.position != target)
        {
            self.position = Vector3.MoveTowards(self.position, target, speed * Time.deltaTime);
            onUpdate?.Invoke();
            yield return 0;
        }
        onComplete?.Invoke();
    }
    */
    
    public void underWater1Start()
    {
        wall5.SetActive(true);
        hongyu.SetActive(true);
        huangyu.SetActive(true);
        lanyu.SetActive(true);
        yuCanvas.SetActive(true);
    }
    public void yuDialogAutoStart()
    {
        //GameManager2.instance.player.GetComponent<FinalMovement>().changeCanMove(false);
        //StartCoroutine(playerMove());
        camPos = GameObject.Find("Main Camera").transform.position;
        GameManager2.instance.player.GetComponent<FinalMovement>().changeCanMove(false);
        GameManager2.instance.player.GetComponent <UnderWaterMove>().ChracterNewAnim("swim_idle", true);
        GameObject.Find("Main Camera").gameObject.GetComponent<CinemachineBrain>().enabled = false;/*
        GameManager2.instance.player.transform.DOMove(new Vector3(17.70056f, -9.609916f, 0), 5).OnComplete(() =>
        {
            GameManager2.instance.player.transform.position = new Vector3(17.70056f, -9.609916f, 0);
        });*/
        DG.Tweening.Sequence quence = DOTween.Sequence();
        quence.Append(GameObject.Find("Main Camera").transform.DOMove(targetcamPos, 5).OnComplete(() =>
        {
            //hongyu.transform.localScale = new Vector3(yuScale, yuScale, yuScale);
            //huangyu.transform.localScale = new Vector3(yuScale, yuScale, yuScale);

            hongyu.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "speak", true);
            huangyu.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "speak", true);
            lanyu.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "speak", true);
            DialogSys2.Instance.dialogStart(15);
        }));
    }
    public void yuDialog0()
    {
        hongyu.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "angry", true);
        huangyu.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "angry", true);
        lanyu.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "angry", true);
        /*
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
        */
    }
    public void yuDialog1()
    {
        
        hongyu.transform.localScale = new Vector3(yuScale, yuScale, yuScale);
        huangyu.transform.localScale = new Vector3(yuScale, yuScale, yuScale);
        lanyu.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "idle", true);
        huangyu.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "idle", true);
        hongyu.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "idle", true);
        DialogSys2.Instance.dialogStart(16);
    }
    public void yuDialog2()
    {
        lanyu.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "speak", true);
        DialogSys2.Instance.dialogStart(17);
        /*
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
        */
    }
    public void yuDialog3()
    {
        lanyu.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "idle", true);
        DialogSys2.Instance.dialogStart(18);
    }
    public void yuDialog4()
    {
        hongyu.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "speak", true);
        DialogSys2.Instance.dialogStart(19);
    }
    public void yuDialog5()
    {
        hongyu.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "angry", true);
        huangyu.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "speak", true);
        DialogSys2.Instance.dialogStart(20);
    }
    public void yuDialog6()
    {
        huangyu.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "angry", true);
        lanyu.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "speak", true);
        DialogSys2.Instance.dialogStart(21);
    }
    public void yuDialog7()
    {
        lanyu.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "idle", true);
        DialogSys2.Instance.dialogStart(22);
    }
    public void yuDialog8()
    {
        lanyu.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "speak", true);
        huangyu.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "speak", true);
        hongyu.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "speak", true);
        GameObject.Find("Main Camera").gameObject.GetComponent<CinemachineBrain>().enabled = true;
        GameManager2.instance.player.GetComponent<FinalMovement>().changeCanMove(true);
        foreach(var obj in fishItemPos)
        {
            obj.GetComponent<BoxCollider>().enabled = true;
            obj.GetComponent<clickAnswer>().enabled = true;
        }
        shell.SetActive(true);
    }
    public void yuDialog9()
    {
        hongyu.transform.localScale = new Vector3(yuScale * -1f, yuScale, yuScale);
        huangyu.transform.localScale = new Vector3(yuScale * -1f, yuScale, yuScale);
        lanyu.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "idle", true);
        huangyu.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "idle", true);
        hongyu.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "idle", true);
        yuDialog11();
    }
    public void yuDialog10()
    {
        EventControl.Instance.events[12] = true;
        GameManager2.instance.player.GetComponent<FinalMovement>().changeCanMove(false);
        GameObject.Find("Main Camera").gameObject.GetComponent<CinemachineBrain>().enabled = false;
        DG.Tweening.Sequence quence = DOTween.Sequence();
        quence.Append(GameObject.Find("Main Camera").transform.DOMove(targetcamPos, 5).OnComplete(() =>
        {
            //hongyu.transform.localScale = new Vector3(yuScale, yuScale, yuScale);
            //huangyu.transform.localScale = new Vector3(yuScale, yuScale, yuScale);

            hongyu.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "speak", true);
            huangyu.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "speak", true);
            lanyu.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "speak", true);
            DialogSys2.Instance.dialogStart(23);
        }));
        
    }
    public void yuDialog11()
    {
        mapleParticle.SetActive(false);
        GameObject.Find("InventoryCanvas").gameObject.GetComponent<Canvas>().enabled = false;
        hudie.transform.localPosition = hudiePos;
        bubble.SetActive(true);
        //StartCoroutine(yuDialog11Delay());
        DG.Tweening.Sequence quence = DOTween.Sequence();
        quence.Append(GameObject.Find("Main Camera").transform.DOMove(hudieCam, 5).OnComplete(() =>
        {
            blackMask.GetComponent<SpriteRenderer>().color = new Vector4(1, 1, 1, 0);
            blackMask.GetComponent<SpriteRenderer>().enabled = true;
            blackMask.gameObject.SetActive(true);
            //blackMask2.gameObject.SetActive(true);
            //Debug.Log("1");
        }));
        quence.Append(blackMask.GetComponent<SpriteRenderer>().DOFade(0.99f, 2)).OnComplete(() =>
        {
            //Debug.Log("2");
            //girlAnim.SetActive(true);
            blackMask.SetActive(false);
            girlAnim.SetActive(true);
            cam.GetComponent<AudioSource>().Stop();
            village.Stop();
        });
        //quence.AppendInterval(5);
        //quence.Append(blackMask.GetComponent<SpriteRenderer>().DOFade(0, 2)).OnComplete(() =>
        //{
        //    //Debug.Log("3");
        //    girlAnim.SetActive(true);
        //});
    }
    public void yuDialog12()
    {
        girlAnim.SetActive(false);
        GameManager2.instance.player.transform.position = girlPos;
            GameManager2.instance.player.GetComponent<PlayerUnderWaterControl>().underWater = false;
            GameManager2.instance.player.transform.Find("ChracterNew").GetComponent<ShaderControl>().ClearAllKeywords();
            GameObject.Find("Main Camera").gameObject.GetComponent<CinemachineBrain>().enabled = true;
            nest.SetActive(true);
            moment3.SetActive(true);
            GameManager2.instance.player.GetComponent<FinalMovement>().changeCanMove(true);
            bubble.SetActive(false);
            mapleParticle.SetActive(true);
            GameObject.Find("InventoryCanvas").gameObject.GetComponent<Canvas>().enabled = true;
            GameManager2.instance.player.transform.position = girlPos;
        NPC.transform.localPosition = NPC_Pos;
        NPC.transform.Find("Spine GameObject (wushi)").localScale = new Vector3(0.4f, 0.4f, 0.4f);
        NPC.transform.Find("JiangSongCanvas").GetComponent<RectTransform>().anchoredPosition = new Vector2(-1.18f, 4.32f);
        GameManager2.instance.player.GetComponent<PlayerUnderWaterControl>().underWater = false;
        GameManager2.instance.player.transform.Find("ChracterNew").GetComponent<ShaderControl>().ClearAllKeywords();
        GameObject.Find("Main Camera").gameObject.GetComponent<CinemachineBrain>().enabled = true;
            //blackMask2.gameObject.SetActive(false);
            nest.SetActive(true);
            moment3.SetActive(true);
    }
    IEnumerator yuDialog11Delay()
    {
        yield return new WaitForSeconds(8);
        Debug.Log("2");
        GameManager2.instance.player.transform.position = girlPos;
        NPC.transform.localPosition = NPC_Pos;
        NPC.transform.Find("Spine GameObject (wushi)").localScale = new Vector3(0.4f, 0.4f, 0.4f);
        NPC.transform.Find("JiangSongCanvas").GetComponent<RectTransform>().anchoredPosition = new Vector2(-1.18f, 4.32f);
        GameManager2.instance.player.GetComponent<PlayerUnderWaterControl>().underWater = false;
        GameManager2.instance.player.transform.Find("ChracterNew").GetComponent<ShaderControl>().ClearAllKeywords();
        GameObject.Find("Main Camera").gameObject.GetComponent<CinemachineBrain>().enabled = true;
            //blackMask2.gameObject.SetActive(false);
            nest.SetActive(true);
            moment3.SetActive(true);
    }
}

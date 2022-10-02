using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;
using Spine;
using Spine.Unity;

public class MapleControl : MonoBehaviour
{
    public GameObject maple;
    public GameObject face;
    public GameObject wall2;
    public GameObject wall3;
    public GameObject npc;
    public GameObject laoPoPo;
    public GameObject moment1;
    Vector3 camPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void maple1()
    {
        maple.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "idleB", true);
        GameManager2.instance.player.GetComponent<FinalMovement>().changeCanMove(true);
        wall2.SetActive(true);
        npc.transform.position = new Vector3(-46.58f, -0.44f, 0f);
        npc.transform.GetChild(0).localScale = new Vector3(-0.4f, 0.4f, 0.4f);
        npc.transform.Find("JiangSongCanvas").GetComponent<NearShow>().startButton.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(38, -86);
        GameObject.Find("LaoPoPoAnimation").GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "idle_angry", true);
    }
    public void maple2()
    {
        GameManager2.instance.player.GetComponent<FinalMovement>().changeCanMove(false);
        camPos = GameObject.Find("Main Camera").transform.position;
        GameObject.Find("Main Camera").gameObject.GetComponent<CinemachineBrain>().enabled = false;
        DG.Tweening.Sequence quence = DOTween.Sequence();
        quence.Append(GameObject.Find("Main Camera").transform.DOMove(new Vector3(-42.72f, 2.34f, -6.69f), 5).OnComplete(() =>
        {
            laoPoPo.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "speak_angry", true);
            DialogSys2.Instance.isTalking = false;
            DialogSys2.Instance.dialogStart(7);
            //DialogSys2.Instance.isTalking = false;
            //DialogSys2.Instance.dialogStart(7);
        }));
    }
    public void maple3()
    {
        npc.transform.Find("JiangSongCanvas").Find("duihuakuang (1)").gameObject.SetActive(true);
        laoPoPo.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "idle_angry", true);
        face.SetActive(true);
        face.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "appear", false);
        DG.Tweening.Sequence quence = DOTween.Sequence();
        quence.AppendInterval(3).OnComplete(() =>
        {
            npc.transform.Find("JiangSongCanvas").Find("duihuakuang (1)").gameObject.SetActive(false);
            face.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "idle", true);
            DialogSys2.Instance.isTalking = false;
            DialogSys2.Instance.dialogStart(8);
        });
    }
    public void maple4()
    {
        DG.Tweening.Sequence quence = DOTween.Sequence();
        quence.Append(GameObject.Find("Main Camera").transform.DOMove(new Vector3(-40.12f, 5.86f, -6.69f), 5));
        quence.AppendInterval(3);
        quence.Append(GameObject.Find("Main Camera").transform.DOMove(new Vector3(-42.72f, 2.34f, -6.69f), 5).OnComplete(() =>
        {
            laoPoPo.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "speak_angry", true);
            DialogSys2.Instance.isTalking = false;
            DialogSys2.Instance.dialogStart(9);
        }));
    }
    public void maple5()
    {
        laoPoPo.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "idle_sad", true);
        DG.Tweening.Sequence quence = DOTween.Sequence();
        quence.Join(GameObject.Find("Main Camera").transform.DOMove(camPos, 3)).OnComplete(() =>
        {
            GameObject.Find("Main Camera").gameObject.GetComponent<CinemachineBrain>().enabled = true;
            GameManager2.instance.player.GetComponent<FinalMovement>().changeCanMove(true);
            wall3.SetActive(true);
        });
    }
    public void maple6()
    {
        GameManager2.instance.player.GetComponent<FinalMovement>().changeCanMove(false);
        GameObject.Find("Main Camera").gameObject.GetComponent<CinemachineBrain>().enabled = false;
        DG.Tweening.Sequence quence = DOTween.Sequence();
        quence.Append(GameObject.Find("Main Camera").transform.DOMove(new Vector3(-43.71f, 2.34f, -7.5f), 2).OnComplete(() =>
        {
            //laoPoPo.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "speak_angry", true);
            DialogSys2.Instance.isTalking = false;
            DialogSys2.Instance.dialogStart(10);
            //DialogSys2.Instance.isTalking = false;
            //DialogSys2.Instance.dialogStart(7);
        }));
        
    }
    public void maple7()
    {
        GameObject.Find("Main Camera").gameObject.GetComponent<CinemachineBrain>().enabled = true;
        GameManager2.instance.player.GetComponent<FinalMovement>().changeCanMove(true);
        moment1.SetActive(true);
        EventControl.Instance.finishEvent(1);
    }
}

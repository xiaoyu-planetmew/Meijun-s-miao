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
    public GameObject npc;
    public GameObject laoPoPo;
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
        npc.transform.localScale = new Vector3(-1, 1, 1);
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
            face.SetActive(true);
            face.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "appear", false);
            //DialogSys2.Instance.isTalking = false;
            //DialogSys2.Instance.dialogStart(7);
        }));
        quence.AppendInterval(3).OnComplete(() => {
            face.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "idle", true);
            laoPoPo.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "speak_angry", true);
            DialogSys2.Instance.isTalking = false;
            DialogSys2.Instance.dialogStart(7);
        });
    }
    public void maple3()
    {
        DG.Tweening.Sequence quence = DOTween.Sequence();
        quence.Append(GameObject.Find("Main Camera").transform.DOMove(new Vector3(-40.12f, 5.86f, -6.69f), 5));
        quence.AppendInterval(3);
        quence.Append(GameObject.Find("Main Camera").transform.DOMove(new Vector3(-42.72f, 2.34f, -6.69f), 5).OnComplete(() =>
        {
            
            DialogSys2.Instance.isTalking = false;
            DialogSys2.Instance.dialogStart(8);
        }));
    }
    public void maple4()
    {
        laoPoPo.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "idle_angry", true);
        DG.Tweening.Sequence quence = DOTween.Sequence();
        quence.Join(GameObject.Find("Main Camera").transform.DOMove(camPos, 3)).OnComplete(() =>
        {
            GameObject.Find("Main Camera").gameObject.GetComponent<CinemachineBrain>().enabled = true;
            GameManager2.instance.player.GetComponent<FinalMovement>().changeCanMove(true);
        });
    }
}

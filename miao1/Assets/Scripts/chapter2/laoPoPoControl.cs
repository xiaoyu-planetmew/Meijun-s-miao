using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;
using Spine;
using Spine.Unity;

public class laoPoPoControl : MonoBehaviour
{
    public GameObject wall;
    //public GameObject LaoPoPoCanvas;
    Vector3 camPos;
    public GameObject laoPoPoAni;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LaoPoPoFirst()
    {
        this.transform.Find("LaoPoPoAnimation").GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "speak_angry", true);
        GameManager2.instance.player.GetComponent<FinalMovement>().changeCanMove(false);
        camPos = GameObject.Find("Main Camera").transform.position;
        GameObject.Find("Main Camera").gameObject.GetComponent<CinemachineBrain>().enabled = false;
        DG.Tweening.Sequence quence = DOTween.Sequence();
        quence.Append(GameObject.Find("Main Camera").transform.DOMove(new Vector3(30.94f, 3.706468f, -10f), 5).OnComplete(() =>
        {
            DialogSys2.Instance.isTalking = false;
            DialogSys2.Instance.dialogStart(5);
        }));
    }
    public void birdRun()
    {
        DG.Tweening.Sequence quence = DOTween.Sequence();
        quence.Append(GameObject.Find("Main Camera").transform.DOMove(new Vector3(16.9f, 3.706468f, -10f), 2)).OnComplete(() =>
        {
            GameObject.Find("honglu").GetComponent<bigBirdAnim2>().fly1();
            GameObject.Find("lanlu").GetComponent<bigBirdAnim2>().fly1();
        });
    }
    public void LaoPoPoSecond()
    {
        StartCoroutine(LaoPoPoRun());
        Vector3[] pos = new Vector3[4];
        pos[0] = new Vector3(35.26f, -0.62f, 0f);
        pos[1] = new Vector3(23.34f, -0.62f, 0f);
        pos[2] = new Vector3(21.34f, 2.04f, 0f);
        pos[3] = new Vector3(17.22f, 2.04f, 0f);
        //{ (35.26f, -0.62f, 0f), (23.34f, -0.62f, 0f), (21.34f, 2.04f, 0f), (17.22f, 2.04f, 0f) };
        DG.Tweening.Sequence quence = DOTween.Sequence();
        quence.Append(GameObject.Find("Main Camera").transform.DOMove(new Vector3(30.3f, 3.706468f, -10f), 1));
        quence.Append(this.transform.DOPath(pos, 6, PathType.Linear, PathMode.Ignore)).OnComplete(() =>
        {
            this.transform.Find("LaoPoPoAnimation").GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "speak_angry", true);
            DialogSys2.Instance.dialogStart(6);
        }); 
        quence.Join(GameObject.Find("Main Camera").transform.DOMove(new Vector3(13.2f, 3.706468f, -10f), 6));
        //quence.Append(this.transform.DOMove(new Vector3(23.34f, -0.62f, 0), 2));
        //quence.Join(GameObject.Find("Main Camera").transform.DOMove(new Vector3(22.37f, 3.706468f, -10f), 1));
        //quence.Append(this.transform.DOMove(new Vector3(21.34f, 2.04f, 0), 2));
        //quence.Append(this.transform.DOMove(new Vector3(17.22f, 2.04f, 0), 2)).OnComplete(() =>
        //{
        //    this.transform.Find("LaoPoPoAnimation").GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "speak_angry", true);
        //    DialogSys2.Instance.dialogStart(6);
        //});
        //quence.Join(GameObject.Find("Main Camera").transform.DOMove(new Vector3(13.2f, 3.706468f, -10f), 1));
    }
    IEnumerator LaoPoPoRun()
    {
        yield return new WaitForSeconds(1);
        this.transform.Find("LaoPoPoAnimation").GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "run_angry", true);
    }
    public void LaoPoPoThird()
    {
        Vector3[] pos = new Vector3[3];
        pos[0] = new Vector3(17.22f, 2.04f, 0f);
        pos[1] = new Vector3(15.34f, 2.04f, 0f);
        pos[2] = new Vector3(10.83f, -0.62f, 0f);
        //pos[3] = new Vector3(17.22f, 2.04f, 0f);
        this.transform.Find("LaoPoPoAnimation").GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "run_angry", true);
        DG.Tweening.Sequence quence = DOTween.Sequence();
        //quence.Append(this.transform.DOMove(new Vector3(15.34f, 2.04f, 0f), 0.5f));
        //quence.Append(this.transform.DOMove(new Vector3(10.83f, -0.62f, 0f), 1f));
        quence.Append(this.transform.DOPath(pos, 2, PathType.Linear, PathMode.Ignore));
        quence.Append(this.transform.DOMove(new Vector3(-39.81f, -0.62f, 0f), 6)).OnComplete(() =>
        {
            laoPoPoAni.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "idle_angry", true);
        });
        quence.Join(GameObject.Find("Main Camera").transform.DOMove(camPos, 3)).OnComplete(() =>
        {
            GameObject.Find("Main Camera").gameObject.GetComponent<CinemachineBrain>().enabled = true;
            GameObject.Find("Maple").gameObject.GetComponent<MapleControl>().maple1();
            //this.transform.Find("LaoPoPoAnimation").GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "idle_angry", true);
        });
    }
}

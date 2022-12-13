using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using Spine;
using DG.Tweening;
using System.Linq;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class bigBirdAnim : MonoBehaviour, IPointerClickHandler
{
    SkeletonAnimation skeletonAnimation;
    Spine.AnimationState spineAnimationState;

    public Transform[] Pos;
    public Transform finalPos;
    public GameObject elseBird;
    public Transform[] Pos1;
    public Transform finalPos1;
    //bool takeOffFinished = false;
    // Start is called before the first frame update
    void Start()
    {
        skeletonAnimation = this.transform.Find("birdAnimation").gameObject.GetComponent<SkeletonAnimation>();
        spineAnimationState = skeletonAnimation.AnimationState;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void takeof()
    {
        
        DialogSys2.Instance.canContinue = false;
        if (skeletonAnimation == null) return;
        //this.GetComponent<Animator>().enabled = false;
        this.GetComponent<SpriteRenderer>().enabled = false;
        this.transform.Find("birdAnimation").gameObject.SetActive(true);
        spineAnimationState.SetAnimation(0, "debut", false).Complete += delegate
        {
            DialogSys2.Instance.dialogStart(3);
            spineAnimationState.SetAnimation(0, "idle", true);
            DialogSys2.Instance.canContinue = true;
        }; 
        /*spineAnimationState.AddAnimation(0, "idle", false, 0f).Complete += delegate
        {
            if (this.gameObject.name == "lanlu")
            {
                this.transform.localScale = new Vector3(1, 1, 1);
                spineAnimationState.AddAnimation(0, "take off", false, 0f).Complete += delegate
                {
                    Debug.Log("fly");
                    flyPath();
                
                };
                spineAnimationState.AddAnimation(0, "fly", true, 0f);
            }
            if (this.gameObject.name == "honglu")
            {
                flyDelay();
            }
        };
        */
        
    }
    public void fly()
    {
        //takeOffFinished = true;
        //if (elseBird.GetComponent<bigBirdAnim>().takeOffFinished == false)
       // elseBird.GetComponent<bigBirdAnim>().fly();
        
        if (this.gameObject.name == "lanlu")
        {
            this.transform.localScale = new Vector3(1, 1, 1);
            spineAnimationState.AddAnimation(0, "take off", false, 0f).Complete += delegate
            {
                Debug.Log("fly");
                flyPath();

            };
            spineAnimationState.AddAnimation(0, "fly", true, 0f);
        }
        if (this.gameObject.name == "honglu")
        {
            flyDelay();
        }
    }
    public void fly1()
    {
        //takeOffFinished = true;
        //if (elseBird.GetComponent<bigBirdAnim>().takeOffFinished == false)
        // elseBird.GetComponent<bigBirdAnim>().fly();

        if (this.gameObject.name == "lanlu")
        {
            this.transform.localScale = new Vector3(-1, 1, 1);
            spineAnimationState.AddAnimation(0, "take off", false, 0f).Complete += delegate
            {
                Debug.Log("fly");
                flyPath1();

            };
            spineAnimationState.AddAnimation(0, "fly", true, 0f);
        }
        if (this.gameObject.name == "honglu")
        {
            this.transform.localScale = new Vector3(1, 1, 1);
            flyDelay1();
        }
    }
    void flyDelay()
    {
        spineAnimationState.SetAnimation(0, "idle", false);
        spineAnimationState.AddAnimation(0, "idle", false, 0f);
        //spineAnimationState.AddAnimation(0, "idle", false, 0f);
        //spineAnimationState.AddAnimation(0, "idle", false, 0f);
        spineAnimationState.AddAnimation(0, "take off", false, 0f).Complete += delegate
        {
            Debug.Log("fly");
            flyPath();
        };
        spineAnimationState.AddAnimation(0, "fly", true, 0f);
    }
    void flyDelay1()
    {
        spineAnimationState.SetAnimation(0, "idle", false);
        spineAnimationState.AddAnimation(0, "idle", false, 0f);
        //spineAnimationState.AddAnimation(0, "idle", false, 0f);
        //spineAnimationState.AddAnimation(0, "idle", false, 0f);
        spineAnimationState.AddAnimation(0, "take off", false, 0f).Complete += delegate
        {
            Debug.Log("fly");
            flyPath1();
        };
        spineAnimationState.AddAnimation(0, "fly", true, 0f);
    }
    IEnumerator final()
    {
        Debug.Log("final0");
        yield return new WaitForSeconds(3);
        Debug.Log("final");
        this.transform.position = finalPos.transform.position;
        if (this.gameObject.name == "lanlu")
        {
            this.transform.localScale = new Vector3(-1, 1, 1);
            this.transform.localEulerAngles = new Vector3(0, 0, 0);
        }
        if (this.gameObject.name == "honglu")
        {
            this.transform.localScale = new Vector3(1, 1, 1);
            this.transform.localEulerAngles = new Vector3(0, 0, 0);
            GameManager2.instance.player.GetComponent<FinalMovement>().canMove = true;
            GameManager2.instance.player.GetComponent<FinalMovement>().changeCanMove(true);
            DialogSys2.Instance.dialogStart(4);
        }
        skeletonAnimation.skeleton.SetToSetupPose();
        spineAnimationState.ClearTracks();
        spineAnimationState.SetAnimation(0, "eat", true);
    }
    IEnumerator final1()
    {
        Debug.Log("final0");
        yield return new WaitForSeconds(3);
        Debug.Log("final");
        this.transform.position = finalPos1.transform.position;
        if (this.gameObject.name == "lanlu")
        {
            this.transform.localScale = new Vector3(-1, 1, 1);
            this.transform.localEulerAngles = new Vector3(0, 0, 0);
        }
        if (this.gameObject.name == "honglu")
        {
            this.transform.localScale = new Vector3(1, 1, 1);
            this.transform.localEulerAngles = new Vector3(0, 0, 0);
            GameManager2.instance.player.GetComponent<FinalMovement>().canMove = false;
            GameManager2.instance.player.GetComponent<FinalMovement>().changeCanMove(false);
            //DialogSys2.Instance.dialogStart(4);
            GameObject.Find("LaoPoPo").GetComponent<laoPoPoControl>().LaoPoPoSecond();
        }
        skeletonAnimation.skeleton.SetToSetupPose();
        spineAnimationState.ClearTracks();
        spineAnimationState.SetAnimation(0, "idle", true);
        this.gameObject.SetActive(false);
    }
    public void flyPath()
    {
        var positions = Pos.Select(u => u.position).ToArray();
        /*
            ����һ:·���� ����
            ������:��ɶ�����Ҫ ������
            ������:·���Ļ��������߻���ֱ��
            ������:·��ģʽ Full3D
            ������:·����ľ��ܶ� ��ֵԽ��Խ����
            ������:·����·����ɫ
            SetOptions(true) ·����ͷ�ص�ԭ��
            SetLookAt(0) ·��������·���㱣�ֵļн� ȡֵ��Χ0-1
         */
        transform.DOPath(positions, 2, PathType.CatmullRom, PathMode.Full3D, 50).SetOptions(false).SetLookAt(0, Vector3.left);
        StartCoroutine(final());
    }
    public void flyPath1()
    {
        var positions = Pos1.Select(u => u.position).ToArray();
        /*
            ����һ:·���� ����
            ������:��ɶ�����Ҫ ������
            ������:·���Ļ��������߻���ֱ��
            ������:·��ģʽ Full3D
            ������:·����ľ��ܶ� ��ֵԽ��Խ����
            ������:·����·����ɫ
            SetOptions(true) ·����ͷ�ص�ԭ��
            SetLookAt(0) ·��������·���㱣�ֵļн� ȡֵ��Χ0-1
         */
        transform.DOPath(positions, 6, PathType.CatmullRom, PathMode.Full3D, 50).SetOptions(false).SetLookAt(0, Vector3.left);
        StartCoroutine(final1());
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        this.GetComponent<BoxCollider>().enabled = false;
        this.GetComponent<Animator>().enabled = true;
        this.GetComponent<mouseChangeObj>().ExitUI();
        this.GetComponent<mouseChangeObj>().enabled = false;
        //takeof();
        elseBird.GetComponent<BoxCollider>().enabled = false;
        elseBird.GetComponent<Animator>().enabled = true;
        elseBird.GetComponent<mouseChangeObj>().ExitUI();
        elseBird.GetComponent<mouseChangeObj>().enabled = false;
        //DialogSys2.Instance.dialogStart(3);
        GameManager2.instance.player.GetComponent<chracterAnimEvents>().playOtherAnim(1);
        GameManager2.instance.player.GetComponent<chracterAnimEvents>().jiangSongAnim(1);
    }
    public void flyAway()
    {
        fly1();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using Spine;
using DG.Tweening;
using System.Linq;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class bigBirdAnim2 : MonoBehaviour
{
    SkeletonAnimation skeletonAnimation;
    Spine.AnimationState spineAnimationState;

    public Transform[] Pos1;
    public Transform finalPos1;
    public GameObject elseBird;
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
            this.transform.localScale = new Vector3(-1, 1, 1);
            flyDelay1();
        }
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
            spineAnimationState.ClearTracks();
            flyPath1();
        };
        spineAnimationState.AddAnimation(0, "fly", true, 0f);
    }
    IEnumerator final1()
    {
        Debug.Log("final0");
        yield return new WaitForSeconds(6);
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
    }
    public void flyPath1()
    {
        this.transform.localScale = new Vector3(1, 1, 1);
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
    public void flyAway()
    {
        fly1();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using Spine;
using DG.Tweening;
using System.Linq;

public class bigBirdAnim : MonoBehaviour
{
    SkeletonAnimation skeletonAnimation;
    Spine.AnimationState spineAnimationState;

    public Transform[] Pos;
    public Transform finalPos;
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
        if (skeletonAnimation == null) return;
        //this.GetComponent<Animator>().enabled = false;
        this.GetComponent<SpriteRenderer>().enabled = false;
        this.transform.Find("birdAnimation").gameObject.SetActive(true);
        spineAnimationState.SetAnimation(0, "debut", false);
        spineAnimationState.AddAnimation(0, "idle", false, 0f).Complete += delegate
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
        
        
    }
    void flyDelay()
    {
        spineAnimationState.SetAnimation(0, "idle", false);
        //spineAnimationState.AddAnimation(0, "idle", false, 0f);
        //spineAnimationState.AddAnimation(0, "idle", false, 0f);
        //spineAnimationState.AddAnimation(0, "idle", false, 0f);
        spineAnimationState.AddAnimation(0, "take off", false, 0f).Complete += delegate
        {
            Debug.Log("fly");
            flyPath();
        };
        spineAnimationState.AddAnimation(0, "fly", true, 0f);
    }
    IEnumerator final()
    {
        Debug.Log("final0");
        yield return new WaitForSeconds(11);
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
        spineAnimationState.SetAnimation(0, "idle", true);
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
        transform.DOPath(positions, 6, PathType.CatmullRom, PathMode.Full3D, 50).SetOptions(false).SetLookAt(0, Vector3.left);
        StartCoroutine(final());
    }
}

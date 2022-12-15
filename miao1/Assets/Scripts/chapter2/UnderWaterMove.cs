using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Spine.Unity;
using Spine;
using System.Runtime.CompilerServices;
using UnityEngine.Events;
using Cinemachine;

public class UnderWaterMove: MonoBehaviour
{
    public Rigidbody2D myplayer;
    public Animator playerani;
    public float speed = 5f;
    private Vector2 vector;
    public float xmove = 0; // 用以进行角色移动
    public float ymove = 0; 
    public float xanim = 0; // 用以进行角色动画判定
    public float yanim = 0;
    public bool otherAnim = false;
    public bool canMove = true;
    void Start()
    {
        myplayer = this.gameObject.GetComponent<Rigidbody2D>();
        playerani = this.gameObject.GetComponent<Animator>();
 
    }
    public void SpineStateMachine()
    {
        if (Mathf.Abs(xmove) <= 0.001 && Mathf.Abs(ymove) <= 0.001 && !otherAnim && this.transform.Find("ChracterNew").GetComponent<SkeletonAnimation>().AnimationName != "swim_idle")
        {
            ChracterNewAnim("swim_idle", true);
        }
        if (Mathf.Abs(xmove) >= 0.001 && Mathf.Abs(ymove) <= 0.001 && !otherAnim && this.transform.Find("ChracterNew").GetComponent<SkeletonAnimation>().AnimationName != "swim_move")
        {
            ChracterNewAnim("swim_move", true);
        }
        if (ymove >= 0.001 && !otherAnim && this.transform.Find("ChracterNew").GetComponent<SkeletonAnimation>().AnimationName != "swim_up")
        {
            ChracterNewAnim("swim_up", true);
        }
        if (ymove <= -0.001 && !otherAnim && this.transform.Find("ChracterNew").GetComponent<SkeletonAnimation>().AnimationName != "swim_down")
        {
            ChracterNewAnim("swim_down", true);
        }
    }
    public void ChracterNewAnim(string animationName, bool loop)
    {
        if (this.transform.Find("ChracterNew"))
        {
            SkeletonAnimation skeletonAnimation;   //gameobject的component。
            skeletonAnimation = this.transform.Find("ChracterNew").GetComponent<SkeletonAnimation>();
            if (skeletonAnimation == null) return;
            Spine.AnimationState spineAnimationState = skeletonAnimation.state;
            //Spine.Skeleton skeleton;
            //skeletonAnimation.skeleton.SetToSetupPose();
            //spineAnimationState.ClearTracks();
            spineAnimationState.SetAnimation(0, animationName, loop);
        }
    }
    void FixedUpdate()
    {
        if(canMove)
        {

        
        xmove = Input.GetAxisRaw("Horizontal"); //得到用户输入值
        ymove = Input.GetAxisRaw("Vertical");
        //playerani.SetFloat("xinput", xanim);   //用该变量来判定动画如何的切换。
        //playerani.SetFloat("yinput", yanim);   
        Vector2 vector = new Vector2(xmove, ymove);
        var i = transform.GetChild(0).localScale.y;
            if (xmove <= 0)
            {
                transform.GetChild(0).localScale = new Vector3(-1 * i, i, i);
                if (transform.Find("ChracterNew"))
                {
                    transform.Find("ChracterNew").localScale = new Vector3(-1 * i, i, i);
                }
                this.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
                //playerCanvas.scale
                
            }
            if (xmove >= 0)
            {
                transform.GetChild(0).localScale = new Vector3(1 * i, i, i);
                if (transform.Find("ChracterNew"))
                {
                    transform.Find("ChracterNew").localScale = new Vector3(1 * i, i, i);
                }
                this.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            }
            
        }
        else
        {
            xmove = 0;
            ymove = 0;
            myplayer.velocity = new Vector2(0, 0);
            //hracterNewAnim("swim_idle", true);
        }
        movement(vector);
        SpineStateMachine();
        if(!canMove && this.transform.Find("ChracterNew").GetComponent<SkeletonAnimation>().AnimationName != "swim_idle")
        {
            
            //ChracterNewAnim("swim_idle", true);
        }
    }
 
    private void movement(Vector2 vec)
    {
        if (canMove && vec != Vector2.zero)          //判定是否在运动
        {
            //playerani.SetBool("iswalking", true);
            myplayer.velocity = new Vector2(xmove * speed, ymove * speed);
            xanim = xmove;                //将运动的值赋给动画判定的值。
            yanim = ymove;
 
        }
        else
        {
            //playerani.SetBool("iswalking", false);
            xanim = 0;                //将运动的值赋给动画判定的值。
            yanim = 0;
            myplayer.velocity = new Vector2(xmove * speed, ymove * speed);
        }
 
 
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
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
    public bool canMove = true;
    void Start()
    {
        myplayer = this.gameObject.GetComponent<Rigidbody2D>();
        playerani = this.gameObject.GetComponent<Animator>();
 
    }
 
    void Update()
    {
        if(canMove)
        {

        
        xmove = Input.GetAxisRaw("Horizontal"); //得到用户输入值
        ymove = Input.GetAxisRaw("Vertical");
        //playerani.SetFloat("xinput", xanim);   //用该变量来判定动画如何的切换。
        //playerani.SetFloat("yinput", yanim);   
        Vector2 vector = new Vector2(xmove, ymove);
 
        movement(vector);
        }
    }
 
    private void movement(Vector2 vec)
    {
        if (vec != Vector2.zero)          //判定是否在运动
        {
            //playerani.SetBool("iswalking", true);
            myplayer.velocity = new Vector2(xmove * speed, ymove * speed);
            xanim = xmove;                //将运动的值赋给动画判定的值。
            yanim = ymove;
 
        }
        else
        {
            //playerani.SetBool("iswalking", false);
            myplayer.velocity = new Vector2(xmove * speed, ymove * speed);
        }
 
 
    }
}

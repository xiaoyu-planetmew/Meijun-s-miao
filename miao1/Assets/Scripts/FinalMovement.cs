using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Spine.Unity;
using Spine;
using System.Runtime.CompilerServices;
using UnityEngine.Events;
using Cinemachine;

public class FinalMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D coll;
    public Animator anim;

    public float speed, jumpForce;
    private float horizontalMove;
    public Transform groundCheck;
    public LayerMask ground;
    
    public bool isGround, isJump, isDashing;
    public AudioSource walk;
    public AudioSource run;

    bool jumpPressed;
    bool outside;
    int jumpCount;
    public bool otherAnim = false;
    public bool running;
    public bool walking;
    public bool moving;
    public bool canMove = true;
    //public Canvas playerCanvas;
    
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        if(anim == null)
        {
            anim = this.transform.GetChild(0).GetComponent<Animator>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && jumpCount > 0)
        {
            //jumpPressed = true;
        }
        /*
        if(running)
        {
            run.Play();
        }
        if(walking)
        {
            walk.Play();
        }
        
        if(!moving && running)
        {
            walk.Stop();
            run.Play();
            moving = true;
        }
        if (!moving && walking)
        {
            run.Stop();
            walk.Play();
            moving = true;
        }*/
        if (!moving)
        {
            
            if(running)
            {
                //walk.Stop();
                run.Play();
                moving = true;
            }
            if(walking)
            {
                //run.Stop();
                walk.Play();
                moving = true;
            }
            if (!running)
            {
                run.Stop();
            }
            if(!walking)
            {
                walk.Stop();
            }
        }
        if (!running && !walking)
            {
                moving = false;
            }
        if(this.transform.Find("ChracterNew")) SpineStateMachine();
        
    }
    public void stopSound()
    {
        /*
        moving = false;
        running = false;
        walking = false;
        run.Stop();
        walk.Stop();
        */
        StopAllCoroutines();
        StartCoroutine(moveDelay());
    }
    IEnumerator moveDelay()
    {
        changeCanMove(false);
        yield return new WaitForSeconds(1f);
        changeCanMove(true);
    }
    public void SpineStateMachine()
    {
        if (Mathf.Abs(horizontalMove) <= 0.001 && !otherAnim && this.transform.Find("ChracterNew").GetComponent<SkeletonAnimation>().AnimationName != "idle")
        {
            ChracterNewAnim("idle", true);
        }
        if (Mathf.Abs(horizontalMove) >= 0.001 && outside && this.transform.Find("ChracterNew").GetComponent<SkeletonAnimation>().AnimationName != "run")
        {
            ChracterNewAnim("run", true);
        }
        if (Mathf.Abs(horizontalMove) >= 0.001 && !outside && this.transform.Find("ChracterNew").GetComponent<SkeletonAnimation>().AnimationName != "walk")
        {
            ChracterNewAnim("walk", true);
        }
    }
    public void ChracterNewAnim(string animationName, bool loop)
    {
        if(this.transform.Find("ChracterNew"))
        {
            SkeletonAnimation skeletonAnimation;   //gameobject的component。
            skeletonAnimation = this.transform.Find("ChracterNew").GetComponent<SkeletonAnimation>();
            if (skeletonAnimation == null) return;
            Spine.AnimationState spineAnimationState = skeletonAnimation.state;
            Spine.Skeleton skeleton;
            skeletonAnimation.skeleton.SetToSetupPose();
            spineAnimationState.ClearTracks();
            spineAnimationState.SetAnimation(0, animationName, loop);
        }
    }
    
    public void stopMoving()
    {
        //run.Stop();
        //walk.Stop();
        horizontalMove = 0;
        canMove = false;
        //running = false;
        //walking = false;
    }
    public void continueMoving()
    {
        horizontalMove = 0;
        canMove = true;
    }

    private void FixedUpdate()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position, 0.1f, ground);
        this.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        GroundMovement();
        Jump();
        /*
        if (canMove)
        {

            

            
        }
        if(outside)
        {
            walk.Stop();
        }
        if (!outside)
        {
            run.Stop();
        }
        */
        //SwitchAnim();
        //if(canMove)
        SwitchSpineAnim();
    }

    void GroundMovement()
    {
        //var playing = false;
        if(outside && transform.localScale.y != 0.4f)
        {
            speed = 5;
            transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        }
        if(!outside && transform.localScale.y != 0.6f)
        {
            speed = 3f;
            transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
        }
        //horizontalMove = Input.GetAxisRaw("Horizontal");//只返回-1，0，1

        if(canMove)
        {
        if(Input.GetKey("a"))
        {
            horizontalMove = -1;
        }
        if(Input.GetKey("d"))
        {
            horizontalMove = 1;
        }
        if(!(Input.GetKey("a")) && !(Input.GetKey("d")))
        {
            horizontalMove = 0;
        }
        }else horizontalMove = 0;
        rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);
        var i = transform.GetChild(0).localScale.y;
        if(horizontalMove == -1)
        {
            transform.GetChild(0).localScale = new Vector3(horizontalMove * i, i, i);
            if(transform.Find("ChracterNew"))
            {
                transform.Find("ChracterNew").localScale = new Vector3(horizontalMove * i, i, i);
            }
            this.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            //playerCanvas.scale
            if(outside)
            {
                running = true;
                walking = false;
            }
            if(!outside)
            {
                walking = true;
                running = false;
            }
        }
        if(horizontalMove == 1)
        {
            transform.GetChild(0).localScale = new Vector3(horizontalMove * i, i, i);
            if (transform.Find("ChracterNew"))
            {
                transform.Find("ChracterNew").localScale = new Vector3(horizontalMove * i, i, i);
            }
            this.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            if(outside)
            {
                running = true;
                walking = false;
            }
            if(!outside)
            {
                walking = true;
                running = false;
            }
        }
        if(horizontalMove == 0)
        {
            running = false;
            walking = false;
        }

    }
    public void changeCanMove(bool move)
    {
        horizontalMove = 0;
        canMove = move;
        //run.Stop();
        //walk.Stop();
        if(canMove && GameObject.Find("Main Camera"))
        {
            GameObject.Find("Main Camera").GetComponent<CinemachineBrain>().enabled = true;
        }
    }
    void Jump()//跳跃
    {
        if (isGround)
        {
            jumpCount = 1;//可跳跃数量
            isJump = false;
        }
        if (jumpPressed && isGround)
        {
            isJump = true;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount--;
            jumpPressed = false;
        }
        else if (jumpPressed && jumpCount > 0 && isJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount--;
            jumpPressed = false;
        }
    }
    /*
    void SwitchAnim()//动画切换
    {
        anim.SetFloat("moving", Mathf.Abs(rb.velocity.x));

        if (isGround)
        {
            anim.SetBool("falling", false);
        }
        else if (!isGround && rb.velocity.y > 0)
        {
            anim.SetBool("jumping", true);
        }
        else if (rb.velocity.y < 0)
        {
            anim.SetBool("jumping", false);
            anim.SetBool("falling", true);
        }
    }
    */
    void SwitchSpineAnim()
    {
        
        if(this.transform.position.y < 10 && this.transform.position.y > -10)
        {
            anim.SetBool("outside", true);
            
            outside = true;
        }
        else{
            anim.SetBool("outside", false);
            outside = false;
        }
        anim.SetFloat("moving", Mathf.Abs(horizontalMove));
        //anim.SetFloat("moving", Mathf.Abs(rb.velocity.x));
        //bool turning;
        //var sa = this.transform.GetChild(0).GetComponent<SkeletonAnimation>();
        
        
    }
    private void OnDisable()
    {
        run.Stop();
        walk.Stop();
    }
}

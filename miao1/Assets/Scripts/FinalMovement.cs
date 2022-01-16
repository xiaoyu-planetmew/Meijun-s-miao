using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Spine.Unity;
using Spine;
using System.Runtime.CompilerServices;

public class FinalMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D coll;
    private Animator anim;

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
    public bool running;
    public bool walking;
    public bool moving;
    //public Canvas playerCanvas;
    
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        anim = this.transform.GetChild(0).GetComponent<Animator>();
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
        */
        if(!moving)
        {
            if(running)
            {
                run.Play();
                moving = true;
            }
            if(walking)
            {
                walk.Play();
                moving = true;
            }
            if(!running)
            {
                run.Stop();
            }
            if(!walking)
            {
                walk.Stop();
            }
            
        }
        if(!running && !walking)
            {
                moving = false;
            }
    }

    private void FixedUpdate()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position, 0.1f, ground);
        this.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;

        GroundMovement();

        Jump();


        //SwitchAnim();
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
        
        rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);
        var i = transform.GetChild(0).localScale.y;
        if(horizontalMove == -1)
        {
            transform.GetChild(0).localScale = new Vector3(horizontalMove * i, i, i);
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
}

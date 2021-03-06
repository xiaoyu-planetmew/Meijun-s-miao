using UnityEngine;
using System.Collections;

public class birdMove : MonoBehaviour {
    public int index = 0;                       //从初始位置触发
    public float speed = 0.05f;                 //移动速度
    public Transform[] theWayPoints;          //移动目标点组
    public Transform finalPoint;
    public Transform endPoint;
    private float passedTime; // default 0
    public float intervalTime;  // set time interval
    public bool isFlying;
    public bool isFlyingAni;
    public Item target;
    float scale;
    private bool hungry = false;
    
    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = new Vector3(theWayPoints[0].position.x, theWayPoints[0].position.y, theWayPoints[0].position.z);
        scale = this.transform.localScale.x;
    }
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < GameManager.instance.items.Count; i++)
        {
            
            if(GameManager.instance.items[i] == target)
            {
                hungry = true;                
            }
        }
        if(!hungry)
        {
            if (transform.position != theWayPoints[index].position)
            {
            
                if(transform.position.x < theWayPoints[index].position.x)
                {
                    transform.localScale = new Vector3(-1 * scale, scale, scale);
                }
                if(transform.position.x > theWayPoints[index].position.x)
                {
                    transform.localScale = new Vector3(scale, scale, scale);
                }
                MoveToThePoints();
                isFlying = true;
                if(isFlying && !isFlyingAni)
                {
                    StartCoroutine("fly");
                }
            }
        //到了数组指定index位置,改变index值，不断循环
            else
            {
                if(isFlying && isFlyingAni)
                {
                this.GetComponent<Animator>().SetTrigger("land");
                StopAllCoroutines();
                }
                if(passedTime>intervalTime)
                {
                    index = ++index % theWayPoints.Length;
                    passedTime = 0; //enter next loop
                    
                }
            passedTime += Time.deltaTime;
            isFlying = false;
            isFlyingAni = false;
            }
        }//未达到指定的index位置，调用MoveToThePoints函数每帧继续移动
        else
        {
            if(transform.position.x < finalPoint.position.x)
                {
                    transform.localScale = new Vector3(-1 * scale, scale, scale);
                }
                if(transform.position.x > finalPoint.position.x)
                {
                    transform.localScale = new Vector3(scale, scale, scale);
                }
            Vector2 temp = Vector2.MoveTowards(transform.position, finalPoint.position, speed * Time.deltaTime);
            GetComponent<Rigidbody2D>().MovePosition(temp);
            //isFlying = true;
            if(transform.position == finalPoint.position)
            {
                isFlying = false;
                isFlyingAni = false;
                transform.localScale = new Vector3(scale, scale, scale);
                StopAllCoroutines();
                this.GetComponent<Animator>().ResetTrigger("lift");
                this.GetComponent<Animator>().ResetTrigger("fly");  
                this.GetComponent<Animator>().SetTrigger("land");            
                //this.GetComponent<Animator>().enabled = false;
            }
            if(isFlying)
            {
                this.GetComponent<Animator>().SetTrigger("fly");
            }
            if(!isFlying && !isFlyingAni && !(transform.position == finalPoint.position))
            {
                StartCoroutine("fly");
            }
            
        }
    }
    void MoveToThePoints()
    {
        //从当前位置按照指定速度移到index位置，记得speed * Time.deltaTime，不然会瞬移
        Vector2 temp = Vector2.MoveTowards(transform.position, theWayPoints[index].position, speed * Time.deltaTime);
        //考虑到可能有碰撞检测，所以使用刚体的移动方式
        GetComponent<Rigidbody2D>().MovePosition(temp);
        
    }
    IEnumerator fly()
    {
        this.GetComponent<Animator>().SetTrigger("lift");
        isFlyingAni = true;
        yield return new WaitForSeconds(0.5f);
        this.GetComponent<Animator>().SetTrigger("fly");
    }
    public void flyToTheEnd()
    {
        finalPoint.position = new Vector3(endPoint.position.x, endPoint.position.y, endPoint.position.z);
        this.GetComponent<Animator>().ResetTrigger("land"); 
        isFlying = true;
        if(isFlying && !isFlyingAni)
        {
            StartCoroutine("fly");
        }
        //StartCoroutine("fly");
    }
}
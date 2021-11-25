using UnityEngine;
using System.Collections;

public class birdMove : MonoBehaviour {
    public int index = 0;                       //从初始位置触发
    public float speed = 0.05f;                 //移动速度
    public Transform[] theWayPoints;          //移动目标点组
    public Transform finalPoint;
    private float passedTime; // default 0
    public float intervalTime;  // set time interval
    public bool isFlying;
    public Item target;
    private bool hungry = false;
    // Start is called before the first frame update
    void Start()
    {
        
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
                    transform.localScale = new Vector3(-1, 1, 1);
                }
                if(transform.position.x > theWayPoints[index].position.x)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }
                MoveToThePoints();
                isFlying = true;
              
            }
        //到了数组指定index位置,改变index值，不断循环
            else
            {
                if(passedTime>intervalTime)
                {
                    index = ++index % theWayPoints.Length;
                    passedTime = 0; //enter next loop
                }
            passedTime += Time.deltaTime;
            isFlying = false;
            }
        }//未达到指定的index位置，调用MoveToThePoints函数每帧继续移动
        else
        {
            if(transform.position.x < finalPoint.position.x)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }
                if(transform.position.x > finalPoint.position.x)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }
            Vector2 temp = Vector2.MoveTowards(transform.position, finalPoint.position, speed * Time.deltaTime);
            GetComponent<Rigidbody2D>().MovePosition(temp);
            if(transform.position == finalPoint.position)
            {
                transform.localScale = new Vector3(1, 1, 1);
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
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class cookingControl : MonoBehaviour
{
    public GameObject scrollBar;
    public GameObject target;
    public float speed = 0.01f;
    public bool moving = true;
    private bool movingRight = true;
    [SerializeField] float leftEdge;
    [SerializeField] float rightEdge;
    public UnityEvent succeedEvent;
    public UnityEvent failedEvent;
    // Start is called before the first frame update
    void Start()
    {
        cook1();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) 
        hit();
        
    }
    void FixedUpdate()
    {
        if(moving) handleMove();    
    }
    public void cook1()
    {
        float r = Random.Range(75f, 500f);
        float w = Random.Range(100f, 300f);
        target.GetComponent<RectTransform>().anchoredPosition = new Vector2(r, 0);
        target.GetComponent<RectTransform>().sizeDelta = new Vector2(w, 70);
        moving = true;
        scrollBar.GetComponent<Scrollbar>().value = 0f;
        
        leftEdge = (target.GetComponent<RectTransform>().anchoredPosition.x - 40) / 800f;
        rightEdge = (target.GetComponent<RectTransform>().anchoredPosition.x + w - 10) / 800f;
    }
    void handleMove()
    {
        if(movingRight)
        {
            //我正在右移
            scrollBar.GetComponent<Scrollbar>().value += speed * Time.deltaTime;
            //.Translate(Vector3.right * speed * Time.deltaTime);
 
            //如果我移到了5，那么接下来就是左移，所以把右移设为false
            if (scrollBar.GetComponent<Scrollbar>().value >= 0.95f)
            {
                movingRight = false;
            }
        }
        else
        {
            //当我在左移，而且x轴坐标到了-5，说明结束左移，开始右移
            scrollBar.GetComponent<Scrollbar>().value -= speed * Time.deltaTime;
 
            //左移结束，右移开始，设置状态为true
            if (scrollBar.GetComponent<Scrollbar>().value <= 0f)
            {
                movingRight = true;
            }
        }
    }
    public void hit()
    {
        
        if(scrollBar.GetComponent<Scrollbar>().value >= leftEdge && scrollBar.GetComponent<Scrollbar>().value <= rightEdge)
        {
            moving = false;
            Debug.Log("success");
            if(succeedEvent != null)
            {
                succeedEvent.Invoke();
            }
        }else 
        {
            moving = false;
            Debug.Log("failed");
            if(failedEvent != null)
            {
                failedEvent.Invoke();
            }
        }
    }
}

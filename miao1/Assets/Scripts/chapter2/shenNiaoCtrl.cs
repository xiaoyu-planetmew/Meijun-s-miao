using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using DG.Tweening;


public class shenNiaoCtrl : MonoBehaviour
{
    public int setStart;
    public int setEnd;
    public int speed;
    public GameObject guang1;
    public GameObject guang2;
    public List<Button> timeButtons = new List<Button>();
    public List<GameObject> yumaoOffs = new List<GameObject>();
    public List<GameObject> yumaoOns = new List<GameObject>();
    public List<GameObject> circle1Off = new List<GameObject>();
    public List<GameObject> circle1On = new List<GameObject>();
    public List<GameObject> circle2Off = new List<GameObject>();
    public List<GameObject> circle2On= new List<GameObject>();
    public List<GameObject> circle3Off = new List<GameObject>();
    public List<GameObject> circle3On= new List<GameObject>();
    public List<int> c1On = new List<int>();
    public List<int> c2On = new List<int>();
    public List<int> c3On = new List<int>();
    public int nowStart = -1;
    public int SEInterval = 4;
    public UnityEvent succeedEvent;

    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<12; i++)
        {
            circle1Off[i].GetComponent<Image>().alphaHitTestMinimumThreshold = 0.1f;
            circle1On[i].GetComponent<Image>().alphaHitTestMinimumThreshold = 0.1f;
            circle2Off[i].GetComponent<Image>().alphaHitTestMinimumThreshold = 0.1f;
            circle2On[i].GetComponent<Image>().alphaHitTestMinimumThreshold = 0.1f;
            circle3Off[i].GetComponent<Image>().alphaHitTestMinimumThreshold = 0.1f;
            circle3On[i].GetComponent<Image>().alphaHitTestMinimumThreshold = 0.1f;
        }
    }
    public void timeAct(int t)
    {
        Debug.Log(t);
        Debug.Log(Mathf.Abs(t - nowStart));
        Debug.Log(12 - Mathf.Max(t, nowStart) + Mathf.Min(t, nowStart));
        if (nowStart == -1)
        {
            nowStart = t;
            yumaoOffs[t].SetActive(false);
            yumaoOns[t].SetActive(true);
        }
        if(nowStart != -1 && nowStart != t)
        {
            if(Mathf.Abs(t - nowStart) <= SEInterval)
            {
                for(int i = 0; i < yumaoOffs.Count; i++)
                {
                    yumaoOffs[i].SetActive(true);
                    yumaoOns[i].SetActive(false);
                    if ((i<=t && i>=nowStart) || (i<=nowStart && i>=t))
                    {
                        yumaoOffs[i].SetActive(false);
                        yumaoOns[i].SetActive(true);
                    }
                }
            }
            if((Mathf.Abs(t - nowStart) >= SEInterval) && ((12 - Mathf.Max(t, nowStart) + Mathf.Min(t, nowStart)) <=SEInterval))
            {
                //Debug.Log(t + (12 - nowStart));
                for(int i=0; i < yumaoOffs.Count; i++)
                {
                    yumaoOffs[i].SetActive(true);
                    yumaoOns[i].SetActive(false);
                    if (t < nowStart)
                    {
                        if(i<=t || i >= nowStart)
                        {
                            yumaoOffs[i].SetActive(false);
                            yumaoOns[i].SetActive(true);
                        }
                    }
                    if (t > nowStart)
                    {
                        if (i >= t || i <= nowStart)
                        {
                            yumaoOffs[i].SetActive(false);
                            yumaoOns[i].SetActive(true);
                        }
                    }
                }
            }
            if ((Mathf.Abs(t - nowStart) >= SEInterval) && ((12 - Mathf.Max(t, nowStart) + Mathf.Min(t, nowStart)) >= SEInterval))
            {
                clearAll();
            }
        }
        if(((t == setStart) && (nowStart == setEnd)) || ((t == setEnd) && (nowStart == setStart)))
        {
            //Debug.Log("succeed");
            succeedEvent.Invoke();
        }
    }
    public void act(int m, int n)
    {
        if(m == 1)
        {
            if(c1On.Count < 5)
            {
                c1On.Add(n);
            }else
            {
                //circle1On[c1On[0]].SetActive(false);
                c1On[0] = c1On[1];
                c1On[1] = c1On[2];
                c1On[2] = c1On[3];
                c1On[3] = n;
                for(int i=0; i<12; i++)
                {
                    if(c1On.Contains(i))
                    {
                        circle1On[i].SetActive(true);
                        circle1Off[i].SetActive(false);
                    }else
                    {
                        circle1On[i].SetActive(false);
                        circle1Off[i].SetActive(true);
                    }
                }
            }
        }
        if(m == 2)
        {
            if(c2On.Count < 5)
            {
                c2On.Add(n);
            }else
            {
                c2On[0] = c2On[1];
                c2On[1] = c2On[2];
                c2On[2] = c2On[3];
                c2On[3] = n;
                for(int i=0; i<12; i++)
                {
                    if(c2On.Contains(i))
                    {
                        circle2On[i].SetActive(true);
                        circle2Off[i].SetActive(false);
                    }else
                    {
                        circle2On[i].SetActive(false);
                        circle2Off[i].SetActive(true);
                    }
                }
            }
        }
        if(m == 3)
        {
            if(c3On.Count < 5)
            {
                c3On.Add(n);
            }else
            {
                c3On[0] = c3On[1];
                c3On[1] = c3On[2];
                c3On[2] = c3On[3];
                c3On[3] = n;
            }
                for(int i=0; i<12; i++)
                {
                    if(c3On.Contains(i))
                    {
                        circle3On[i].SetActive(true);
                        circle3Off[i].SetActive(false);
                    }else
                    {
                        circle3On[i].SetActive(false);
                        circle3Off[i].SetActive(true);
                    }
                }
        }
    }
    public void down1(int n)
    {
        n = 11-n;
        //c1On.Remove(n);
        for(int i=0; i<c1On.Count; i++)
        {
            if(c1On[i] == n)
            {
                c1On.RemoveAt(i);
            }
        }
        for(int i=0; i<12; i++)
                {
                    if(c1On.Contains(i))
                    {
                        circle1On[i].SetActive(true);
                        circle1Off[i].SetActive(false);
                    }else
                    {
                        circle1On[i].SetActive(false);
                        circle1Off[i].SetActive(true);
                    }
                }
    }
    public void down2(int n)
    {
        n = 11-n;
        for(int i=0; i<c2On.Count; i++)
        {
            if(c2On[i] == n)
            {
                c2On.RemoveAt(i);
            }
        }
        for(int i=0; i<12; i++)
                {
                    if(c2On.Contains(i))
                    {
                        circle2On[i].SetActive(true);
                        circle2Off[i].SetActive(false);
                    }else
                    {
                        circle2On[i].SetActive(false);
                        circle2Off[i].SetActive(true);
                    }
                }
    }
    public void down3(int n)
    {
        n = 11-n;
        Debug.Log(n);
        for(int i=0; i<c3On.Count; i++)
        {
            if(c3On[i] == n)
            {
                c3On.RemoveAt(i);
                Debug.Log(i);
            }
        }
        for(int i=0; i<12; i++)
                {
                    if(c3On.Contains(i))
                    {
                        circle3On[i].SetActive(true);
                        circle3Off[i].SetActive(false);
                    }else
                    {
                        circle3On[i].SetActive(false);
                        circle3Off[i].SetActive(true);
                    }
                }
    }
    
    public void act1(int n)
    {
        n = 11-n;
         if(c1On.Count < 1)
            {
                c1On.Add(n);
            }else
            {
                //circle1On[c1On[0]].SetActive(false);
                c1On[0] = n;
                
            }
            for(int i=0; i<12; i++)
                {
                    if(c1On.Contains(i))
                    {
                        circle1On[i].SetActive(true);
                        circle1Off[i].SetActive(false);
                    }else
                    {
                        circle1On[i].SetActive(false);
                        circle1Off[i].SetActive(true);
                    }
                }
        if(c1On[0] == 7 && c2On[0] == 8 && (c3On.Contains(7) && c3On.Contains(8) && c3On.Contains(9))) succeedEvent.Invoke();
    }
    public void act2(int n)
    {
        n = 11-n;
        if(c2On.Count < 1)
            {
                c2On.Add(n);
            }else
            {
                c2On[0] = n;
                
            }
            for(int i=0; i<12; i++)
                {
                    if(c2On.Contains(i))
                    {
                        circle2On[i].SetActive(true);
                        circle2Off[i].SetActive(false);
                    }else
                    {
                        circle2On[i].SetActive(false);
                        circle2Off[i].SetActive(true);
                    }
                }
                if(c1On[0] == 7 && c2On[0] == 8 && (c3On.Contains(7) && c3On.Contains(8) && c3On.Contains(9))) succeedEvent.Invoke();
    }
    public void act3(int n)
    {
        n = 11-n;
        if(c3On.Count < 3)
            {
                c3On.Add(n);
            }else
            {
                c3On[0] = c3On[1];
                c3On[1] = c3On[2];
                c3On[2] = n;
            }
            for(int i=0; i<12; i++)
                {
                    if(c3On.Contains(i))
                    {
                        circle3On[i].SetActive(true);
                        circle3Off[i].SetActive(false);
                    }else
                    {
                        circle3On[i].SetActive(false);
                        circle3Off[i].SetActive(true);
                    }
                }
                if(c1On[0] == 7 && c2On[0] == 8 && (c3On.Contains(7) && c3On.Contains(8) && c3On.Contains(9))) succeedEvent.Invoke();
                
    }
    public void succeed()
    {
        succeedEvent.Invoke();
    }
    public void clearAll()
    {
        nowStart = -1;
        for (int i = 0; i < yumaoOffs.Count; i++)
        {
            yumaoOffs[i].SetActive(true);
            yumaoOns[i].SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        guang1.transform.Rotate(Vector3.forward*Time.deltaTime*speed);
        guang2.transform.Rotate(Vector3.forward*Time.deltaTime*speed*-1f);
    }
}

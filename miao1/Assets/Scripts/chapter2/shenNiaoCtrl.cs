using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class shenNiaoCtrl : MonoBehaviour
{
    public int setStart;
    public int setEnd;
    public List<Button> timeButtons = new List<Button>();
    public List<GameObject> yumaoOffs = new List<GameObject>();
    public List<GameObject> yumaoOns = new List<GameObject>();
    public int nowStart = -1;
    public int SEInterval = 4;
    // Start is called before the first frame update
    void Start()
    {
        
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
            Debug.Log("succeed");
        }
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
        
    }
}

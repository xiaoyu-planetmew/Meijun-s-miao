using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickProcess : MonoBehaviour
{
    public float Ping = 2;
    private bool IsStart = false;
    private float LastTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsStart && Ping > 0 && LastTime > 0 && Time.time - LastTime > Ping)
        {
            Debug.Log("长按触发");
            IsStart = false;
            LastTime = 0;
        }
    }

    public void Click(bool bStart)
    {
        IsStart = bStart;
        if (IsStart)
        {
            LastTime = Time.time;
            Debug.Log("长按开始");

        }
        else if (LastTime != 0)
        {
            LastTime = 0;
            Debug.Log("长按取消");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleProcess : MonoBehaviour
{
    private bool IsStart = false;

    public Transform process;
    public Transform indicator;

    public int targetProcess = 2;
    private float currentAmout = 0;
  
    void Update()
    {
        if (currentAmout < targetProcess)
        {
            if (IsStart)
            {
                currentAmout += Time.deltaTime;
                Process();
            }
            else
            {
                currentAmout -= Time.deltaTime;
                Process();
            }
        }
        else
        {
            indicator.GetComponent<Text>().text = "激活成功";
        }
    }
    public void Process()
    {
        indicator.GetComponent<Text>().text = ((int)(currentAmout * 50)).ToString() + "%";
        process.GetComponent<Image>().fillAmount = currentAmout / 2.0f;
        if (currentAmout > targetProcess)
            currentAmout = targetProcess;
        if (currentAmout<0)
            currentAmout = 0;
    }

    public void Clickprocess(bool bStart)
    {
        IsStart = bStart;
    }

}

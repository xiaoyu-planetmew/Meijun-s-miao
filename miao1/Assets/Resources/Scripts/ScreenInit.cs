using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenInit : MonoBehaviour
{
    private void Awake()
    {
        //Camera.main.fieldOfView是用来设置摄像机视野的大小

        float targetHight = 1920.0f;
        if (1080*Screen.height>1920*Screen.width)
        {
            targetHight = 1080f * Screen.height / Screen.width;
        }
        Camera.main.fieldOfView *= (targetHight/1920.0f);
    }
}
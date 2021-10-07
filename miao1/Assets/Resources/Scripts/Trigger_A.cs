using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_A : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(Time.time + ":进入该触发器的对象是：" + other.gameObject.name);
    }
    void OnTriggerStay(Collider other)    //每帧调用一次OnTriggerStay()函数
    {
        Debug.Log(Time.time + "留在触发器的对象是：" + other.gameObject.name);
    }
    void OnTriggerExit(Collider other)
    {
        Debug.Log(Time.time + "离开触发器的对象是：" + other.gameObject.name);
    }
}
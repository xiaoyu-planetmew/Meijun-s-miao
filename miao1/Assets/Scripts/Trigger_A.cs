using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_A : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(Time.time + ":����ô������Ķ����ǣ�" + other.gameObject.name);
    }
    void OnTriggerStay(Collider other)    //ÿ֡����һ��OnTriggerStay()����
    {
        Debug.Log(Time.time + "���ڴ������Ķ����ǣ�" + other.gameObject.name);
    }
    void OnTriggerExit(Collider other)
    {
        Debug.Log(Time.time + "�뿪�������Ķ����ǣ�" + other.gameObject.name);
    }
}
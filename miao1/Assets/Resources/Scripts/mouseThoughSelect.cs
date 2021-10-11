using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseThoughSelect : MonoBehaviour
{
    //2.参数hitInfo 为out类型，可得到碰撞检测的返回值；
    RaycastHit hit;
 
    //4.参数layerMask 在指定层上碰撞检测(注意是public，不然在脚本属性那儿找不到指定的层，坑)
    public LayerMask clickableLayer;
 
    void Update()
    {  
        //1.参数ray 为射线碰撞检测的光线(返回一个从相机到屏幕鼠标位置的光线)
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if ((Physics.Raycast(ray, out hit, 50, clickableLayer.value)) && (Input.GetMouseButtonDown(0))) //如果碰撞检测到物体
        {
           //Debug.Log(hit.collider.gameObject.name);//打印鼠标点击到的物体名称
           GameObject.Find(hit.collider.gameObject.name).GetComponent<PickupItem>().pickUp();
        }
        
    }
}
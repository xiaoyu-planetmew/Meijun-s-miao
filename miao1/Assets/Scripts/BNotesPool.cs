using System.Collections.Generic;
using UnityEngine;

public class BNotesPool : MonoBehaviour
{
    public static BNotesPool BNotesPoolInstance;      //子弹池单例
    public GameObject bulletObj;                        //子弹perfabs
    public int pooledAmount = 5;                        //子弹池初始大小
    public bool lockPoolSize = false;                   //是否锁定子弹池大小

    private List<GameObject> pooledObjects;             //子弹池链表

    private int currentIndex = 0;                       //当前指向链表位置索引
    public GameObject notes;

    void Awake()
    {
        BNotesPoolInstance = this;                     //把本对象作为实例。
    }

    void Start()
    {
        pooledObjects = new List<GameObject>();         //初始化链表
        for (int i = 0; i < pooledAmount; ++i)
        {
            GameObject obj = Instantiate(bulletObj);    //创建子弹对象
            obj.transform.parent = notes.transform;
            //obj.transform.SetParent(notes.transform, false);
            obj.SetActive(false);                       //设置子弹无效
            pooledObjects.Add(obj);                     //把子弹添加到链表（对象池）中
        }
    }

    public GameObject GetPooledObject()                 //获取对象池中可以使用的子弹。
    {
        for (int i = 0; i < pooledObjects.Count; ++i)   //把对象池遍历一遍
        {
            //这里简单优化了一下，每一次遍历都是从上一次被使用的子弹的下一个，而不是每次遍历从0开始。
            //例如上一次获取了第4个子弹，currentIndex就为5，这里从索引5开始遍历，这是一种贪心算法。
            int temI = (currentIndex + i) % pooledObjects.Count;
            if (!pooledObjects[temI].activeInHierarchy) //判断该子弹是否在场景中激活。
            {
                currentIndex = (temI + 1) % pooledObjects.Count;
                return pooledObjects[temI];             //找到没有被激活的子弹并返回
            }
        }


        //如果遍历完一遍子弹库发现没有可以用的，执行下面
        if(!lockPoolSize)                               //如果没有锁定对象池大小，创建子弹并添加到对象池中。
        {
            GameObject obj = Instantiate(bulletObj);
            obj.transform.parent = notes.transform;
            //obj.transform.SetParent(notes.transform, false);
            pooledObjects.Add(obj);
            return obj;
        }

        //如果遍历完没有而且锁定了对象池大小，返回空。
        return null;
    }

}
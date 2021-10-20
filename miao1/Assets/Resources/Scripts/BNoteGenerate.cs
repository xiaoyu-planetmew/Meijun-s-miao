using UnityEngine;

public class BNoteGenerate : MonoBehaviour
{
    //传统创建子弹方法需要的子弹perfabs
    //public GameObject shotObj;

    public GameObject shotSpawn;                //子弹发射的初始化位置

    public float fireRate = 0.2f;               //每次发射子弹事件间隔

    private float nextFire;                     //下一次发射子弹的时间
    public GameObject line1;

    void Update()
    {
        if (Time.time > nextFire)               //可以发射子弹时间
        {
            nextFire = Time.time + fireRate;

            //传统创建子弹方法
            //Instantiate(shotObj, shotSpawn.transform.position, shotSpawn.transform.rotation);

            //获取对象池中的子弹
            GameObject bullet = BRhythmManager.instance.GetPooledObject();
            if(bullet != null)                  //不为空时执行
            {
                bullet.SetActive(true);         //激活子弹并初始化子弹的位置
                bullet.transform.position = shotSpawn.transform.position;
                bullet.GetComponent<DrawBesizerLine>().line = line1;
            }
        }
    }
}
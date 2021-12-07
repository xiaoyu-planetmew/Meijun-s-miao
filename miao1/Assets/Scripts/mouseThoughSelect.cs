using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mouseThoughSelect : MonoBehaviour
{
    //2.参数hitInfo 为out类型，可得到碰撞检测的返回值；
    RaycastHit hit;
    public GameObject cams;
    [SerializeField] private List<Transform> camList = new List<Transform>();
    //[SerializeField] private Camera cam;
 
    //4.参数layerMask 在指定层上碰撞检测(注意是public，不然在脚本属性那儿找不到指定的层，坑)
    public LayerMask clickableLayer;
    public GameObject player;
    public float pickUpDistance;
    public GameObject tip;
    public string warningText;
    public float warningTime;
    void Awake()
    {
        Scene scene = SceneManager.GetActiveScene ();
        if(scene.name == "SampleScene")
        {
            cams = GameObject.Find("Cameras");
        }
        foreach(Transform i in cams.transform)
        {
            camList.Add(i);
        }
    }
    void OnEnable()
    {
        Scene scene = SceneManager.GetActiveScene ();
        if(scene.name == "SampleScene")
        {
            cams = GameObject.Find("Cameras");
        }
        for(int i = 0; i < camList.Count; i++)
        {
            camList[i] = cams.transform.GetChild(i);
        }
    }
 
    void Update()
    {
        
        if(cams.activeInHierarchy)
        {
            var cam = Camera.main;
        for(int i = 0; i < camList.Count; i++)
        {
            if(camList[i].gameObject.activeInHierarchy)
            {
                cam = camList[i].gameObject.GetComponent<Camera>();
                tip.transform.parent.gameObject.GetComponent<Canvas>().worldCamera = cam;
            }
        } 
        //1.参数ray 为射线碰撞检测的光线(返回一个从相机到屏幕鼠标位置的光线)
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        
        if ((Physics.Raycast(ray, out hit, 50, clickableLayer.value)) && (Input.GetMouseButtonDown(0))) //如果碰撞检测到物体
        {
           //Debug.Log(hit.collider.gameObject.name);//打印鼠标点击到的物体名称
           if((GameObject.Find(hit.collider.gameObject.name).transform.position - player.transform.position).magnitude <= pickUpDistance)
           {
               GameObject.Find(hit.collider.gameObject.name).GetComponent<PickupItem>().pickUp();
           }
           if((GameObject.Find(hit.collider.gameObject.name).transform.position - player.transform.position).magnitude > pickUpDistance)
           {
               tip.SetActive(true);
               tip.transform.Find("tipText").GetComponent<Text>().text = warningText;
               StartCoroutine("warningClose");
            
           }
        }
        }
        
        
    }
    IEnumerator warningClose()
    {
        yield return new WaitForSeconds(warningTime);
        tip.SetActive(false);
    }
}
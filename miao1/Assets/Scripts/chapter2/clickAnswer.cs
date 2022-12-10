using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class clickAnswer : MonoBehaviour, IPointerClickHandler
{
    public UnityEvent afterClick;
    RaycastHit hit;
    public GameObject cams;
    [SerializeField] private List<Transform> camList = new List<Transform>();
    //[SerializeField] private Camera cam;

    //4.参数layerMask 在指定层上碰撞检测(注意是public，不然在脚本属性那儿找不到指定的层，坑)
    public LayerMask clickableLayer;
    // Start is called before the first frame update
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "SampleScene" || scene.name == "Scene2")
        {
            cams = GameObject.Find("Cameras");
        }
        foreach (Transform i in cams.transform)
        {
            camList.Add(i);
        }
    }
    void OnEnable()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "SampleScene" || scene.name == "Scene2")
        {
            cams = GameObject.Find("Cameras");
        }
        for (int i = 0; i < camList.Count; i++)
        {
            camList[i] = cams.transform.GetChild(i);
        }
    }
    // Update is called once per frame
    void Update()
    {
        /*
        if (cams != null)
        {


            if (cams.activeInHierarchy)
            {
                var cam = Camera.main;
                for (int i = 0; i < camList.Count; i++)
                {
                    if (camList[i].gameObject.activeInHierarchy)
                    {
                        cam = camList[i].gameObject.GetComponent<Camera>();
                    }
                }
                //1.参数ray 为射线碰撞检测的光线(返回一个从相机到屏幕鼠标位置的光线)
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);

                if ((Physics.Raycast(ray, out hit, 50, clickableLayer.value)) && (Input.GetMouseButtonDown(0)) && (hit.collider.gameObject == this)) //如果碰撞检测到物体
                {
                    Debug.Log(hit.collider.gameObject.name);
                    if (afterClick != null)
                    {
                        afterClick.Invoke();
                    }
                }
            }
        }
        */
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (afterClick != null)
        {
            afterClick.Invoke();
        }
    }
}

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

    //4.����layerMask ��ָ��������ײ���(ע����public����Ȼ�ڽű������Ƕ��Ҳ���ָ���Ĳ㣬��)
    public LayerMask clickableLayer;
    // Start is called before the first frame update
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        if ((scene.name == "SampleScene" || scene.name == "Scene2") && (cams == null))
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
        if ((scene.name == "SampleScene" || scene.name == "Scene2") && (cams == null))
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
                //1.����ray Ϊ������ײ���Ĺ���(����һ�����������Ļ���λ�õĹ���)
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);

                if ((Physics.Raycast(ray, out hit, 50, clickableLayer.value)) && (Input.GetMouseButtonDown(0)) && (hit.collider.gameObject == this)) //�����ײ��⵽����
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

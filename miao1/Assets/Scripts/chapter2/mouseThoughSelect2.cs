using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mouseThoughSelect2 : MonoBehaviour
{
    //2.����hitInfo Ϊout���ͣ��ɵõ���ײ���ķ���ֵ��
    RaycastHit hit;
    public GameObject cams;
    [SerializeField] private List<Transform> camList = new List<Transform>();
    //[SerializeField] private Camera cam;

    //4.����layerMask ��ָ��������ײ���(ע����public����Ȼ�ڽű������Ƕ��Ҳ���ָ���Ĳ㣬��)
    public LayerMask clickableLayer;
    public GameObject player;
    public float pickUpDistance;
    public GameObject tip;
    public string warningTextJ;
    public string warningTextE;
    public string warningTextCN;
    public float warningTime;
    void Awake()
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
        if(player == null)
        {
            player = GameManager2.instance.player;
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
        if (player == null)
        {
            player = GameManager2.instance.player;
        }
    }

    void Update()
    {
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
                        tip.transform.parent.gameObject.GetComponent<Canvas>().worldCamera = cam;
                    }
                }
                //1.����ray Ϊ������ײ���Ĺ���(����һ�����������Ļ���λ�õĹ���)
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);

                if ((Physics.Raycast(ray, out hit, 50, clickableLayer.value)) && (Input.GetMouseButtonDown(0))) //�����ײ��⵽����
                {
                    //Debug.Log(hit.collider.gameObject.name);//��ӡ�����������������
                    if ((GameObject.Find(hit.collider.gameObject.name).transform.position - player.transform.position).magnitude <= pickUpDistance)
                    {
                        GameObject.Find(hit.collider.gameObject.name).GetComponent<PickupItem>().pickUp();
                    }
                    if ((GameObject.Find(hit.collider.gameObject.name).transform.position - player.transform.position).magnitude > pickUpDistance)
                    {
                        tip.SetActive(true);
                        if (GameManager2.instance.languageNum == 0)
                        {
                            tip.transform.Find("tipText").GetComponent<Text>().text = warningTextJ;
                        }
                        if (GameManager2.instance.languageNum == 1)
                        {
                            tip.transform.Find("tipText").GetComponent<Text>().text = warningTextE;
                        }
                        if (GameManager2.instance.languageNum == 2)
                        {
                            tip.transform.Find("tipText").GetComponent<Text>().text = warningTextCN;
                        }
                        //
                        StartCoroutine("warningClose");

                    }
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
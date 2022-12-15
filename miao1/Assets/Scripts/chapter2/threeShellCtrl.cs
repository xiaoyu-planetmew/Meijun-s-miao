using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Linq;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class threeShellCtrl : MonoBehaviour
{
    public UnityEvent succeedEvent;
    public UnityEvent failedEvent;
    public GameObject tip;
    public GameObject restartChoose;
    public string warningTextJ;
    public string warningTextE;
    public string warningTextCN;
    public float warningTime;
    public int pearlPos;
    public Sprite shellOff;
    public Sprite shellOn;
    public GameObject startPearl;
    public GameObject pearl;
    public GameObject realPearl;
    public List<Vector3> shellPos = new List<Vector3>();
    public List<GameObject> shells = new List<GameObject>();
    public Transform pathPoint1;
    public Transform pathPoint2;
    public Transform[] pos;
    public int[] nowPos = {0, 1, 2};
    public int nowTimes;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void jumpRandomInvoke()
    {
        pearlPos = 1;
        shellStart();
        nowTimes = 0;
    }
    public void shellGameInvoke()
    {
        pearlPos = Random.Range(0, 3);
        shellStart();
        nowTimes = 0;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void shellStart()
    {
        for(int i=0; i<shells.Count; i++)
        {
            shells[i].transform.localPosition = shellPos[i];
            shells[i].GetComponent<SpriteRenderer>().sprite = shellOff;
        }
        pearl.transform.localPosition = shellPos[pearlPos];
        shells[pearlPos].GetComponent<SpriteRenderer>().sprite = shellOn;
        pearl.SetActive(true);
        nowPos[0] = 0;
        nowPos[1] = 1;
        nowPos[2] = 2;
        pos[0].GetComponent<BoxCollider2D>().enabled = false;
        pos[2].GetComponent<BoxCollider2D>().enabled = false;
        pos[4].GetComponent<BoxCollider2D>().enabled = false;
        StartCoroutine(shellStartRolling());
    }
    IEnumerator shellStartRolling()
    {
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < shells.Count; i++)
        {
            shells[i].transform.localPosition = shellPos[i];
            shells[i].GetComponent<SpriteRenderer>().sprite = shellOff;
        }
        pearl.SetActive(false);
        StartCoroutine(shellRoll(Random.Range(3, 6)));
    }/*
    public void shellRoll(int times)
    {
        for(int i=0; i<times; i++)
        {
            int a = Random.Range(0, 3);
            int b = Random.Range(0, 3);
            while(a == b)
            {
                b = Random.Range(0, 3);
            }
            Debug.Log(a);
            Debug.Log(b);
            shellRollUnit(a, b);
        }
    }*/
    IEnumerator shellRoll(int times)
    {
        Debug.Log("times");
        Debug.Log(times);
        while (nowTimes < times)
        {
            yield return new WaitForSeconds(2.5f);
            int a = Random.Range(0, 3);
            int b = Random.Range(0, 3);
            while (a == b)
            {
                b = Random.Range(0, 3);
            }
            Debug.Log("a");
            Debug.Log(a);
            Debug.Log("b");
            Debug.Log(b);
            shellRollUnit(a, b);
            nowTimes++;
        }
        shellRollFinish();
    }
    public void shellRollUnit(int a, int b)
    {
        for(int i=0; i<shells.Count; i++)
        {

        }
        if(a == 0 && b == 1)
        {
            Vector3[] positionsA = { pos[0].localPosition, pos[1].localPosition, pos[2].localPosition };
            Vector3[] positionsB = { pos[2].localPosition, pos[0].localPosition };
            Sequence quence = DOTween.Sequence();
            shells[nowPos[a]].transform.DOLocalPath(positionsA, 2, PathType.CatmullRom, PathMode.Full3D, 50).SetOptions(false);
            shells[nowPos[b]].transform.DOLocalPath(positionsB, 2, PathType.CatmullRom, PathMode.Full3D, 50).SetOptions(false);
            if (pearlPos == 0)
            {
                pearlPos = 1;
            }else if(pearlPos == 0)
            {
                pearlPos = 0;
            }
            
            var c = nowPos[a];
            nowPos[a] = nowPos[b];
            nowPos[b] = c;
        }
        if (a == 1 && b == 0)
        {
            Vector3[] positionsA = { pos[0].localPosition, pos[1].localPosition, pos[2].localPosition };
            Vector3[] positionsB = { pos[2].localPosition, pos[0].localPosition };
            Sequence quence = DOTween.Sequence();
            shells[nowPos[a]].transform.DOLocalPath(positionsB, 2, PathType.CatmullRom, PathMode.Full3D, 50).SetOptions(false);
            shells[nowPos[b]].transform.DOLocalPath(positionsA, 2, PathType.CatmullRom, PathMode.Full3D, 50).SetOptions(false);
            if (pearlPos == 1)
            {
                pearlPos = 0;
            }
            else if (pearlPos == 0)
            {
                pearlPos = 1;
            }
            var c = nowPos[a];
            nowPos[a] = nowPos[b];
            nowPos[b] = c;
        }
        if (a == 0 && b == 2)
        {
            Vector3[] positionsA = { pos[0].localPosition, pos[1].localPosition, pos[3].localPosition, pos[4].localPosition };
            Vector3[] positionsB = { pos[4].localPosition, pos[3].localPosition, pos[1].localPosition, pos[0].localPosition };
            Sequence quence = DOTween.Sequence();
            shells[nowPos[a]].transform.DOLocalPath(positionsA, 2, PathType.CatmullRom, PathMode.Full3D, 50).SetOptions(false);
            shells[nowPos[b]].transform.DOLocalPath(positionsB, 2, PathType.CatmullRom, PathMode.Full3D, 50).SetOptions(false);
            if (pearlPos == 0)
            {
                pearlPos = 2;
            }
            else if (pearlPos == 2)
            {
                pearlPos = 0;
            }
            var c = nowPos[a];
            nowPos[a] = nowPos[b];
            nowPos[b] = c;
        }
        if (a == 2 && b == 0)
        {
            Vector3[] positionsA = { pos[0].localPosition, pos[1].localPosition, pos[3].localPosition, pos[4].localPosition };
            Vector3[] positionsB = { pos[4].localPosition, pos[3].localPosition, pos[1].localPosition, pos[0].localPosition };
            Sequence quence = DOTween.Sequence();
            shells[nowPos[a]].transform.DOLocalPath(positionsB, 2, PathType.CatmullRom, PathMode.Full3D, 50).SetOptions(false);
            shells[nowPos[b]].transform.DOLocalPath(positionsA, 2, PathType.CatmullRom, PathMode.Full3D, 50).SetOptions(false);
            if (pearlPos == 2)
            {
                pearlPos = 0;
            }
            else if (pearlPos == 0)
            {
                pearlPos = 2;
            }
            var c = nowPos[a];
            nowPos[a] = nowPos[b];
            nowPos[b] = c;
        }
        if (a == 1 && b == 2)
        {
            Vector3[] positionsA = { pos[2].localPosition, pos[3].localPosition, pos[4].localPosition };
            Vector3[] positionsB = { pos[4].localPosition, pos[2].localPosition };
            Sequence quence = DOTween.Sequence();
            shells[nowPos[a]].transform.DOLocalPath(positionsA, 2, PathType.CatmullRom, PathMode.Full3D, 50).SetOptions(false);
            shells[nowPos[b]].transform.DOLocalPath(positionsB, 2, PathType.CatmullRom, PathMode.Full3D, 50).SetOptions(false);
            if (pearlPos == 1)
            {
                pearlPos = 2;
            }
            else if (pearlPos == 2)
            {
                pearlPos = 1;
            }
            var c = nowPos[a];
            nowPos[a] = nowPos[b];
            nowPos[b] = c;
        }
        if (a == 2 && b == 1)
        {
            Vector3[] positionsA = { pos[2].localPosition, pos[3].localPosition, pos[4].localPosition };
            Vector3[] positionsB = { pos[4].localPosition, pos[2].localPosition };
            Sequence quence = DOTween.Sequence();
            shells[nowPos[a]].transform.DOLocalPath(positionsB, 2, PathType.CatmullRom, PathMode.Full3D, 50).SetOptions(false);
            shells[nowPos[b]].transform.DOLocalPath(positionsA, 2, PathType.CatmullRom, PathMode.Full3D, 50).SetOptions(false);
            if (pearlPos == 2)
            {
                pearlPos = 1;
            }
            else if (pearlPos == 1)
            {
                pearlPos = 2;
            }
            var c = nowPos[a];
            nowPos[a] = nowPos[b];
            nowPos[b] = c;
        }
    }
    public void shellRollFinish()
    {
        pearl.transform.localPosition = shellPos[pearlPos];
        pos[0].GetComponent<BoxCollider2D>().enabled = true;
        pos[2].GetComponent<BoxCollider2D>().enabled = true;
        pos[4].GetComponent<BoxCollider2D>().enabled = true;    
    }
    public void shellAnswer(int a)
    {
        shells[nowPos[a]].GetComponent<SpriteRenderer>().sprite = shellOn;
        if(a == pearlPos)
        {
            succeedEvent.Invoke();
            realPearl.transform.position = pearl.transform.position;
            realPearl.SetActive(true);
            pearl.SetActive(true);
        }
        if(a != pearlPos)
        {
            failedEvent.Invoke();
            failedWaring();
           //StartCoroutine(RestartRoll());
        }
    }
    public void ResetShell()
    {
        startPearl.SetActive(true);
        pearl.SetActive(false);
        for(int i=0; i<shells.Count; i++)
        {
            shells[i].transform.localPosition = shellPos[i];
            shells[i].GetComponent<SpriteRenderer>().sprite = shellOff;
        }
        shells[1].GetComponent<SpriteRenderer>().sprite = shellOn;
    }
    IEnumerator RestartRoll()
    {
        yield return new WaitForSeconds(2f);
        shellGameInvoke();
    }
    void failedWaring()
    {
        if(tip != null)
        {
            tip.SetActive(true);
                        if (GameManager2.instance.languageNum == 0)
                        {
                            tip.transform.Find("tipText").GetComponent<Text>().text = warningTextJ;
                            GameObject obj = Instantiate(Resources.Load<GameObject>("Fonts/UDDigiKyokashoN-B"));
                            tip.transform.Find("tipText").GetComponent<Text>().font = obj.GetComponent<Text>().font;
                            DestroyImmediate(obj);
                        }
                        if (GameManager2.instance.languageNum == 1)
                        {
                            tip.transform.Find("tipText").GetComponent<Text>().text = warningTextE;
                            GameObject obj = Instantiate(Resources.Load<GameObject>("Fonts/UDDigiKyokashoN-B"));
                            tip.transform.Find("tipText").GetComponent<Text>().font = obj.GetComponent<Text>().font;
                            DestroyImmediate(obj);
                        }
                        if (GameManager2.instance.languageNum == 2)
                        {
                            tip.transform.Find("tipText").GetComponent<Text>().text = warningTextCN;
                            GameObject obj = Instantiate(Resources.Load<GameObject>("Fonts/简剪纸"));
                            tip.transform.Find("tipText").GetComponent<Text>().font = obj.GetComponent<Text>().font;
                            DestroyImmediate(obj);
                        }
                        //
                        StartCoroutine("warningClose");
            restartChoose.SetActive(true);
        }
    }
    IEnumerator warningClose()
    {
        yield return new WaitForSeconds(warningTime);
        tip.SetActive(false);
    }
}

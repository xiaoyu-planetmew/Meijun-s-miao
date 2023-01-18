using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;
using Spine;
using Spine.Unity;
using static Spine.AnimationState;

public class zhuLinController : MonoBehaviour
{
    public GameObject fuDao;
    public GameObject wall;
    public GameObject kaleido;
    public GameObject moment5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(kaleido.activeInHierarchy == true)
        {
            if(kaleido.transform.Find("group1").GetComponent<kaledoControl>().groupRight && kaleido.transform.Find("group1 (1)").GetComponent<kaledoControl>().groupRight && kaleido.transform.Find("group1 (2)").GetComponent<kaledoControl>().groupRight)
            {
                kaleido.SetActive(false);
                zhuLin3();
            }
        }
    }
    public void zhuLin1()
    {
        GameManager2.instance.player.GetComponent<FinalMovement>().changeCanMove(false);
        fuDao.transform.DOLocalMoveY(-27.38f, 2).OnComplete(() => {
            GameManager2.instance.player.GetComponent<FinalMovement>().changeCanMove(true);
            fuDao.transform.Find("fudaoTrigger").gameObject.SetActive(true);
        });
    }
    public void zhuLin2()
    {
        GameManager2.instance.player.GetComponent<FinalMovement>().changeCanMove(false);
        fuDao.transform.DOLocalMoveY(-2.74f, 2).OnComplete(() => {
            GameManager2.instance.player.GetComponent<FinalMovement>().changeCanMove(true);
            wall.SetActive(true);
        });
    }
    public void zhuLin4()
    {
        GameManager2.instance.player.GetComponent<FinalMovement>().changeCanMove(false);
        fuDao.transform.DOLocalMoveY(-27.38f, 2).OnComplete(() => {
            GameManager2.instance.player.GetComponent<FinalMovement>().changeCanMove(true);
            //fuDao.transform.Find("fudaoTrigger").gameObject.SetActive(true);
        });
    }
    public void zhuLin3()
    {
        moment5.SetActive(true);
    }
}

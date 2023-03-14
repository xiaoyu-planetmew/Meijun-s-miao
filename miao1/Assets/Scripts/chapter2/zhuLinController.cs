using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    public GameObject NPC;
    public GameObject shenniao;
    public GameObject bamboo;
    public GameObject kanZhuZi;
    public GameObject kanZhuZiCanvas;
    public int cutTimes = 0;
    Vector3 camPos;
    public GameObject cutDownButton;
    public GameObject fuDao3;
    public GameObject fuDao4;
    //public GameObject
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
                //kaleido.SetActive(false);
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
        fuDao.transform.DOLocalMoveY(-27.38f, 7).OnComplete(() => {
            GameManager2.instance.player.GetComponent<FinalMovement>().changeCanMove(true);
            //fuDao.transform.Find("fudaoTrigger").gameObject.SetActive(true);
        });
        zhuLin5();
    }
    public void zhuLin3()
    {
        StartCoroutine(zhulin3Delay());
        for(int i=0; i<kaleido.transform.childCount; i++)
        {
            for(int j=0; j<kaleido.transform.GetChild(i).childCount; j++)
            {
                kaleido.transform.GetChild(i).GetChild(j).gameObject.GetComponent<kaleidoRotate>().canBeDrag = false;
                kaleido.transform.GetChild(i).GetChild(j).gameObject.GetComponent<Image>().DOFade(0, 2);
            }
        }
    }
    IEnumerator zhulin3Delay()
    {
        yield return new WaitForSeconds(2f);
        kaleido.SetActive(false);
        moment5.SetActive(true);
    }
    public void zhuLin5()
    {
        shenniao.GetComponent<SkeletonAnimation>().state.SetAnimation(0, "idle", true);
        NPC.transform.position = new Vector3(-40.64f, -0.9f, 0);
        NPC.transform.Find("Spine GameObject (wushi)").transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        NPC.transform.Find("JiangSongCanvas").GetComponent<NearShow>().enabled = true;
        //NPC.transform.Find("musicFollow").transform.position = new Vector3(-43.55f, 1.84f, -5.14f);
    }
    public void zhulin6()
    {
        //GameManager2.instance.AddItem(bamboo);
        kanZhuZiCanvas.SetActive(true);
        fuDao3.SetActive(true);
        GameManager2.instance.player.GetComponent<FinalMovement>().changeCanMove(true);
        NPC.transform.Find("JiangSongCanvas").GetComponent<NearShow>().enabled = true;
    }
    public void zhulin7()
    {
        if (cutTimes == 0)
        {
            cutDownButton.SetActive(false);
            GameManager2.instance.player.GetComponent<FinalMovement>().changeCanMove(false);
            camPos = GameObject.Find("Main Camera").transform.position;
            GameObject.Find("Main Camera").gameObject.GetComponent<CinemachineBrain>().enabled = false;
            
            DG.Tweening.Sequence quence = DOTween.Sequence();

            quence.Append(GameObject.Find("Main Camera").transform.DOMove(new Vector3(-58.16f, 26.57f, -6.69f), 3).OnComplete(() =>
            {
                //face.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "disappear", false);
            }));
            quence.AppendInterval(3).OnComplete(() =>
            {
                cutDownButton.SetActive(true);
            });
        }
        if(cutTimes < 4 && cutTimes > 0)
        {
            cutDownButton.SetActive(false);
            DG.Tweening.Sequence quence = DOTween.Sequence();
            kanZhuZi.transform.GetChild(cutTimes-1).gameObject.GetComponent<SpriteRenderer>().enabled = false;
            kanZhuZi.transform.GetChild(cutTimes-1).GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;
            kanZhuZi.transform.GetChild(cutTimes-1).GetChild(1).gameObject.GetComponent<SpriteRenderer>().enabled = true;
            kanZhuZi.GetComponent<Animator>().SetTrigger(cutTimes.ToString());
            quence.AppendInterval(0.3f).OnComplete(() =>
            {
                cutDownButton.SetActive(true);
            });
        }
        if(cutTimes >= 3)
        {
            cutDownButton.SetActive(false);
            MouseSet.Instance.mouseChange("mouseTexture");
            bamboo.SetActive(true);
            //maple.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "disappear", false);
            DG.Tweening.Sequence quence = DOTween.Sequence();
            quence.AppendInterval(3);
            //hudie.GetComponent<SkeletonAnimation>().Skeleton.A = 0;
            //hudie.gameObject.SetActive(true);
            //hudie.gameObject.GetComponent<Animator>().SetTrigger("appear");
            //StartCoroutine(hudieAppear());
            quence.Append(GameObject.Find("Main Camera").transform.DOMove(camPos, 2).OnComplete(() =>
            {
                //hudie.GetComponent<SkeletonAnimation>().Skeleton.A = 1;
                GameObject.Find("Main Camera").gameObject.GetComponent<CinemachineBrain>().enabled = true;
                GameManager2.instance.player.GetComponent<FinalMovement>().changeCanMove(true);
                fuDao4.SetActive(true);
                //npc.gameObject.SetActive(true);
                //npc.transform.Find("JiangSongCanvas").gameObject.GetComponent<NearShow>().enabled = true;
                //laoPoPo.gameObject.SetActive(true);
                //maple.gameObject.SetActive(false);
                
                //hudieCanvas.gameObject.SetActive(true);
            }));
            
        }
        cutTimes++;
    }
    public void zhulin8()
    {
        GameManager2.instance.player.GetComponent<FinalMovement>().changeCanMove(false);
        fuDao.transform.DOLocalMoveY(-27.38f, 7).OnComplete(() => {
            GameManager2.instance.player.GetComponent<FinalMovement>().changeCanMove(true);
            //fuDao.transform.Find("fudaoTrigger").gameObject.SetActive(true);
        });
    }
}

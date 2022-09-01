using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;

public class openingCamera : MonoBehaviour
{
    public bool actived = false;
    // Start is called before the first frame update
    void Start()
    {
        cam1();
    }
    void cam1()
    {
        GameManager2.instance.player.GetComponent<FinalMovement>().canMove = false;
        //GameManager2.instance.player.GetComponent<PlayerUnderWaterControl>().enabled = false;
        Sequence quence = DOTween.Sequence();
        quence.Append(transform.DOMove(new Vector3(-43.34f, 2.2f, -7.58f), 5).OnComplete(() =>
        {
            //this.gameObject.GetComponent<CinemachineBrain>().enabled = true;
            this.transform.Find("darkMask").GetComponent<SpriteRenderer>().enabled = false;
        }));
        quence.Join(this.transform.Find("darkMask").GetComponent<SpriteRenderer>().DOFade(0, 5).OnComplete(() => {
            //GameManager2.instance.player.GetComponent<FinalMovement>().canMove = true;
            //GameManager2.instance.player.GetComponent<PlayerUnderWaterControl>().enabled = true;
        })); ;
    }
    public void cam2()
    {
        Sequence quence = DOTween.Sequence();
        quence.Append(transform.DOMove(new Vector3(-43.34f, 3.706468f, -10f), 5).OnComplete(() =>
        {
            //this.gameObject.GetComponent<CinemachineBrain>().enabled = true;
            //this.transform.Find("darkMask").GetComponent<SpriteRenderer>().enabled = false;
        }));
    }
    // Update is called once per frame
    void Update()
    {
        //-43.34f, 3.706468f, -10f
    }
}

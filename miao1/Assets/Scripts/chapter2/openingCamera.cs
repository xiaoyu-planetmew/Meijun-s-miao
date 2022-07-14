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
        Sequence quence = DOTween.Sequence();
        quence.Append(transform.DOMove(new Vector3(-44.92f, 3.706468f, -10f), 5).OnComplete(() =>
        {
            this.gameObject.GetComponent<CinemachineBrain>().enabled = true;
            this.transform.Find("darkMask").GetComponent<SpriteRenderer>().enabled = false;
        }));
        quence.Join(this.transform.Find("darkMask").GetComponent<SpriteRenderer>().DOFade(0, 5));
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

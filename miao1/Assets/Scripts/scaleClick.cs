using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class scaleClick : MonoBehaviour
{
    bool scaleBool;
    public float scaleLong;
    public float scaleShort;
    public float scaleDuration;
    // Start is called before the first frame update
    void Start()
    {
        scaleBool = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void scaleAct()
    {
        if(!scaleBool)
        {
            scaleBool = true;
            Sequence s = DOTween.Sequence();
            s.Append(transform.DOScaleY(scaleShort, scaleDuration));
            s.Append(transform.DOScaleY(scaleLong, scaleDuration * 2));
            s.Append(transform.DOScaleY(1, scaleDuration));
            s.AppendCallback(() => 
            {
                scaleFinish();
            });
        }
    }
    private void scaleFinish()
    {
        scaleBool = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class itemScale : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Sequence s = DOTween.Sequence();
        s.Append(this.transform.DOScale(new Vector3(0.6f, 0.6f, 0.6f), 0.2f));
        s.Append(this.transform.DOScale(new Vector3(0.4f, 0.4f, 0.4f), 0.4f));
        s.Append(this.transform.DOScale(new Vector3(0.5f, 0.5f, 0.5f), 0.2f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

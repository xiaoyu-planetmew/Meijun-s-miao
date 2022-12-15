using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;
using DG.Tweening;
public class shakeClick : MonoBehaviour
{
    bool shakeBool;
    public float leftAngle;
    public float rightAngle;
    public float duration;
    public UnityEvent afterShake;

    // Start is called before the first frame update
    void Start()
    {
        shakeBool = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void shakeAct()
    {
        if(!shakeBool)
        {
            shakeBool = true;
            //Tweener t = transform.DOShakeRotation(0.5f, new Vector3(0, 0, 50), 2);
            Sequence s = DOTween.Sequence();
            s.Append(transform.DORotate(new Vector3(0, 0, rightAngle), duration));
            s.Append(transform.DORotate(new Vector3(0, 0, leftAngle), duration * 2f));
            s.Append(transform.DORotate(new Vector3(0, 0, 0), duration));
            s.AppendCallback(() => 
            {
                shakeFinish();
            });
            //t.onComplete(shakeFinish);
        }
    }
    private void shakeFinish()
    {
        this.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
        shakeBool = false;
        afterShake.Invoke();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class jumpClick : MonoBehaviour
{
    bool jumpBool;
    public float jumpHight;
    public float jumpDuration;
    float x;
    float y;
    float z;
    // Start is called before the first frame update
    void Start()
    {
        jumpBool = false;
        x = transform.position.x;
        y = transform.position.y;
        z = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void jumpAct()
    {
        if(!jumpBool)
        {
            jumpBool = true;
            Sequence t = transform.DOJump(new Vector3(this.transform.position.x, this.transform.position.y+jumpHight, this.transform.position.z), jumpHight, 1, jumpDuration);
            //t.Append(transform.DOPlayBackwards());
            t.AppendInterval(0.5f);
            t.AppendCallback(() => 
            {
                transform.DORewind();
                onComplete();
            });
            //transform.DOPlayBackwards();
            
        }
    }
    private void onComplete()
    {
        transform.position = new Vector3(x, y, z);
        jumpBool = false;
    }
}

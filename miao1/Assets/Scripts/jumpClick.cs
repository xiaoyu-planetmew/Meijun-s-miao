using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class jumpClick : MonoBehaviour
{
    bool jumpBool;
    public float jumpHight;
    public float jumpDuration;
    // Start is called before the first frame update
    void Start()
    {
        jumpBool = false;
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
            t.AppendCallback(() => 
            {
                onComplete();
            });
            //transform.DOPlayBackwards();
            
        }
    }
    private void onComplete()
    {
        jumpBool = false;
    }
}

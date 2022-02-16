using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BBackgroundScale : MonoBehaviour
{
    public GameObject BG;
    public bool hitting;
    public bool holding;
    public bool shrinking;
    public float hitEnlargeSpeed;
    public float holdEnlargeSpeed;
    public float shrinkSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(hitting && BG.transform.localScale.x <= 1.5f)
        {
            BG.transform.DOPause();
            BG.transform.DOScale(new Vector3(BG.transform.localScale.x + hitEnlargeSpeed, BG.transform.localScale.y + hitEnlargeSpeed, 0), 0.2f);
            hitting = false;
            shrinking = true;
            //BG.transform.localScale += new Vector3(hitEnlargeSpeed, hitEnlargeSpeed, 0);
        }
        if(holding && BG.transform.localScale.x <= 1.5f && BG.transform.localScale.x >= 1.48f)
        {
            BG.transform.DOPause();
        }else
        if(holding && BG.transform.localScale.x <= 1.5f)
        {
            BG.transform.DOPause();
            BG.transform.DOScale(new Vector3(BG.transform.localScale.x + holdEnlargeSpeed, BG.transform.localScale.y + holdEnlargeSpeed, 0), 0.25f);
            //BG.transform.localScale += new Vector3(holdEnlargeSpeed, holdEnlargeSpeed, 0);
        }
        if(shrinking && BG.transform.localScale.x >= 1f)
        {
            BG.transform.DOPause();
            BG.transform.DOScale(new Vector3(BG.transform.localScale.x - shrinkSpeed, BG.transform.localScale.y - shrinkSpeed, 0), 1f);
            
            //BG.transform.localScale -= new Vector3(shrinkSpeed, shrinkSpeed, 0);
        }
        if(!Input.anyKey || (!hitting && !holding))
        {
            hitting = false;
            holding = false;
            shrinking = true;
        }else{
            shrinking = false;
        }
    }
    public void hitScale()
    {
        hitting = true;
    }
    public void holdScale()
    {
        holding = true;
    }
    public void shrinkScale()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetSequenceAni : MonoBehaviour
{
    public Sprite s;
    // Start is called before the first frame update
    void Start()
    {
        //s = this.gameObject.GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void resetAni()
    {
        this.GetComponent<Animator>().Play("default");
        this.gameObject.GetComponent<SpriteRenderer>().sprite = s;
    }
}

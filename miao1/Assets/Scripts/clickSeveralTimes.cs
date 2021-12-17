using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickSeveralTimes : MonoBehaviour
{
    public int times;
    public Animator ani;
    public GameObject _item;
    int clickCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void click()
    {
        if(clickCount == times)
        {
            _item.SetActive(true);
        }else{       
            ani.SetTrigger("click");
            clickCount++;
        }
    }
}

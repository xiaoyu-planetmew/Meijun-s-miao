using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventoryScroll : MonoBehaviour
{
    public GameObject scrollBar;
    public float scrollValue;
    // Start is called before the first frame update
    void Start()
    {
        scrollBar = this.transform.GetChild(1).gameObject;
        
    }

    // Update is called once per frame
    void Update()
    {
        scrollValue = scrollBar.GetComponent<Scrollbar>().value;
    }
    public void left()
    {
        if(scrollValue >= 0.05f)
        {
            scrollBar.GetComponent<Scrollbar>().value -= 0.05f;
        }else{
            scrollBar.GetComponent<Scrollbar>().value = 0;
        }
    }
    public void right()
    {
        if(scrollValue <= 0.95f)
        {
            scrollBar.GetComponent<Scrollbar>().value += 0.05f;
        }else{
            scrollBar.GetComponent<Scrollbar>().value = 1;
        }
    }
}

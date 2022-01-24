using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moment4Compound : MonoBehaviour
{
    public Item seed;
    public Item moment;
    public Item target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.items.Contains(seed) && GameManager.instance.items.Contains(moment))
        {
            GameManager.instance.RemoveItem(seed);
            GameManager.instance.RemoveItem(moment);
            GameManager.instance.AddItem(target);
            GameManager.instance.events[16] = true;
            this.GetComponent<moment4Compound>().enabled = false;
        }
    }
}

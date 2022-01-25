using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basementKeyCheck : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.items.Contains(items[0]))
        {
            GameManager.instance.events[24] = true;
        }
        if(GameManager.instance.items.Contains(items[1]))
        {
            GameManager.instance.events[25] = true;
        }
    }
}

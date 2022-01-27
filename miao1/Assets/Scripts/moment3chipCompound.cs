using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moment3chipCompound : MonoBehaviour
{
    public Item chip1;
    public Item chip2;
    public Item chip3;
    public Item target;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if ((GameManager.instance.items.Contains(chip1)) && (GameManager.instance.items.Contains(chip2)) && (GameManager.instance.items.Contains(chip3)))
        {
            //GameManager.instance.RemoveItem(seed);
            GameManager.instance.RemoveItem(chip1);
            GameManager.instance.RemoveItem(chip2);
            GameManager.instance.RemoveItem(chip3);
            GameManager.instance.AddItem(target);
            //GameManager.instance.events[16] = true;
            this.GetComponent<moment3chipCompound>().enabled = false;
        }
    }
}
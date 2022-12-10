using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chipCompound : MonoBehaviour
{
    public List<Item> chips1 = new List<Item>();
    public Item target;
    int chips1Count = 0;
    public List<bool> finished = new List<bool>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!finished[0])
        {
            for (int i = 0; i < chips1.Count; i++)
            {
                if (GameManager2.instance.items.Contains(chips1[i]))
                {
                    chips1Count++;
                }
            }
            if (GameManager2.instance.items.Contains(target))
            {
                for (int i = 0; i < chips1.Count; i++)
                {
                    GameManager2.instance.RemoveItem(chips1[i]);
                }
                finished[0] = true;
            }
            if (chips1Count == chips1.Count)
            {
                for (int i = 0; i < chips1.Count; i++)
                {
                    GameManager2.instance.RemoveItem(chips1[i]);
                }
                GameManager2.instance.AddItem(target);
                //this.GetComponent<chipCompound>().enabled = false;
            }
            else chips1Count = 0;
        }
    }
}

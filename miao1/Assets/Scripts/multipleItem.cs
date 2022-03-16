using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class multipleItem : MonoBehaviour
{
    public List<GameObject> objs = new List<GameObject>();
    public Item _item;
    bool finish = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    async void Update()
    {
        if(GameManager.instance.items.Contains(_item) && !finish)
        {
            for(int i=0;i<objs.Count;i++)
            {
                if(objs[i])
                {
                    //objs[i].SetActive(false);
                    objs[i].GetComponent<eventLimit>().enabled = false;
                    objs[i].GetComponent<BoxCollider>().enabled = false;
                }
            }
            finish = true;
        }        
    }
}

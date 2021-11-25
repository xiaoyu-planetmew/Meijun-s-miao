using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moment2chipCompound : MonoBehaviour
{
    int c;
    public Item item1Change;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        c = 0;
        for(int i = 0; i < GameManager.instance.items.Count; i++)
        {
            if(GameManager.instance.items[i].itemDes == "A chip of moment2")
            {
                c++;
            }
        }
        if(c == 3 || GameManager.instance.events[5])
        {
            for(int i = 0; i < GameManager.instance.items.Count; i++)
            {
                if(GameManager.instance.items[i].itemName == "moment2Chip1")
                {
                    GameManager.instance.TradeItem(GameManager.instance.items[i], item1Change);
                    GameManager.instance.events[5] = true;
                }
                if(GameManager.instance.items[i].itemName == "moment2Chip2" || GameManager.instance.items[i].itemName == "moment2Chip3")
                {
                    GameManager.instance.RemoveItem(GameManager.instance.items[i]);
                }
            }
            StartCoroutine(jobFinish());
            //this.gameObject.GetComponent<moment2chipCompound>().enabled = false;
        }
        
    }
    IEnumerator jobFinish()
    {
        yield return new WaitForSeconds(0.1f);
        this.gameObject.GetComponent<moment2chipCompound>().enabled = false;
    }
}
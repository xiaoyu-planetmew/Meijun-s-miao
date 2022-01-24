using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getMoment4 : MonoBehaviour
{
    public Item obj;
    public string str;
    bool finish = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.items.Contains(obj) && !finish)
        {
            inventoryResponse.instance.girlTip(str);
            finish = true;
            this.GetComponent<getMoment4>().enabled = false;
        }
    }
}

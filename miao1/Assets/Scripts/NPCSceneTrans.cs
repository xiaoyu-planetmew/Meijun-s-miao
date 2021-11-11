using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSceneTrans : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnEnable()
    {
        if(GameManager.instance.events[0] && !GameManager.instance.events[6])
        {
            this.transform.GetChild(0).gameObject.SetActive(true);
        }
        if(GameManager.instance.events[5] && !GameManager.instance.events[7])
        {
            this.transform.GetChild(1).gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

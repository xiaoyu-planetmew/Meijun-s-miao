using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSceneTrans : MonoBehaviour
{
    public GameObject trans1;
    public GameObject trans2;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void turnOn()
    {
        if(GameManager.instance.events[0] && !GameManager.instance.events[1])
        {
            trans1.SetActive(true);
            trans1.transform.Find("Button").gameObject.SetActive(true);
        }
        if(GameManager.instance.events[5] && !GameManager.instance.events[7])
        {
            trans2.SetActive(true);
            trans2.transform.Find("Button").gameObject.SetActive(true);
        }
    }
    public void turnOff()
    {
        trans1.SetActive(false);
        foreach(Transform child in trans1.transform)
        {
            child.gameObject.SetActive(false);
        }
        trans2.SetActive(false);
        foreach(Transform child in trans2.transform)
        {
            child.gameObject.SetActive(false);
        }
    }
    // Update is called once per frame
    
}

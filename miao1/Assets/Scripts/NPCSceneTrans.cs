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
    void OnEnable()
    {
        if(GameManager.instance.events[0] && !GameManager.instance.events[1])
        {
            trans1.SetActive(true);
        }
        if(GameManager.instance.events[5] && !GameManager.instance.events[7])
        {
            trans2.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

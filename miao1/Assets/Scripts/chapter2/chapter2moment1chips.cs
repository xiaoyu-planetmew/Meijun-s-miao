using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chapter2moment1chips : MonoBehaviour
{
    public GameObject item;
    //public GameObject team;
    public bool getItem = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void showItem()
    {
        if(!getItem)
        {
            getItem = true;
            //team.GetComponent<chapter2moment1chips>().getItem = true;
            item.SetActive(true);
        }
    }
}

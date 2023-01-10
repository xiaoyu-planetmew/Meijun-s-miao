using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class wall4 : MonoBehaviour
{
    public UnityEvent e;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void act()
    {
        if(EventControl.Instance.events[5] && EventControl.Instance.events[6])
        {
            e.Invoke();
        }
    }
}

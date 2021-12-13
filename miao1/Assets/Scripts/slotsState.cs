using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slotsState : MonoBehaviour
{
    public bool slotCanBeClick;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void turnOffInventory()
    {
        slotCanBeClick = false;
    }
    public void turnOnInventory()
    {
        slotCanBeClick = true;
    }
}

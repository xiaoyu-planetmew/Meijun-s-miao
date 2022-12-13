using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class mouseChangeObj: MonoBehaviour
{
    public string mouse;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseEnter()
    {
       MouseSet.Instance.mouseChange(mouse);
    } 
    void OnMouseOver()
    {
       MouseSet.Instance.mouseChange(mouse);
    } 
    void OnMouseExit()
    {
        MouseSet.Instance.mouseChange("mouseTexture");
    }
    public void ExitUI()
    {
        MouseSet.Instance.mouseChange("mouseTexture");
    }
}

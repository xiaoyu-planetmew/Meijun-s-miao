using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class mapleCutDown : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        MouseSet.Instance.mouseChange("axe1");
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        MouseSet.Instance.mouseChange("mouseTexture");
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        MouseSet.Instance.mouseChange("axe2");
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        MouseSet.Instance.mouseChange("axe1");
    }
    
}

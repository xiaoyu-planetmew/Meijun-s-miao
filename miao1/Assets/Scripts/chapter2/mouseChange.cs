using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class mouseChange : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
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
    public void OnPointerEnter(PointerEventData eventData)
    {
        MouseSet.Instance.mouseChange(mouse);
    }
    public void OnPointerOver(PointerEventData eventData)
    {
        MouseSet.Instance.mouseChange(mouse);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        MouseSet.Instance.mouseChange("mouseTexture");
    }
    public void ExitUI()
    {
        MouseSet.Instance.mouseChange("mouseTexture");
    }
}

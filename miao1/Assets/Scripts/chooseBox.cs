using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Text;
using UnityEngine.UI;

public class chooseBox : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler//, IPointerClickHandler
{
    public Text option;
    public GameObject pointer;
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
        pointer.SetActive(true);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        pointer.SetActive(false);
    }
   
}

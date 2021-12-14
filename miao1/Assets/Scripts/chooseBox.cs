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
        this.gameObject.GetComponent<Text>().color = new Color32(69, 69, 69, 255);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        pointer.SetActive(false);
        this.gameObject.GetComponent<Text>().color = new Color32(69, 69, 69, 153);
    }
   
}

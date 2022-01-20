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
    bool isIn = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(!isIn)
        {
            pointer.SetActive(false);
            option.color = new Color32(69, 69, 69, 153);
        }
    }
    void onEnable()
    {
        
    }
    public void beOut()
    {
        isIn = false;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        pointer.SetActive(true);
        option.color = new Color32(69, 69, 69, 255);
        isIn = true;
        //this.transform.parent.gameObject.GetComponent<Text>().color = new Color32(69, 69, 69, 255);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        pointer.SetActive(false);
        option.color = new Color32(69, 69, 69, 153);
        isIn = false;
        //this.transform.parent.gameObject.GetComponent<Text>().color = new Color32(69, 69, 69, 153);
    }
   
}

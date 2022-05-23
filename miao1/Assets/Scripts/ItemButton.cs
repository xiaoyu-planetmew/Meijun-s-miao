using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Text;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public int buttonID;
    public Item thisItem;
    public GameObject tip;

    public Tooltips tooltip;
    private Vector2 position;

    //HELPER FUNCTION to get the items on this button
    void Start()
    {
        tip = this.transform.GetChild(1).gameObject;
    }

    private Item GetThisItem()
    {
        for(int i = 0; i < GameManager.instance.items.Count; i++)
        {
            if(buttonID == i)
            {
                thisItem = GameManager.instance.items[i];
            }
        }

        return thisItem;
    }

    public void CloseButton()
    {
        GameManager.instance.RemoveItem(GetThisItem());

        //Once we press the colse button, We have to Update the current thisItem
        thisItem = GetThisItem();
        if(thisItem != null)
        {
            //SHOW TOOLTIP
            tooltip.ShowTooltip();

            
            if(GameManager.instance.languageNum == 0)
            {
                tooltip.UpdateTooltip(thisItem.itemDesJ);
            }
            if(GameManager.instance.languageNum == 1)
            {
                tooltip.UpdateTooltip(thisItem.itemDesE);
            }
            if(GameManager.instance.languageNum == 2)
            {
                tooltip.UpdateTooltip(thisItem.itemDesCN);
            }
            RectTransformUtility.ScreenPointToLocalPointInRectangle(GameObject.Find("Canvas").transform as RectTransform, Input.mousePosition, null, out position);
            tooltip.SetPosition(position);
        }
        else
        {
            //HIDE TOOLTIP
            tooltip.HideTooltip();
            tooltip.UpdateTooltip("");//CLEAR
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetThisItem();

        if(thisItem != null)
        {
            //Debug.Log("ENTER " + thisItem.itemName + " SLOT");

            tooltip.ShowTooltip();

            //tooltip.UpdateTooltip(thisItem.itemDes);
            if(GameManager.instance.languageNum == 0)
            {
                tooltip.UpdateTooltip(thisItem.itemDesJ);
            }
            if(GameManager.instance.languageNum == 1)
            {
                tooltip.UpdateTooltip(thisItem.itemDesE);
            }
            if(GameManager.instance.languageNum == 2)
            {
                tooltip.UpdateTooltip(thisItem.itemDesCN);
            }
            //tooltip.UpdateTooltip(GetDetailText(thisItem));
            //RectTransformUtility.ScreenPointToLocalPointInRectangle(GameObject.Find("Canvas").transform as RectTransform, Input.mousePosition, null, out position);
            tooltip.SetPosition(position);
            
            tip.SetActive(true);
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        GetThisItem();
        if(thisItem != null && this.transform.parent.GetComponent<slotsState>().slotCanBeClick)
        {
            Debug.Log(thisItem.itemName);
            inventoryResponse.instance.importMessage(thisItem);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //if(thisItem != null)
        //{
            //Debug.Log("EXIT " + thisItem.itemName + " SLOT");

            tooltip.HideTooltip();
            tooltip.UpdateTooltip("");//CLEAR
            tip.SetActive(false);
        //}
    }

    //HELPER FUNCTION TO GET A SERIES OF WORDS/INFORMATION/SENTENCE
    /*private string GetDetailText(Item _item)
    {
        if(_item == null)
        {
            return "";
        }
        else
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat("<color=black><size=36>Item: </size></color> <color=black><size=36>{0}</size></color>\n\n", _item.itemName);
            stringBuilder.AppendFormat("<color=black><size=36>Sell Price: </size></color> <color=black><size=36>{0}</size></color>\n\n" + 
                                        "<size=36>Description:</size> <size=36><color=black>{1}</color></size>\n\n", _item.itemPrice, _item.itemDes);
            return stringBuilder.ToString();
        }
    }*/
}

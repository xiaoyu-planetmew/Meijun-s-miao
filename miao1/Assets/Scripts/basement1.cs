using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class basement1 : MonoBehaviour
{
    public Item target;
    public string wrongTipJ;
    public string wrongTipE;
    public string wrongTipCN;
    public bool rightSeed = false;
    public Sprite targetSprite;
    public GameObject other1;
    public GameObject other2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if((GameManager.instance.player.transform.position - this.transform.position).magnitude >= 50)
        {
            this.GetComponent<Button>().enabled = false;
        }else if(!rightSeed)
        {
            this.GetComponent<Button>().enabled = true;
        }

    }
    public void hit()
    {
        if(GameManager.instance.languageNum == 0)
        {
            
            inventoryResponse.instance.becomeUseful(target, this.gameObject, wrongTipJ);
        }
        if(GameManager.instance.languageNum == 1)
        {
            
            inventoryResponse.instance.becomeUseful(target, this.gameObject, wrongTipE);
        }
        if(GameManager.instance.languageNum == 2)
        {
            
            inventoryResponse.instance.becomeUseful(target, this.gameObject, wrongTipCN);
        }
        inventoryResponse.instance.activeInventoryTip();
        if(other1.GetComponent<Button>().enabled == true)
        {
            other1.SetActive(false);
        }
        if(other2.GetComponent<Button>().enabled == true)
        {
            other2.SetActive(false);
        }
        
    }
    public void getMessage()
    {
        GameManager.instance.RemoveItem(target);
        this.gameObject.GetComponent<Image>().sprite = targetSprite;
        this.gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        this.gameObject.GetComponent<Button>().enabled = false;
        rightSeed = true;
        other1.SetActive(true);
        other2.SetActive(true);
        inventoryResponse.instance.finishDialog();
    }
}

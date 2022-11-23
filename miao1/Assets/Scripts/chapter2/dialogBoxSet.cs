using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogBoxSet : MonoBehaviour
{
    public string dialogName;
    public int nameNum;
    public bool reverse = false;
    float scale = 0.009791746f;
    // Start is called before the first frame update
    void Start()
    {
        //scale = this.GetComponent<RectTransform>().localScale.x;
    }
    public void setDialog()
    {
        for (int i = 0; i < this.GetComponent<dialogBoxCtrl>().names.Count; i++)
        {
            if (dialogName == this.GetComponent<dialogBoxCtrl>().names[i])
            {
                nameNum = i;
                break;
            }
        }
        this.GetComponent<Image>().sprite = this.GetComponent<dialogBoxCtrl>().bg[nameNum];
        if (this.GetComponent<dialogBoxCtrl>().langNum == 2)
        {
            this.transform.GetChild(0).GetComponent<Image>().sprite = this.GetComponent<dialogBoxCtrl>().nameCN[nameNum];
            this.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(this.GetComponent<dialogBoxCtrl>().nameCN[nameNum].rect.width, this.GetComponent<dialogBoxCtrl>().nameCN[nameNum].rect.height);
        }
        if (this.GetComponent<dialogBoxCtrl>().langNum == 1)
        {
            this.transform.GetChild(0).GetComponent<Image>().sprite = this.GetComponent<dialogBoxCtrl>().nameEN[nameNum];
            this.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(this.GetComponent<dialogBoxCtrl>().nameEN[nameNum].rect.width, this.GetComponent<dialogBoxCtrl>().nameEN[nameNum].rect.height);
        }
        if (this.GetComponent<dialogBoxCtrl>().langNum == 0)
        {
            this.transform.GetChild(0).GetComponent<Image>().sprite = this.GetComponent<dialogBoxCtrl>().nameJP[nameNum];
            this.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(this.GetComponent<dialogBoxCtrl>().nameJP[nameNum].rect.width, this.GetComponent<dialogBoxCtrl>().nameJP[nameNum].rect.height);
        }
        if(reverse)
        {
            this.GetComponent<RectTransform>().localScale = new Vector3(-1 * scale, scale, scale);
            this.transform.GetChild(0).GetComponent<RectTransform>().localScale = new Vector3(-1, 1, 1);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

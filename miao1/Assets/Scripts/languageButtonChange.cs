using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class languageButtonChange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("GameManager"))
        {
        if(GameManager.instance.languageNum == 0)
        {
            this.transform.GetChild(0).gameObject.SetActive(true);
            this.transform.GetChild(1).gameObject.SetActive(false);
            this.transform.GetChild(2).gameObject.SetActive(false);
            //this.GetComponent<Text>().text = JanpanessString;
        }
        if(GameManager.instance.languageNum == 1)
        {
            this.transform.GetChild(1).gameObject.SetActive(true);
            this.transform.GetChild(0).gameObject.SetActive(false);
            this.transform.GetChild(2).gameObject.SetActive(false);
        }
        if(GameManager.instance.languageNum == 2)
        {
            this.transform.GetChild(0).gameObject.SetActive(false);
            this.transform.GetChild(1).gameObject.SetActive(false);
            this.transform.GetChild(2).gameObject.SetActive(true);
            //this.GetComponent<Text>().text = JanpanessString;
        }
        }
        else if(GameObject.Find("GameManager2"))
        {
            if (GameManager2.instance.languageNum == 0)
            {
                this.transform.GetChild(0).gameObject.SetActive(true);
                this.transform.GetChild(1).gameObject.SetActive(false);
                this.transform.GetChild(2).gameObject.SetActive(false);
                //this.GetComponent<Text>().text = JanpanessString;
            }
            if (GameManager2.instance.languageNum == 1)
            {
                this.transform.GetChild(1).gameObject.SetActive(true);
                this.transform.GetChild(0).gameObject.SetActive(false);
                this.transform.GetChild(2).gameObject.SetActive(false);
            }
            if (GameManager2.instance.languageNum == 2)
            {
                this.transform.GetChild(0).gameObject.SetActive(false);
                this.transform.GetChild(1).gameObject.SetActive(false);
                this.transform.GetChild(2).gameObject.SetActive(true);
                //this.GetComponent<Text>().text = JanpanessString;
            }
        }
        else
        {
            this.transform.GetChild(0).gameObject.SetActive(true);
            this.transform.GetChild(1).gameObject.SetActive(false);
            this.transform.GetChild(2).gameObject.SetActive(false);
        }
    }
}

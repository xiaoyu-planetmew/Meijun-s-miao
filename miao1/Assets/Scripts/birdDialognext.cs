using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class birdDialognext : MonoBehaviour
{
    public string Js1;
    public string Js2;
    public string Es1;
    public string Es2;
    public string CNs1;
    public string CNs2;
    
    public Font fontJE;
    public Font fontCN;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void click1()
    {
        GameManager.instance.player.transform.Find("Canvas").GetChild(0).gameObject.SetActive(false);
        GameManager.instance.player.transform.Find("Canvas").GetChild(0).GetChild(2).gameObject.SetActive(false);
        GameManager.instance.player.transform.Find("Canvas").GetChild(1).gameObject.SetActive(true);
        if(GameManager.instance.languageNum == 0)
        {
            GameManager.instance.player.transform.Find("Canvas").GetChild(1).transform.GetChild(0).GetComponent<Text>().text = Js1;
            GameManager.instance.player.transform.Find("Canvas").GetChild(1).transform.GetChild(0).GetComponent<Text>().font = fontJE;
            GameManager.instance.player.transform.Find("Canvas").GetChild(1).transform.GetChild(1).GetComponent<Text>().text = Js2;
            GameManager.instance.player.transform.Find("Canvas").GetChild(1).transform.GetChild(1).GetComponent<Text>().font = fontJE;
        }
        if(GameManager.instance.languageNum == 1)
        {
            GameManager.instance.player.transform.Find("Canvas").GetChild(1).transform.GetChild(0).GetComponent<Text>().text = Es1;
            GameManager.instance.player.transform.Find("Canvas").GetChild(1).transform.GetChild(1).GetComponent<Text>().text = Es2;
            GameManager.instance.player.transform.Find("Canvas").GetChild(1).transform.GetChild(0).GetComponent<Text>().font = fontJE;
            GameManager.instance.player.transform.Find("Canvas").GetChild(1).transform.GetChild(1).GetComponent<Text>().font = fontJE;
        }
        if(GameManager.instance.languageNum == 2)
        {
            GameManager.instance.player.transform.Find("Canvas").GetChild(1).transform.GetChild(0).GetComponent<Text>().text = CNs1;
            GameManager.instance.player.transform.Find("Canvas").GetChild(1).transform.GetChild(1).GetComponent<Text>().text = CNs2;
            GameManager.instance.player.transform.Find("Canvas").GetChild(1).transform.GetChild(0).GetComponent<Text>().font = fontCN;
            GameManager.instance.player.transform.Find("Canvas").GetChild(1).transform.GetChild(1).GetComponent<Text>().font = fontCN;
        }
    }
    public void click2()
    {
        //GameManager.instance.player.transform.Find("Canvas").GetChild(0).gameObject.SetActive(false);
        //GameManager.instance.player.transform.Find("Canvas").GetChild(0).GetChild(2).gameObject.SetActive(false);
        GameObject.Find("birdDialogBox").GetComponent<birdDialog>().nextDialog();
    }
}

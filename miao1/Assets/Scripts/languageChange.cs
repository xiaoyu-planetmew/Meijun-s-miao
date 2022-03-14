using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class languageChange : MonoBehaviour
{
    public string JanpanessString;
    public string EnglishString;
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
            this.GetComponent<Text>().text = JanpanessString;
        }
        if(GameManager.instance.languageNum == 1)
        {
            this.GetComponent<Text>().text = EnglishString;
        }
        }
    }
}

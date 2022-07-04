using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class languageChange : MonoBehaviour
{
    public string JanpanessString;
    public string EnglishString;
    public string ChineseString;
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
            //this.GetComponent<Text>().font = Resources.Load("Fonts/UDDigiKyokashoN-B");
            GameObject obj = Instantiate(Resources.Load<GameObject>("Fonts/UDDigiKyokashoN-B"));
            this.GetComponent<Text>().font = obj.GetComponent<Text>().font;
            DestroyImmediate(obj);
        }
        if(GameManager.instance.languageNum == 1)
        {
            this.GetComponent<Text>().text = EnglishString;
            GameObject obj = Instantiate(Resources.Load<GameObject>("Fonts/UDDigiKyokashoN-B"));
            this.GetComponent<Text>().font = obj.GetComponent<Text>().font;
            DestroyImmediate(obj);
            //this.GetComponent<Text>().font = Resources.Load("Fonts/UDDigiKyokashoN-B");
        }
        if(GameManager.instance.languageNum == 2)
        {
            this.GetComponent<Text>().text = ChineseString;
            GameObject obj = Instantiate(Resources.Load<GameObject>("Fonts/简剪纸"));
            this.GetComponent<Text>().font = obj.GetComponent<Text>().font;
            DestroyImmediate(obj);
            //this.GetComponent<Text>().font = Resources.Load("Fonts/简剪纸");
        }
        }
    }
}

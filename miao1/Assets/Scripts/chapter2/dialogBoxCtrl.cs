using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogBoxCtrl : MonoBehaviour
{
    public List<string> names = new List<string>();
    public List<Sprite> bg = new List<Sprite>();
    public List<Sprite> nameCN = new List<Sprite>();
    public List<Sprite> nameEN = new List<Sprite>();
    public List<Sprite> nameJP = new List<Sprite>();
    public int langNum = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("GameManager2"))
        {
            langNum = GameManager2.instance.languageNum;
        }
        if (GameObject.Find("GameManager"))
        {
            langNum = GameManager.instance.languageNum;
        }
        this.GetComponent<dialogBoxSet>().setDialog();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("GameManager2"))
        {
            langNum = GameManager2.instance.languageNum;
        }
        if (GameObject.Find("GameManager"))
        {
            langNum = GameManager.instance.languageNum;
        }
    }
}

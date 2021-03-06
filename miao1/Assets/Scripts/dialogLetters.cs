using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using DG.Tweening;
public class dialogLetters : MonoBehaviour
{
    public string strJ;
    public string strE;
    public string strCN;
    public string str;
    public float textSpeed;
    // Start is called before the first frame update
    void Start()
    {
        strJ.Replace("\\n", "\n");
        strE.Replace("\\n", "\n");
        strCN.Replace("\\n", "\n");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void playStart()
    {
        //StartCoroutine(SetText());
        this.transform.GetChild(0).GetComponent<Text>().text = "";
        if(GameManager.instance.languageNum == 0)
        {
            GameObject obj = Instantiate(Resources.Load<GameObject>("Fonts/UDDigiKyokashoN-B"));
            this.transform.GetChild(0).GetComponent<Text>().font = obj.GetComponent<Text>().font;
            DestroyImmediate(obj);
            this.transform.GetChild(0).GetComponent<Text>().DOText(strJ, strJ.Length * 0.05f);
            StartCoroutine(SetText(strJ.Length * 0.05f));
        }
        if(GameManager.instance.languageNum == 1)
        {
            GameObject obj = Instantiate(Resources.Load<GameObject>("Fonts/UDDigiKyokashoN-B"));
            this.transform.GetChild(0).GetComponent<Text>().font = obj.GetComponent<Text>().font;
            DestroyImmediate(obj);
            this.transform.GetChild(0).GetComponent<Text>().DOText(strE, strE.Length * 0.05f);
            StartCoroutine(SetText(strE.Length * 0.05f));
        }
        if(GameManager.instance.languageNum == 2)
        {
            GameObject obj = Instantiate(Resources.Load<GameObject>("Fonts/简剪纸"));
            this.transform.GetChild(0).GetComponent<Text>().font = obj.GetComponent<Text>().font;
            DestroyImmediate(obj);
            this.transform.GetChild(0).GetComponent<Text>().DOText(strCN, strCN.Length * 0.05f);
            StartCoroutine(SetText(strCN.Length * 0.05f));
        }
        
    }
    IEnumerator SetText(float f)
    {
        this.transform.GetChild(1).gameObject.SetActive(false);
        
        yield return new WaitForSeconds(f);
        this.transform.GetChild(1).gameObject.SetActive(true);
    }
}

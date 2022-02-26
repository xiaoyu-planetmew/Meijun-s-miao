using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogLetters : MonoBehaviour
{
    public string str;
    public float textSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void playStart()
    {
        StartCoroutine(SetText());
    }
    IEnumerator SetText()
    {
        this.transform.GetChild(1).gameObject.SetActive(false);
        
        this.transform.GetChild(0).GetComponent<Text>().text = "";
        for(int i = 0; i < str.Length; i++)
        {
            //Debug.Log(i);
            this.transform.GetChild(0).GetComponent<Text>().text += str[i];
            yield return new WaitForSeconds(textSpeed);
        }
        this.transform.GetChild(1).gameObject.SetActive(true);
    }
}

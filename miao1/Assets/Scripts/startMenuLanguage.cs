using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startMenuLanguage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("language").GetComponent<startMenuStartButton>().languageNum == 0)
        {
            this.transform.GetChild(0).gameObject.SetActive(true);
            this.transform.GetChild(1).gameObject.SetActive(false);
            this.transform.GetChild(2).gameObject.SetActive(false);
            //this.GetComponent<Text>().text = JanpanessString;
        }
        if(GameObject.Find("language").GetComponent<startMenuStartButton>().languageNum == 1)
        {
            this.transform.GetChild(1).gameObject.SetActive(true);
            this.transform.GetChild(0).gameObject.SetActive(false);
            this.transform.GetChild(2).gameObject.SetActive(false);
        }
        if(GameObject.Find("language").GetComponent<startMenuStartButton>().languageNum == 2)
        {
            this.transform.GetChild(2).gameObject.SetActive(true);
            this.transform.GetChild(0).gameObject.SetActive(false);
            this.transform.GetChild(1).gameObject.SetActive(false);
        }
    }
}

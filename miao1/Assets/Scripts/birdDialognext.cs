using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class birdDialognext : MonoBehaviour
{
    public string s1;
    public string s2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void click()
    {
        GameManager.instance.player.transform.Find("Canvas").GetChild(0).gameObject.SetActive(false);
        GameManager.instance.player.transform.Find("Canvas").GetChild(0).GetChild(2).gameObject.SetActive(false);
        GameManager.instance.player.transform.Find("Canvas").GetChild(1).gameObject.SetActive(true);
        GameManager.instance.player.transform.Find("Canvas").GetChild(1).transform.GetChild(0).GetComponent<Text>().text = s1;
        GameManager.instance.player.transform.Find("Canvas").GetChild(1).transform.GetChild(1).GetComponent<Text>().text = s2;
    }
}

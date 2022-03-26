using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallTip : MonoBehaviour
{    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs(GameManager.instance.player.transform.position.x - this.transform.position.x) <=5)
        {
            GameManager.instance.player.transform.Find("Canvas").Find("wallTip").gameObject.SetActive(true);
        }
        if(Mathf.Abs(GameManager.instance.player.transform.position.x - this.transform.position.x) >5 && Mathf.Abs(GameManager.instance.player.transform.position.x - this.transform.position.x) < 10)
        {
            GameManager.instance.player.transform.Find("Canvas").Find("wallTip").gameObject.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class eventLimit : MonoBehaviour
{
    public int eventNum;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.events[eventNum])
        {
            this.gameObject.SetActive(true);
            //var b = this.gameObject.GetComponent<Button>();
            //var s = this.gameObject.GetComponent<SpriteRenderer>();
            if(this.gameObject.GetComponent<Button>() != null)
            {
                this.gameObject.GetComponent<Button>().enabled = true;
            }
            if(this.gameObject.GetComponent<SpriteRenderer>() != null)
            {
                this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }
            if(this.gameObject.GetComponent<BoxCollider>() != null)
            {
                this.gameObject.GetComponent<BoxCollider>().enabled = true;
            }
            this.GetComponent<eventLimit>().enabled = false;
        }
    }
}

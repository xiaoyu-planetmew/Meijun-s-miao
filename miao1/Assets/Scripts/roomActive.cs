using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class roomActive : MonoBehaviour
{
    public GameObject room;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if((Mathf.Abs(room.transform.position.x - GameManager.instance.player.transform.position.x) < 50) && (Mathf.Abs(room.transform.position.y - GameManager.instance.player.transform.position.y) < 10))
        {
            this.GetComponent<GraphicRaycaster>().enabled = true;
        }else{
            this.GetComponent<GraphicRaycaster>().enabled = false;
        }
    }
}

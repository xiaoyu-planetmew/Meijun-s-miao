using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemChange : MonoBehaviour
{
    public GameObject npc;
    public Item upload;
    public Item download;
    public GameObject player;
    public bool moveStop;
    //public GameObject button;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if((((npc.transform.position - player.transform.position).magnitude) < 3f) && GameManager.instance.items.Contains(upload))
        {
            
            moveStop = true;
            //button.SetActive(true);
            GameManager.instance.RemoveItem(upload);
            GameManager.instance.AddItem(download);
        }
    }
    
}

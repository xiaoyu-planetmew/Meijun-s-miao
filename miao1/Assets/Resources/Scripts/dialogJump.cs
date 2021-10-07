using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogJump : MonoBehaviour
{
    //public GameObject item;
    //public List<string> itemNames = new List<string>();
    public Item target;
    public GameObject dialog;
    public bool jump;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(GameManager.instance.items.Count);
        for (int i = 0; i < GameManager.instance.items.Count; i++)
        {
            
            if(GameManager.instance.items[i] == target)
            {
                jump = true;
                dialog.GetComponent<DialogSystem>().jump = true;
            }
        }
    }
    
}

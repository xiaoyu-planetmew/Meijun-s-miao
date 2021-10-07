using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class longNoteDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "longDestroyer")
        {
            transform.localScale = new Vector3(1f, 0f, 1f);//×²Ç½ÔòÒô·û¶ÎÏûÊ§
            //Debug.Log("active");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chimeCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.layer == 16)
        {
            this.transform.parent.gameObject.GetComponent<windChime>().chimeAudio(this.gameObject);
            Debug.Log("chime1");
        }
    }
}

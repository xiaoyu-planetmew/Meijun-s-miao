using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraFocusFollow : MonoBehaviour
{
    public GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y + 3.6f, this.transform.position.z);
    }
}

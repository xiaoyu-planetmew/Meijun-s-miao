using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class roomCamera : MonoBehaviour
{
    public string cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find(cam).activeInHierarchy)
        {
            this.GetComponent<Canvas>().worldCamera = GameObject.Find(cam).GetComponent<Camera>();
        }
    }
}

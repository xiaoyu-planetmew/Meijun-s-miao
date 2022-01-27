using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class roomCamera : MonoBehaviour
{
    public string camName;
    public GameObject cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find(camName).activeInHierarchy)
        {
            this.GetComponent<Canvas>().worldCamera = GameObject.Find(camName).GetComponent<Camera>();
            cam = GameObject.Find(camName);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fontChange2 : MonoBehaviour
{
    public List<GameObject> texts = new List<GameObject>();
    public List<Font> fonts = new List<Font>();
    // Start is called before the first frame update
    void Start()
    {
        foreach(var t in texts)
        {
            t.GetComponent<Text>().font = fonts[GameManager2.instance.languageNum];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

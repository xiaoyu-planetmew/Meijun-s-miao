using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fontChange : MonoBehaviour
{
    public List<Text> texts = new List<Text>();
    public List<Font> fonts = new List<Font>();
    // Start is called before the first frame update
    void Start()
    {
        foreach(var t in texts)
        {
            t.font = fonts[GameManager.instance.languageNum];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

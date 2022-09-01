using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<AllIn1Shader>().ClearAllKeywords();
        //this.gameObject.GetComponent<AllIn1Shader>().SetKeywordOn("GLOW_ON");
    }
    public void ClearAllKeywords()
    {
        this.gameObject.GetComponent<AllIn1Shader>().ClearAllKeywords();
        //this.gameObject.GetComponent<AllIn1Shader>().SetKeywordOn("GLOW_ON");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

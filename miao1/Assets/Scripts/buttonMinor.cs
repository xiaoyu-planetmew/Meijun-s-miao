using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonMinor : MonoBehaviour
{
    [Header("次要按钮")]
    public KeyCode key;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(key))
        {
            this.gameObject.GetComponent<Button>().onClick.Invoke();
        }
    }
}

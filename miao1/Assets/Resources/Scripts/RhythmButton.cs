using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmButton : MonoBehaviour
{
    private Animation ani;
    public KeyCode keyToPress;
    void Start()
    {
        ani = this.GetComponent<Animation>();
    }

    void Update()
    {
        
        if (Input.GetKeyDown(keyToPress))
        {
            ani.Play("buttonDown");
        }
       
    }
}

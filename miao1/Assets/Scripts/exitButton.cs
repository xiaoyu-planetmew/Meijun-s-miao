using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class exitButton : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]bool b = true;
    public GameObject bg;
    public GameObject exitB;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        exitControl();
    }
    private void exitControl()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && b)
        {
            
            bg.SetActive(true);
            exitB.SetActive(true);
            b = false;
            Time.timeScale = 0.0f;
            Debug.Log("1");
        }
        if (Input.GetKeyDown(KeyCode.Escape) && !b)
        {
            bg.SetActive(false);
            exitB.SetActive(false);
            b = true;
            Time.timeScale = 1.0f;
        }
    }
    public void resetExit()
    {
        bg.SetActive(false);
        exitB.SetActive(false);
        b = true;
        Time.timeScale = 1.0f;
    }
}

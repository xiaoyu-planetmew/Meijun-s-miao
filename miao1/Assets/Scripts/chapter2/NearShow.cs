using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearShow : MonoBehaviour
{
    public GameObject target1;
    public GameObject target2;
    public float distance;
    public GameObject startButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Mathf.Abs(target1.transform.position.x - target2.transform.position.x) <= distance) && !DialogSys2.Instance.isTalking)
        {
            startButton.SetActive(true);
        }else
        //if ((Mathf.Abs(target1.transform.position.x - target2.transform.position.x) > distance))
        {
            startButton.SetActive(false);
        }
    }
}

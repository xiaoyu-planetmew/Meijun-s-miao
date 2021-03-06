using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;

public class CamaraFocusFollow : MonoBehaviour
{
    public GameObject obj;
    public float yAxis;
    
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y + yAxis, this.transform.position.z);
        if (obj.transform.position.x < -100)
        {
            if (obj.transform.position.x < -261)
            {
                if (cam.name == "Main Camera")
                {
                    cam.gameObject.GetComponent<CinemachineBrain>().enabled = false;
                    cam.transform.DOMove(new Vector3(-280f, 2.86f, -10f), 0.5f);
                    //cam.transform.position = new Vector3(-280f, 2.86f, -10f);
                    cam.fieldOfView = 100;
                }
            }
            else
            {
                if (cam.name == "Main Camera")
                {
                    cam.gameObject.GetComponent<CinemachineBrain>().enabled = true;
                }
            }
        }
    }
}
